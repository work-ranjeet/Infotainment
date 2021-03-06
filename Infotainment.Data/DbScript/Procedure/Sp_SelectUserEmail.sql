IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectUserEmail')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectUserEmail
GO

CREATE PROCEDURE SelectUserEmail (@UserID BIGINT)
AS
BEGIN
	BEGIN TRY
		SELECT EmailID, UserID, Email, IsActive, IsVerified, IsVerCodeSent, VerificationCode, DttmCreated, DttmModified
		FROM UserEmail
		WHERE UserID = @UserID and IsActive = 1 
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectUserEmail', 'Error from SelectUserEmail Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


GO


