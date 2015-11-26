IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateImageDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateImageDetail
GO

CREATE PROCEDURE UpdateImageDetail (@ImageID NVARCHAR(50) OUTPUT, @ImageUrl NVARCHAR(500), @ImageType INT, @IsFirst INT)
AS
BEGIN
	BEGIN TRY
		UPDATE ImageDetail
		SET ImageUrl = @ImageUrl, ImageType = @ImageType, IsFirst = @IsFirst
		WHERE ImageID = @ImageID
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectUserViewLatestPost', 'Error from SelectUserViewLatestPost Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec UpdateImageDetail '02B8BF07-B64C-458B-8342-78768F87BF08' ,'saefa', 2,2
GO


