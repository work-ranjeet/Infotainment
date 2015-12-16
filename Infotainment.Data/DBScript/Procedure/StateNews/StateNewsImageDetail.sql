IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'StateNewsImageDetail') AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE StateNewsImageDetail
GO

CREATE PROCEDURE StateNewsImageDetail (@NewsID VARCHAR(50))
AS
BEGIN
	BEGIN TRY
		SELECT img.ImageID,
			img.ImageUrl,
			img.ImageType,
			img.IsFirst,
			img.IsActive,
			img.DttmCreated,
			img.DttmModified
		FROM ImageDetail img
		LEFT OUTER JOIN StateNewsImage timg ON timg.ImageID = img.ImageID
		WHERE timg.NewsID = @NewsID
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
			'StateNewsImageDetail',
			'Error from StateNewsImageDetail Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
