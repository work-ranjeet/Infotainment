IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertLatestNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE InsertLatestNews
GO

CREATE PROCEDURE InsertLatestNews (
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription NVARCHAR(MAX),
	@LanguageID INT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@IsFirst INT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DECLARE @ImageID NVARCHAR(50)

		SELECT @ImageID = NEWID()

		INSERT INTO ImageDetail (
			ImageID,
			ImageType,
			ImageUrl,
			IsFirst
			)
		VALUES (
			@ImageID,
			@ImageType,
			@ImageUrl,
			@IsFirst
			)

		DECLARE @NewsID NVARCHAR(50)

		SELECT @NewsID = NEWID()

		INSERT INTO TopNews (
			TopNewsID,
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID
			)
		VALUES (
			@NewsID,
			@EditorID,
			@DisplayOrder,
			@Heading,
			@ShortDescription,
			@NewsDescription,
			@LanguageID
			)

		INSERT INTO TopNewsImage (
			TopNewsID,
			ImageID,
			IsActive
			)
		VALUES (
			@NewsID,
			@ImageID,
			1
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
