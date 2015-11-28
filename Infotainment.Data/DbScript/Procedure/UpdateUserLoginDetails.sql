IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateLogOut') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE UpdateLogOut
GO

CREATE PROCEDURE UpdateLogOut (@UserID BIGINT)
AS
BEGIN
	BEGIN TRY
		DECLARE @LoginDetailsID NVARCHAR(300)

		SELECT @LoginDetailsID = UserLoginDetailsID
		FROM UserLoginDetails
		WHERE UserID = @UserID		
		ORDER BY DttmCreated DESC

		UPDATE UserLoginDetails
		SET LogOutDateTime = GETDATE()
		WHERE UserID = @UserID
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'UpdateLogOut', 'Error from UpdateLogOut Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
GO


