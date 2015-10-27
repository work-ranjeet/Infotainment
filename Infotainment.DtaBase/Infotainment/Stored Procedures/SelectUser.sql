
CREATE PROCEDURE SelectUser (@EmailID VARCHAR(100))
AS
BEGIN
	BEGIN TRY
		DECLARE @UserID BIGINT
		DECLARE @tempUserID BIGINT

		SELECT @tempUserID = UserID
		FROM UserEmail
		WHERE Email LIKE @EmailID AND IsActive = 1 AND IsVerified = 1

		IF (@tempUserID IS NULL)
		BEGIN
			SELECT @tempUserID = UserID
			FROM UserAddress
			WHERE MobileNo LIKE @EmailID AND IsPrimary = 1
		END

		SELECT @UserID = @tempUserID

		SELECT U.UserID, U.FName, U.MName, U.LName, U.Gender, U.Dob, U.Age, U.MariedSatus, U.IsActive, U.IsNew, E.EmailID, E.Email, A.AddressID, A.MobileNo, P.Password, U.DttmCreated, U.DttmModified
		FROM Users U
		LEFT OUTER JOIN UserEmail E ON U.UserID = E.UserID AND E.IsActive = 1 AND E.IsVerified = 1
		LEFT OUTER JOIN UserAddress A ON U.UserID = A.UserID
		LEFT OUTER JOIN PwdManagement P ON P.UserID = U.UserID
		WHERE U.UserID = @UserID AND U.IsActive = 1
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectUser', 'Error from SelectUser Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec SelectUser 'er.ranjeetkumar@gmail.com'
	--exec SelectUser '9535304488'
