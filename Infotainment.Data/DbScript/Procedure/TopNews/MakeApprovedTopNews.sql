IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'MakeApprovedTopNews') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE MakeApprovedTopNews
GO

CREATE PROCEDURE MakeApprovedTopNews (@TopNewsID NVARCHAR(50), @IsApproved INT, @UserID BIGINT)
AS
BEGIN

	BEGIN TRY
		UPDATE TopNews
		SET IsApproved = @IsApproved
		WHERE TopNewsID = @TopNewsID

		IF (@IsApproved = 1)
		BEGIN
			INSERT INTO TopNewsTacking (TopNewsID, NewsStatusID, UserID)
			VALUES (@TopNewsID, 3, @UserID)
		END

		IF (@IsApproved = 0)
		BEGIN
			INSERT INTO TopNewsTacking (TopNewsID, NewsStatusID, UserID)
			VALUES (@TopNewsID, 7, @UserID)
		END
	END TRY

	BEGIN CATCH

		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'MakeApprovedTopNews', 'Error from MakeApprovedTopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


