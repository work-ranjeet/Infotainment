IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SearchStateNews')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SearchStateNews
GO

CREATE PROCEDURE SearchStateNews (
	@DateFrom DATETIME,
	@DateTo DATETIME,
	@Heading NVARCHAR(300),
	@StateCode NVARCHAR(300)
	)
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		SELECT NewsID,
			EditorID,
			DisplayOrder,
			Heading,
			ShortDescription,
			NewsDescription,
			LanguageID,
			IsApproved,
			IsActive,
			IsTopNews,
			DttmCreated,
			DttmModified
		FROM StateNews
		WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom
			AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
			AND Heading LIKE @Heading
			AND NewsType = @NewsType
			AND StateCode = @StateCode
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (
			ErrorType,
			ErrorName,
			CustomMesage,
			ErrorNumber,
			ErrorMessage
			)
		VALUES (
			1,
			'SearchStateNews',
			'Error from SearchStateNews Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
