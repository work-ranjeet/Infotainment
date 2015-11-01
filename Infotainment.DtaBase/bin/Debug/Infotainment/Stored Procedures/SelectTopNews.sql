CREATE PROCEDURE SelectTopNews (@DateFrom DATETIME, @DateTo DATETIME, @Heading Nvarchar(300) = null, @IsApproved int = 0, @IsActive int = 0)
AS
BEGIN
	BEGIN TRY
		SELECT TopNewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, ImageID, IsApproved, IsActive, DttmCreated, DttmModified
		FROM TopNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
		AND IsApproved = @IsApproved AND IsActive = @IsActive AND Heading LIKE @Heading
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectTopNews', 'Error from SelectTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END

--declare @date datetime =CONVERT(DATETIME, '2015-5-21' , 110)
--declare @date1 datetime=CONVERT(DATETIME, '2015-10-21' , 110)
--EXEC SelectTopNews @date, @date1, N'%%', 0, 0
