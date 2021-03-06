IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'MakeActiveStateNews')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE MakeActiveStateNews
GO

--@StateCode NVARCHAR(20),
CREATE PROCEDURE MakeActiveStateNews (@NewsID NVARCHAR(50), @IsActive INT, @UserID BIGINT)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE StateNews
		SET IsActive = @IsActive
		WHERE NewsID = @NewsID
			--AND StateCode = @StateCode

		IF (@IsActive = 1)
		BEGIN
			INSERT INTO StateNewsTacking (NewsID, NewsStatusID, UserID)
			VALUES (@NewsID, 4, @UserID)
		END

		IF (@IsActive = 0)
		BEGIN
			INSERT INTO StateNewsTacking (NewsID, NewsStatusID, UserID)
			VALUES (@NewsID, 8, @UserID)
		END

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'MakeActiveStateNews', 'Error from MakeActiveStateNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


