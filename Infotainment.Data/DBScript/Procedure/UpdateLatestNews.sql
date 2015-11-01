
CREATE PROCEDURE UpdateLatestNews (
	@TopNewsID NVARCHAR(50),
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription TEXT,
	@LanguageID INT,
	@ImageID NVARCHAR(50),
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@IsNewsImage INT,
	@IsActive INT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE ImageDetail
		SET ImageUrl = @ImageUrl,
			ImageType = @ImageType,
			IsNewsImage = @IsNewsImage
		WHERE ImageID = @ImageID

		UPDATE TopNews
		SET EditorID = @EditorID,
			DisplayOrder = @DisplayOrder,
			Heading = @Heading,
			ShortDescription = @ShortDescription,
			NewsDescription = @NewsDescription,
			LanguageID = @LanguageID,
			ImageID = @ImageID
		WHERE TopNewsID = @TopNewsID

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
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
