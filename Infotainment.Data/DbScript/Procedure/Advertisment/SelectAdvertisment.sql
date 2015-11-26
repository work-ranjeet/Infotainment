IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectAdvertisment') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectAdvertisment
GO

CREATE PROCEDURE SelectAdvertisment (@AdvertismentID nvarchar(50))
AS
BEGIN
	BEGIN TRY
		
			SELECT AdvertismentID, DisplayOrder, Heading, WebUrl, WebLink, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified
			FROM Advertisment
			WHERE AdvertismentID = @AdvertismentID
		
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectAdvertisment', 'Error from SelectAdvertisment Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
