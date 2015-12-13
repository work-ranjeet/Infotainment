IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateStateNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE UpdateStateNews
GO

CREATE PROCEDURE UpdateStateNews (
	@NewsID NVARCHAR(50),
	@EditorID NVARCHAR(50),
	@DisplayOrder INT,
	@Heading NVARCHAR(300),
	@ShortDescription NVARCHAR(1000),
	@NewsDescription NVARCHAR(MAX),
	@LanguageID INT,
	@StateCode NVARCHAR(20),
	@IsActive INT,
	@IsApproved INT,
	@IsTopNews INT,
	@ImageUrl NVARCHAR(500),
	@Caption NVARCHAR(100),
	@CaptionLink NVARCHAR(200),
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
		FROM StateNewsImage TNI
		LEFT JOIN ImageDetail ImgD ON ImgD.ImageID = TNI.ImageID
		WHERE ImgD.IsActive = 1
			AND ImgD.IsFirst = 1
			AND TNI.NewsID = @NewsID

		UPDATE ImageDetail
		SET ImageUrl = @ImageUrl,
			ImageType = @ImageType,
			IsFirst = @IsFirst,
			IsActive = @IsActieImage,
			Caption = @Caption,
			CaptionLink = @CaptionLink
		WHERE ImageID = @ImageID

		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		UPDATE StateNews
		SET EditorID = @EditorID,
			DisplayOrder = @DisplayOrder,
			Heading = @Heading,
			ShortDescription = @ShortDescription,
			NewsDescription = @NewsDescription,
			LanguageID = @LanguageID,
			StateCode = @StateCode,
			IsActive = @IsActive,
			IsApproved = @IsApproved,
			IsTopNews = @IsTopNews
		WHERE NewsID = @NewsID
			AND NewsType = @NewsType
			AND StateCode = @StateCode

		INSERT INTO StateNewsTacking (
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
			'UpdateStateNews',
			'Error from UpdateStateNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


