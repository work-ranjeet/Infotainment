IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectUserGroup') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectUserGroup
GO

CREATE PROCEDURE SelectUserGroup (@userID BIGINT)
AS
BEGIN
	BEGIN TRY
		SELECT G.GroupID, G.GroupTYpe, G.GroupDetails, G.IsActive, G.DttmCreate, G.DttmModified
		FROM Groups G
		LEFT OUTER JOIN UserGroups UG ON UG.GroupID = G.GroupID
		WHERE UG.UserID = @userID AND G.IsActive = 1
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectUser', 'Error from SelectUser Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec SelectUserGroup 1
	GO
