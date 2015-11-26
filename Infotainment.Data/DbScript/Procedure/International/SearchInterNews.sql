IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SearchInterNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SearchInterNews
GO

CREATE PROCEDURE SearchInterNews (@DateFrom DATETIME, @DateTo DATETIME, @Heading NVARCHAR(300))
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternatioanlNews'

		SELECT NewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, CountryCode, IsApproved, IsActive, DttmCreated, DttmModified
		FROM InternationalNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo AND Heading LIKE @Heading AND NewsType = @NewsType
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SearchInterNews', 'Error from SearchInterNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
