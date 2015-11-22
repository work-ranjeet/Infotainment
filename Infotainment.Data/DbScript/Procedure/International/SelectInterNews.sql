IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectInterNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectInterNews
GO

CREATE PROCEDURE SelectInterNews (@NewsID NVARCHAR(50))
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
		LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
			AND ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
		WHERE TN.NewsID = @NewsID
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
			'SelectInterNews',
			'Error from SelectInterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
