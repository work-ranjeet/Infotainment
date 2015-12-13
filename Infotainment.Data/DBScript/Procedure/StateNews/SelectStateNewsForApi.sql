IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectStateNewsForApi')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectStateNewsForApi
GO

CREATE PROCEDURE SelectStateNewsForApi (@StateCode NVARCHAR(20))
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
			TN.StateCode,
			SC.StateName,
			TN.IsApproved,
			TN.IsActive,
			TN.IsTopNews,
			TN.DttmCreated,
			TN.DttmModified,
			ImgD.ImageUrl,
			ImgD.Caption,
			ImgD.CaptionLink
		FROM StateNews TN
		LEFT OUTER JOIN StateNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
		LEFT OUTER JOIN StateCode SC ON SC.StateCode = TN.StateCode
			AND ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
		WHERE TN.IsActive = 1
			AND TN.IsApproved = 1
			AND TN.NewsType = @NewsType
			AND TN.StateCode = @StateCode
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
