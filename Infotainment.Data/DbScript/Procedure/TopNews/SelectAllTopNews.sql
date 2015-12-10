IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectAllTopNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectAllTopNews
GO

CREATE PROCEDURE SelectAllTopNews (@NextPageValue BIGINT = NULL)
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'TopNews'

		IF (@NextPageValue IS NULL)
		BEGIN
			SELECT TN.TopNewsID,
				TN.EditorID,
				TN.DisplayOrder,
				TN.Heading,
				TN.ShortDescription,
				TN.NewsDescription,
				TN.LanguageID,
				TN.IsApproved,
				TN.IsActive,
				TN.DttmCreated,
				TN.DttmModified,
				ImgD.ImageUrl,
				ImgD.Caption
			FROM TopNews TN
			LEFT OUTER JOIN TopNewsImage TPI ON TPI.TopNewsID = TN.TopNewsID
			LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
			WHERE TN.NewsType = @NewsType
			ORDER BY TN.DttmCreated DESC
		END

		IF (@NextPageValue IS NOT NULL)
		BEGIN
			SELECT *
			FROM (
				SELECT TN.TopNewsID,
					TN.EditorID,
					TN.DisplayOrder,
					TN.Heading,
					TN.ShortDescription,
					TN.NewsDescription,
					TN.LanguageID,
					TN.IsApproved,
					TN.IsActive,
					TN.DttmCreated,
					TN.DttmModified,
					ImgD.ImageUrl,
					ImgD.Caption,
					ROW_NUMBER() OVER (
						ORDER BY TN.DttmCreated DESC
						) AS Row
				FROM TopNews TN
				LEFT OUTER JOIN TopNewsImage TPI ON TPI.TopNewsID = TN.TopNewsID
				LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
				WHERE TN.NewsType = @NewsType
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
			'SelectAllTopNews',
			'Error from SelectAllTopNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--EXEC SelectAllTopNews 0
