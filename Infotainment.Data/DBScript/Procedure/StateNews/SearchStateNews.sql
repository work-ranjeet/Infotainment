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
	@StateCode NVARCHAR(300) = NULL
	)
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		IF (@StateCode IS NULL)
		BEGIN
			SELECT SN.NewsID,
				SN.EditorID,
				SN.DisplayOrder,
				SN.Heading,
				SN.ShortDescription,
				SN.NewsDescription,
				SN.LanguageID,
				SN.StateCode,
				SC.StateName,
				SN.IsApproved,
				SN.IsActive,
				SN.IsTopNews,
				SN.DttmCreated,
				SN.DttmModified
			FROM StateNews SN
			LEFT OUTER JOIN StateCode SC ON SC.StateCode = SN.StateCode
			WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom
				AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
				AND SN.Heading LIKE @Heading
				AND SN.NewsType = @NewsType
				--AND SN.StateCode = @StateCode
		END
		ELSE
		BEGIN
			SELECT SN.NewsID,
				SN.EditorID,
				SN.DisplayOrder,
				SN.Heading,
				SN.ShortDescription,
				SN.NewsDescription,
				SN.LanguageID,
				SN.StateCode,
				SC.StateName,
				SN.IsApproved,
				SN.IsActive,
				SN.IsTopNews,
				SN.DttmCreated,
				SN.DttmModified
			FROM StateNews SN
			LEFT OUTER JOIN StateCode SC ON SC.StateCode = SN.StateCode
			WHERE CONVERT(VARCHAR(10), DttmCreated, 10) >= @DateFrom
				AND CONVERT(VARCHAR(10), DttmCreated, 10) <= @DateTo
				AND SN.Heading LIKE @Heading
				AND SN.NewsType = @NewsType
				AND SN.StateCode = @StateCode
		END
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
