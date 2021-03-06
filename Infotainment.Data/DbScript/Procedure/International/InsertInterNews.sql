IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertInterNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE InsertInterNews
GO

CREATE PROCEDURE InsertInterNews (
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription NVARCHAR(MAX),
	@LanguageID INT,
	@CountryCode NVARCHAR(50),
	@IsTopNews INT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@Caption NVARCHAR(200),
	@IsFirst INT,
	@UserID BIGINT
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
			Caption,
			ImageUrl,
			IsFirst
			)
		VALUES (
			@ImageID,
			@ImageType,
			@Caption,
			@ImageUrl,
			@IsFirst
			)

		DECLARE @NewsID NVARCHAR(50)

		SELECT @NewsID = NEWID()

		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternationalNews'

		INSERT INTO InternationalNews (
			NewsID,
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID,
			NewsType,
			CountryCode,
			IsTopNews
			)
		VALUES (
			@NewsID,
			@EditorID,
			@DisplayOrder,
			@Heading,
			@ShortDescription,
			@NewsDescription,
			@LanguageID,
			@NewsType,
			@CountryCode,
			@IsTopNews
			)

		INSERT INTO InterNewsImage (
			NewsID,
			ImageID,
			IsActive
			)
		VALUES (
			@NewsID,
			@ImageID,
			1
			)

		INSERT INTO InternationalNewsTacking (
			NewsID,
			NewsStatusID,
			UserID
			)
		VALUES (
			@NewsID,
			1,
			@UserID
			)

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (
			ErrorType,
			ErrorName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			1,
			'InsertInterNews',
			'Error from InsertInterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec InsertInterNews 1, N'बबबबबब ', 'testing', 'testing testing' ,1, 1,1  
