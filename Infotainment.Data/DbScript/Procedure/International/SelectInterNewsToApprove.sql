IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectInterNewsToApprove')
			AND type IN (
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
		SELECT TN.NewsID,
			TN.EditorID,
			TN.DisplayOrder,
			TN.Heading,
			TN.ShortDescription,
			TN.NewsDescription,
			TN.LanguageID,
			TN.CountryCode,
			TN.IsApproved,
			TN.IsActive,
			TN.DttmCreated,
			TN.DttmModified,
			ImgD.ImageUrl
		FROM InternationalNews TN
		LEFT JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
			AND ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
		WHERE TN.IsApproved = 0
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (
			ErrorType,
			ProcedureName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			'Database Error',
			'SelectInterNewsToApprove',
			'Error from SelectInterNewsToApprove Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END

