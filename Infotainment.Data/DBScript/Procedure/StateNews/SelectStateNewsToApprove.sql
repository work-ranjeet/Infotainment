IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectStateNewsToApprove')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectStateNewsToApprove
GO

CREATE PROCEDURE SelectStateNewsToApprove (@StateCode NVARCHAR(20))
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		SELECT TN.NewsID,
			TN.EditorID,
			TN.DisplayOrder,
			TN.Heading,
			TN.ShortDescription,
			TN.NewsDescription,
			TN.LanguageID,
			TN.StateCode,
			TN.IsApproved,
			TN.IsActive,
			TN.IsTopNews,
			TN.DttmCreated,
			TN.DttmModified,
			ImgD.ImageUrl,
			ImgD.Caption,
			ImgD.CaptionLink
		FROM StateNews TN
		LEFT JOIN StaterNewsImage TPI ON TPI.NewsID = TN.NewsID
		LEFT JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
			AND ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
		WHERE TN.IsApproved = 0
			AND TN.NewsType = @NewsType
			AND TN.StateCode = @StateCode
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
			'SelectStateNewsToApprove',
			'Error from SelectStateNewsToApprove Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec SelectInterNewsToApprove
