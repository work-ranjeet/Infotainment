IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectStateNewsForApi')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE SelectStateNewsForApi
GO

CREATE PROCEDURE SelectStateNewsForApi
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsCount INT = 1
		DECLARE @StateNews TABLE (
			NewsID NVARCHAR(50),
			EditorID NVARCHAR(50),
			DisplayOrder INT NOT NULL,
			Heading NVARCHAR(300) NOT NULL,
			ShortDescription NVARCHAR(1000),
			NewsDescription NVARCHAR(MAX),
			LanguageID INT,
			StateCode NVARCHAR(20),
			StateName NVARCHAR(200),
			IsApproved INT DEFAULT 0,
			IsActive INT DEFAULT 0,
			IsTopNews INT DEFAULT 0,
			DttmCreated DATETIME DEFAULT(getdate()),
			DttmModified DATETIME DEFAULT(getdate()),
			ImageUrl NVARCHAR(500),
			Caption NVARCHAR(200),
			CaptionLink NVARCHAR(400)
			)
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'StateNews'

		DECLARE @Cursor_StateCode NVARCHAR(200)

		DECLARE StateCode_Cursor CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY
		FOR
		SELECT DISTINCT StateCode
		FROM StateCode

		OPEN StateCode_Cursor

		FETCH NEXT
		FROM StateCode_Cursor
		INTO @Cursor_StateCode

		WHILE @@FETCH_STATUS = 0
		BEGIN
			--Do something with Id here
			PRINT @Cursor_StateCode

			IF @Cursor_StateCode IS NOT NULL
			BEGIN
				INSERT INTO @StateNews
				SELECT TOP (
						SELECT @NewsCount
						) TN.NewsID,
					TN.EditorID,
					TN.DisplayOrder,
					TN.Heading,
					TN.ShortDescription,
					TN.NewsDescription,
					TN.LanguageID,
					TN.StateCode,
					SC.StateNameHindi,
					TN.IsApproved,
					TN.IsActive,
					TN.IsTopNews,
					TN.DttmCreated,
					TN.DttmModified,
					ImgD.ImageUrl,
					ImgD.Caption,
					ImgD.CaptionLink
				FROM StateNews TN
				LEFT OUTER JOIN StateNewsImage TPI ON TPI.NewsID = TN.NewsID
				LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
				LEFT OUTER JOIN StateCode SC ON SC.StateCode = TN.StateCode
					AND ImgD.IsActive = 1
					AND ImgD.IsFirst = 1
				WHERE TN.IsActive = 1
					AND TN.IsApproved = 1
					AND TN.NewsType = @NewsType
					AND TN.StateCode = (
						SELECT RTRIM((
									SELECT LTRIM(@Cursor_StateCode)
									))
						)
				ORDER BY TN.DttmCreated DESC
			END

			FETCH NEXT
			FROM StateCode_Cursor
			INTO @Cursor_StateCode
		END

		CLOSE StateCode_Cursor

		DEALLOCATE StateCode_Cursor

		SELECT *
		FROM @StateNews
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
			'SelectStateNewsForApi',
			'Error from SelectStateNewsForApi Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec SelectStateNewsForApi
