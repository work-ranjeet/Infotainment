IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateAdvertisment') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateAdvertisment
GO

CREATE PROCEDURE UpdateAdvertisment (
	@AdvertismentID NVARCHAR(50), @DisplayOrder INT, @Heading NVARCHAR(300), @WebUrl NVARCHAR(200), @WebLink NVARCHAR(1000), @ShortDesc NVARCHAR(300), @ImgUrl NVARCHAR(1000), @AdvertismentType INT, @Position INT, 
	@IsApproved INT, @IsActive INT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE Advertisment
		SET DisplayOrder = @DisplayOrder, Heading = @Heading, WebUrl = @WebUrl, WebLink = @WebLink, ShortDesc = @ShortDesc, ImgUrl = @ImgUrl, AdvertismentType = @AdvertismentType, Position = @Position, IsApproved = @IsApproved, 
			IsActive = @IsActive, DttmModified = GETDATE()
		WHERE AdvertismentID = @AdvertismentID

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'UpdateAdvertisment', 'Error from UpdateAdvertisment Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
