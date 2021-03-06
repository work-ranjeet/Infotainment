IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertLatestNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertLatestNews
GO

CREATE PROCEDURE InsertLatestNews (
	@EditorID NVARCHAR(50), @DisplayOrder INT, @Heading NVARCHAR(300), @ShortDescription NVARCHAR(1000), @NewsDescription NVARCHAR(MAX), @LanguageID INT, @ImageUrl NVARCHAR(500), @ImageType INT, @Caption NVARCHAR(200)
	, @IsFirst INT, @UserID BIGINT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DECLARE @ImageID NVARCHAR(50)

		SELECT @ImageID = NEWID()

		INSERT INTO ImageDetail (ImageID, ImageType, ImageUrl, Caption, IsFirst)
		VALUES (@ImageID, @ImageType, @ImageUrl, @Caption, @IsFirst)

		DECLARE @NewsID NVARCHAR(50)
		DECLARE @NewsType INT

		SELECT @NewsID = NEWID()

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'TopNews'

		INSERT INTO TopNews (TopNewsID, EditorID, DisplayOrder, Heading, ShortDescription, NewsDescription, LanguageID, NewsType)
		VALUES (@NewsID, @EditorID, @DisplayOrder, @Heading, @ShortDescription, @NewsDescription, @LanguageID, @NewsType)

		INSERT INTO TopNewsImage (TopNewsID, ImageID, IsActive)
		VALUES (@NewsID, @ImageID, 1)

		INSERT INTO TopNewsTacking (TopNewsID, NewsStatusID, UserID)
		VALUES (@NewsID, 1, @UserID)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectUserViewLatestPost', 'Error from SelectUserViewLatestPost Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec InsertLatestNews 1, N'बबबबबब ', 'testing', 'testing testing' ,1, 1,1  
