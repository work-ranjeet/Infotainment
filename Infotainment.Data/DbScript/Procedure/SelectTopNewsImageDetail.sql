IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectTopNewsImageDetail') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectTopNewsImageDetail
GO

CREATE PROCEDURE SelectTopNewsImageDetail (@NewsID VARCHAR(50))
AS
BEGIN
	BEGIN TRY
		SELECT img.ImageID, img.ImageUrl, img.ImageType, img.IsFirst, img.IsActive, img.DttmCreated, img.DttmModified
		FROM ImageDetail img
		LEFT OUTER JOIN TopNewsImage timg ON timg.ImageID = img.ImageID
		WHERE timg.TopNewsID = @NewsID
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ProcedureName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES ('Database Error', 'SelectTopNewsForUpdate', 'Error from SelectTopNewsForUpdate Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
