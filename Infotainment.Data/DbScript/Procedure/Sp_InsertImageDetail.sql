IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertImageDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertImageDetail
GO

CREATE PROCEDURE InsertImageDetail (@ImageID NVARCHAR(50) OUTPUT, @ImageUrl NVARCHAR(500), @ImageType INT, @IsFirst INT)
AS
BEGIN
	BEGIN TRY
		--DECLARE @ImageID NVARCHAR(50)
		SELECT @ImageID = NEWID()

		INSERT INTO ImageDetail (ImageID, ImageUrl, ImageType, IsFirst)
		VALUES (@ImageID, @ImageUrl, @ImageType, @IsFirst)

		SELECT @ImageID AS 'ImageID'
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectUserViewLatestPost', 'Error from SelectUserViewLatestPost Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--Declare @ImageID  NVARCHAR(50)  exec InsertImageDetail @ImageID, '~/aervaewr', 1, 1   
GO


