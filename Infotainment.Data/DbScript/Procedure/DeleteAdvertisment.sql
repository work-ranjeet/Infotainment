IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'DeleteAdvertisment') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE DeleteAdvertisment
GO

CREATE PROCEDURE DeleteAdvertisment (@AdvertismentID NVARCHAR(50))
AS
BEGIN
	BEGIN TRANSACTION

	BEGIN TRY
		DELETE
		FROM Advertisment
		WHERE AdvertismentID = @AdvertismentID

		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION

		INSERT INTO ErrorLog (
			ErrorType,
			ProcedureName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			'Database Error',
			'DeleteAdvertisment',
			'Error from DeleteAdvertisment Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
