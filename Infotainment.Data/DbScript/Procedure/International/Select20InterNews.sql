IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Select20InterNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE Select20InterNews
GO

CREATE PROCEDURE Select20InterNews
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternationalNews'

		SELECT TOP 20 TN.NewsID,
			TN.EditorID,
			TN.DisplayOrder,
			TN.Heading,
			TN.ShortDescription,
			TN.NewsDescription,
			TN.LanguageID,
			--TN.CountryCode,
			TN.IsApproved,
			TN.IsActive,
			TN.DttmCreated,
			TN.DttmModified,
			ImgD.ImageUrl,
			ImgD.Caption
		FROM InternationalNews TN
		LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
		WHERE TN.IsActive = 1 AND TN.IsApproved = 1 AND TN.NewsType = @NewsType
		ORDER BY TN.DttmCreated DESC
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
			'Select20InterNews',
			'Error from Select20InterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--EXEC Select20InterNews
