IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SearchNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SearchNews
GO

CREATE PROCEDURE SearchNews (@DateFrom DATETIME, @DateTo DATETIME, @Heading NVARCHAR(300))
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'TopNews'

		SELECT TopNewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, IsApproved, IsActive, DttmCreated, DttmModified
		FROM TopNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo AND Heading LIKE @Heading AND NewsType = @NewsType
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectTopNews', 'Error from SelectTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--declare @date datetime =CONVERT(DATETIME, '2015-5-21' , 110)
	--declare @date1 datetime=CONVERT(DATETIME, '2015-10-21' , 110)
	--EXEC SelectTopNews @date, @date1, N'%%', 0, 0
