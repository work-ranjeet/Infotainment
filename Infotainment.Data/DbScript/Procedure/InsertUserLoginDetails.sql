IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertUserLoginDetails') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE InsertUserLoginDetails
GO

CREATE PROCEDURE InsertUserLoginDetails (@UserID BIGINT)
AS
BEGIN
	BEGIN TRY
		INSERT INTO UserLoginDetails (UserID, LoginCount, LoginDateTime, LogOutDateTime, IsActive)
		VALUES (@UserID, 0, GETDATE(), NULL, 1)
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'InsertUserLoginDetails', 'Error from InsertUserLoginDetails Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	
GO


