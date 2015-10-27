
CREATE PROCEDURE InsertImageDetail (
	@ImageID NVARCHAR(50) OUTPUT,
	@ImageUrl NVARCHAR(500),
	@ImageType INT,
	@IsNewsImage INT
	)
AS
BEGIN
	BEGIN TRY
		SELECT @ImageID = NEWID()

		INSERT INTO ImageDetail (
			ImageID,
			ImageUrl,
			ImageType,
			IsNewsImage
			)
		VALUES (
			@ImageID,
			@ImageUrl,
			@ImageType,
			@IsNewsImage
			)

		SELECT @ImageID AS 'ImageID'
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
	--Declare @ImageID  NVARCHAR(50)  exec InsertImageDetail @ImageID, '~/aervaewr', 1, 1   
