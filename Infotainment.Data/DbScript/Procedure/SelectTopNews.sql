CREATE PROCEDURE SelectTopNews(@NewsID nvarchar(50))
AS
BEGIN
	BEGIN TRY
		SELECT TopNewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID,  IsApproved, IsActive, DttmCreated, DttmModified
		FROM TopNews where TopNewsID = @NewsID
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectAllTopNews', 'Error from SelectAllTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END

--declare @date datetime =CONVERT(DATETIME, '2015-5-21' , 110)
--declare @date1 datetime=CONVERT(DATETIME, '2015-10-21' , 110)
--EXEC SelectTopNews @date, @date1, N'%%', 0, 0
