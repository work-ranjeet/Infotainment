IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectStateNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectStateNews
GO

CREATE PROCEDURE SelectStateNews (
	@NewsID NVARCHAR(50)
	)
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		SELECT SN.NewsID,
			SN.EditorID,
			SN.DisplayOrder,
			SN.Heading,
			SN.ShortDescription,
			SN.NewsDescription,
			SN.LanguageID,
			SN.StateCode,
			SN.IsApproved,
			SN.IsActive,
			SN.IsTopNews,
			SN.DttmCreated,
			SN.DttmModified,
			ImgD.ImageUrl,
			ImgD.Caption,
			ImgD.CaptionLink
		FROM StateNews SN
		LEFT OUTER JOIN StateNewsImage TPI ON TPI.NewsID = SN.NewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
			AND ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
		WHERE SN.NewsID = @NewsID
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
			'SelectStateNews',
			'Error from SelectStateNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	-- EXEC SelectInterNews '5D19439A-7A7E-470E-85FB-6B9E9EE68008'
