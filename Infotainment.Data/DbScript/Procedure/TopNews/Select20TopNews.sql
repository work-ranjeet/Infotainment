IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Select20TopNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE Select20TopNews
GO

CREATE PROCEDURE Select20TopNews
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT
		SELECT @NewsType = NewsType from NewsTYpe where EnumWord like 'TopNews'
	
		SELECT TOP 20 TN.TopNewsID, TN.EditorID, TN.DisplayOrder, TN.Heading, TN.ShortDescription, TN.NewsDescription, TN.LanguageID, TN.IsApproved, TN.IsActive, TN.DttmCreated, TN.DttmModified, ImgD.ImageUrl, Imgd.Caption
		FROM TopNews TN
		LEFT OUTER JOIN TopNewsImage TPI ON TPI.TopNewsID = TN.TopNewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
		WHERE TN.IsActive = 1 AND TN.IsApproved = 1 AND TN.NewsType = @NewsType
		ORDER BY TN.DttmCreated DESC
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'Select20TopNews', 'Error from Select20TopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--EXEC Select20TopNews
