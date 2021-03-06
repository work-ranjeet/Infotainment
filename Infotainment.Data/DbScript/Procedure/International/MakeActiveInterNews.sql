IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'MakeActiveInterNews') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE MakeActiveInterNews
GO

CREATE PROCEDURE MakeActiveInterNews (
	@NewsID NVARCHAR(50),
	@IsActive INT,
	@UserID BIGINT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE InternationalNews
		SET IsActive = @IsActive
		WHERE NewsID = @NewsID

		IF (@IsActive = 1)
		BEGIN
			INSERT INTO InternationalNewsTacking (
				NewsID,
				NewsStatusID,
				UserID
				)
			VALUES (
				@NewsID,
				4,
				@UserID
				)
		END

		IF (@IsActive = 0)
		BEGIN
			INSERT INTO InternationalNewsTacking (
				NewsID,
				NewsStatusID,
				UserID
				)
			VALUES (
				@NewsID,
				8,
				@UserID
				)
		END

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (
			ErrorType,
			ErrorName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			1,
			'MakeActiveInterNews',
			'Error from MakeActiveInterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec UpdateLatestNews '2B45812B-0016-4FDE-ACBF-3FF612BDC2B6', 1, N'बबबबबब ', 'testing', 'testing testing' ,1, '18C4C1BC-44CE-41A4-AF78-903E48003868',2,1,1
GO


