IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertStateNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE InsertStateNews
GO

CREATE PROCEDURE InsertStateNews (
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription NVARCHAR(MAX),
	@LanguageID INT,
	@StateCode NVARCHAR(50),
	@IsTopNews INT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@Caption NVARCHAR(200),
	@CaptionLink NVARCHAR(400),
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
			CaptionLink,
			ImageUrl,
			IsFirst
			)
		VALUES (
			@ImageID,
			@ImageType,
			@Caption,
			@CaptionLink,
			@ImageUrl,
			@IsFirst
			)

		DECLARE @NewsID NVARCHAR(50)

		SELECT @NewsID = NEWID()

		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		INSERT INTO StateNews (
			NewsID,
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID,
			NewsType,
			StateCode,
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
			@StateCode,
			@IsTopNews
			)

		INSERT INTO StateNewsImage (
			NewsID,
			ImageID,
			IsActive
			)
		VALUES (
			@NewsID,
			@ImageID,
			1
			)

		INSERT INTO StateNewsTacking (
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
			'InsertStateNews',
			'Error from InsertStateNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec InsertInterNews 1, N'बबबबबब ', 'testing', 'testing testing' ,1, 1,1  
