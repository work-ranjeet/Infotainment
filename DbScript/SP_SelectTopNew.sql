IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectAllTopNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectAllTopNews
GO

CREATE PROCEDURE SelectAllTopNews (@DateFrom DATETIME, @DateTo DATETIME)
AS
BEGIN
	BEGIN TRY
		SELECT TopNewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, ImageID, IsApproved, IsActive, DttmCreated, DttmModified
		FROM TopNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectTopNews', 'Error from SelectTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec SelectAllTopNews '2015-10-20', '2015-10-20'
