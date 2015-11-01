
CREATE PROCEDURE InsertLatestNews (
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription TEXT,
	@LanguageID INT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@IsNewsImage INT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DECLARE @ImageID NVARCHAR(50)
		SELECT @ImageID = NEWID()
		INSERT INTO ImageDetail(ImageID, ImageType,ImageUrl, IsNewsImage)
		VALUES (@ImageID, @ImageType, @ImageUrl, @IsNewsImage)

		INSERT INTO TopNews (
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID,
			ImageID
			)
		VALUES (
			@EditorID,
			@DisplayOrder,
			@Heading,
			@ShortDescription,
			@NewsDescription,
			@LanguageID,
			@ImageID
			)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (
			ErrorType,
			ProcedureName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			'Database Error',
			'SelectUserViewLatestPost',
			'Error from SelectUserViewLatestPost Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec InsertLatestNews 1, N'बबबबबब ', 'testing', 'testing testing' ,1, 1,1
