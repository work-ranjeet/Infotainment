IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectTopNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectTopNews
GO

CREATE PROCEDURE SelectTopNews (@NewsID NVARCHAR(50))
AS
BEGIN
	BEGIN TRY
		SELECT TN.TopNewsID, TN.EditorID, TN.DisplayOrder, TN.Heading, TN.ShortDescription, TN.NewsDescription, TN.LanguageID, TN.IsApproved, TN.IsActive, TN.DttmCreated, TN.DttmModified, ImgD.ImageUrl
		FROM TopNews TN
		LEFT OUTER JOIN TopNewsImage TPI ON TPI.TopNewsID = TN.TopNewsID
		LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID AND ImgD.IsActive = 1 AND ImgD.IsFirst = 1
		WHERE TN.TopNewsID = @NewsID
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectAllTopNews', 'Error from SelectAllTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--declare @date datetime =CONVERT(DATETIME, '2015-5-21' , 110)
	--declare @date1 datetime=CONVERT(DATETIME, '2015-10-21' , 110)
	--EXEC SelectTopNews @date, @date1, N'%%', 0, 0
