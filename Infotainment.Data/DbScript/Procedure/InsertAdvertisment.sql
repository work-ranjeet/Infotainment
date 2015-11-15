IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertAdvertisment') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertAdvertisment
GO

CREATE PROCEDURE InsertAdvertisment (@DisplayOrder INT, @Heading NVARCHAR(300), @WebUrl NVARCHAR(200), @ShortDesc NVARCHAR(300), @ImgUrl NVARCHAR(500), @AdvertismentType INT, @Position INT)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		INSERT INTO Advertisment (DisplayOrder, Heading, WebUrl, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified)
		VALUES (@DisplayOrder, @Heading, @WebUrl, @ShortDesc, @ImgUrl, @AdvertismentType, @Position, 0, 0, GETDATE(), GETDATE())

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectUserViewLatestPost', 'Error from SelectUserViewLatestPost Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END

