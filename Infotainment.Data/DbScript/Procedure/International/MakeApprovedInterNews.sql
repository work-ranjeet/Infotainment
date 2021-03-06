IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'MakeApprovedInterNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE MakeApprovedInterNews
GO

CREATE PROCEDURE MakeApprovedInterNews (@NewsID NVARCHAR(50), @IsApproved INT, @UserID BIGINT)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE InternationalNews
		SET IsApproved = @IsApproved
		WHERE NewsID = @NewsID

		IF (@IsApproved = 1)
		BEGIN
			INSERT INTO InternationalNewsTacking (TopNewsID, NewsStatusID, UserID)
			VALUES (@NewsID, 3, @UserID)
		END

		IF (@IsApproved = 0)
		BEGIN
			INSERT INTO InternationalNewsTacking (NewsID, NewsStatusID, UserID)
			VALUES (@NewsID, 7, @UserID)
		END

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'MakeApprovedInterNews', 'Error from MakeApprovedInterNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	GO


