IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertInterNews')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertInterNews
GO

CREATE PROCEDURE InsertInterNews (
	@EditorID NVARCHAR(50), @DisplayOrder INT, @Heading NVARCHAR(300), @ShortDescription NVARCHAR(1000), 
	@NewsDescription NVARCHAR(MAX), @LanguageID INT, @CountryCode NVARCHAR(100), @ImageUrl NVARCHAR(500), 
	@ImageType INT, @IsFirst INT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DECLARE @ImageID NVARCHAR(50)

		SELECT @ImageID = NEWID()

		INSERT INTO ImageDetail (ImageID, ImageType, ImageUrl, IsFirst)
		VALUES (@ImageID, @ImageType, @ImageUrl, @IsFirst)

		DECLARE @NewsID NVARCHAR(50)

		SELECT @NewsID = NEWID()

		INSERT INTO InternationalNews (
			NewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, 
			CountryCode
			)
		VALUES (
			@NewsID, @EditorID, @DisplayOrder, @Heading, @ShortDescription, @NewsDescription, @LanguageID, 
			@CountryCode
			)

		INSERT INTO InterNewsImage (NewsID, ImageID, IsActive)
		VALUES (@NewsID, @ImageID, 1)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage
			)
		VALUES (
			'Database Error', 'InsertInterNews', 'Error from InsertInterNews Store Procedure', 
			ERROR_NUMBER(), ERROR_MESSAGE()
			)
	END CATCH
END
	--exec InsertInterNews 1, N'बबबबबब ', 'testing', 'testing testing' ,1, 1,1  
