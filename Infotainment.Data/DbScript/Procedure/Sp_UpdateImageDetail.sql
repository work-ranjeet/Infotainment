IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UpdateImageDetail')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE UpdateImageDetail
GO

CREATE PROCEDURE UpdateImageDetail (
	@ImageID NVARCHAR(50) OUTPUT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@IsNewsImage INT
	)
AS
BEGIN
	BEGIN TRY
		UPDATE ImageDetail
		SET ImageUrl = @ImageUrl,
			ImageType = @ImageType,
			IsNewsImage = @IsNewsImage
		WHERE ImageID = @ImageID
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
			'SelectUserViewLatestPost',
			'Error from SelectUserViewLatestPost Store Procedure',
			ERROR_NUMBER(),
			ERROR_MESSAGE()
			)
	END CATCH
END
	--exec UpdateImageDetail '02B8BF07-B64C-458B-8342-78768F87BF08' ,'saefa', 2,2
GO


