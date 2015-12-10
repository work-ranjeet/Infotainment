IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectInterNews') AND type IN (
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
		LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
		WHERE TN.NewsID = @NewsID AND TN.NewsType = @NewsType
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
			'SelectInterNews',
			'Error from SelectInterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END

-- EXEC SelectInterNews '5D19439A-7A7E-470E-85FB-6B9E9EE68008'
