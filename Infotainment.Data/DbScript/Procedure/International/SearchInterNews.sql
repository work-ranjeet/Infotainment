IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SearchInterNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SearchInterNews
GO

CREATE PROCEDURE SearchInterNews (
	@DateFrom DATETIME,
	@DateTo DATETIME,
	@Heading NVARCHAR(300)
	)
AS
BEGIN
	BEGIN TRY
		SELECT NewsID,
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID,
			CountryCode,
			IsApproved,
			IsActive,
			DttmCreated,
			DttmModified
		FROM InternationalNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom
			AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
			AND Heading LIKE @Heading
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (
			ErrorType,
			ProcedureName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			'Database Error',
			'SearchInterNews',
			'Error from SearchInterNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
