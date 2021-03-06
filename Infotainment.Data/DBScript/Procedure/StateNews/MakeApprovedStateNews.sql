IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'MakeApprovedStateNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE MakeApprovedStateNews
GO
--@StateCode NVARCHAR(20),
CREATE PROCEDURE MakeApprovedStateNews (
	@NewsID NVARCHAR(50),
	@IsApproved INT,	
	@UserID BIGINT
	)
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		UPDATE StateNews
		SET IsApproved = @IsApproved
		WHERE NewsID = @NewsID
			--AND StateCode = @StateCode

		IF (@IsApproved = 1)
		BEGIN
			INSERT INTO StateNewsTacking (
				NewsID,
				NewsStatusID,
				UserID
				)
			VALUES (
				@NewsID,
				3,
				@UserID
				)
		END

		IF (@IsApproved = 0)
		BEGIN
			INSERT INTO StateNewsTacking (
				NewsID,
				NewsStatusID,
				UserID
				)
			VALUES (
				@NewsID,
				7,
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
			'MakeApprovedStateNews',
			'Error from MakeApprovedStateNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
GO


