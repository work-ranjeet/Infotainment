IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectInterNewsToApprove') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectInterNewsToApprove
GO

CREATE PROCEDURE SelectInterNewsToApprove
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternationalNews'

		SELECT TN.NewsID,
			TN.EditorID,
			TN.DisplayOrder,
			TN.Heading,
			TN.ShortDescription,
			TN.NewsDescription,
			TN.LanguageID,
			--TN.CountryCode,
			TN.IsApproved,
			TN.IsActive,
			TN.IsTopNews,
			TN.DttmCreated,
			TN.DttmModified,
			ImgD.ImageUrl,
			ImgD.Caption
		FROM InternationalNews TN
		LEFT JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
		WHERE TN.IsApproved = 0 AND TN.NewsType = @NewsType
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
			'SelectInterNewsToApprove',
			'Error from SelectInterNewsToApprove Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec SelectInterNewsToApprove
