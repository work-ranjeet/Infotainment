IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectAllInterForList') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectAllInterForList
GO

CREATE PROCEDURE SelectAllInterForList (@NextPageValue BIGINT = NULL)
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternationalNews'

		IF (@NextPageValue IS NULL)
		BEGIN
			SELECT TN.NewsID,
				TN.EditorID,
				TN.DisplayOrder,
				TN.Heading,
				TN.ShortDescription,
				TN.NewsDescription,
				TN.LanguageID,
				TN.IsApproved,
				TN.IsActive,
				TN.IsTopNews,
				TN.DttmCreated,
				TN.DttmModified,
				ImgD.ImageUrl,
				ImgD.Caption
			FROM InternationalNews TN
			LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
			LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
			WHERE TN.NewsType = @NewsType  AND TN.IsApproved = 1 AND TN.IsActive = 1
			ORDER BY TN.DttmCreated DESC
		END

		IF (@NextPageValue IS NOT NULL)
		BEGIN
			SELECT *
			FROM (
				SELECT TN.NewsID,
					TN.EditorID,
					TN.DisplayOrder,
					TN.Heading,
					TN.ShortDescription,
					TN.NewsDescription,
					TN.LanguageID,
					TN.IsApproved,
					TN.IsActive,
					TN.IsTopNews,
					TN.DttmCreated,
					TN.DttmModified,
					ImgD.ImageUrl,
					ImgD.Caption,
					ROW_NUMBER() OVER (
						ORDER BY TN.DttmCreated DESC
						) AS Row
				FROM InternationalNews TN
				LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
				LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
				WHERE TN.NewsType = @NewsType  AND TN.IsApproved = 1 AND TN.IsActive = 1
				) AS news
			WHERE news.Row > @NextPageValue AND news.Row < (@NextPageValue + 15)
		END
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (
			ErrorType,
			ErrorName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			1,
			'InternationalNews',
			'Error from InternationalNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--EXEC SelectAllInterForList 0
