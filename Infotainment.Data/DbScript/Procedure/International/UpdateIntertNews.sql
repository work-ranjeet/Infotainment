IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateIntertNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE UpdateIntertNews
GO

CREATE PROCEDURE UpdateIntertNews (
	@NewsID NVARCHAR(50),
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription NVARCHAR(MAX),
	@LanguageID INT,
	--@CountryCode NVARCHAR(100),
	@IsActive INT,
	@IsApproved INT,
	@IsTopNews INT,
	@ImageUrl NVARCHAR(500),
	@Caption NVARCHAR(100),
	@ImageType INT,
	@IsFirst INT,
	@IsActieImage INT,
	@UserID BIGINT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DECLARE @ImageID NVARCHAR(50)

		SELECT @ImageID = TNI.ImageID
		FROM InterNewsImage TNI
		LEFT JOIN ImageDetail ImgD ON ImgD.ImageID = TNI.ImageID
		WHERE ImgD.IsActive = 1 AND ImgD.IsFirst = 1 AND TNI.NewsID = @NewsID

		UPDATE ImageDetail
		SET ImageUrl = @ImageUrl,
			ImageType = @ImageType,
			IsFirst = @IsFirst,
			IsActive = @IsActieImage,
			Caption = @Caption
		WHERE ImageID = @ImageID

		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'InternationalNews'

		UPDATE InternationalNews
		SET EditorID = @EditorID,
			DisplayOrder = @DisplayOrder,
			Heading = @Heading,
			ShortDescription = @ShortDescription,
			NewsDescription = @NewsDescription,
			LanguageID = @LanguageID,
			--CountryCode = @CountryCode,
			IsActive = @IsActive,
			IsApproved = @IsApproved,
			IsTopNews = @IsTopNews
		WHERE NewsID = @NewsID AND NewsType = @NewsType

		INSERT INTO InternationalNewsTacking (
			NewsID,
			NewsStatusID,
			UserID
			)
		VALUES (
			@NewsID,
			2,
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
			'UpdateIntertNews',
			'Error from UpdateIntertNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


