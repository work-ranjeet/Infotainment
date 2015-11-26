IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'SelectAllAdvertisment') AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE SelectAllAdvertisment
GO

CREATE PROCEDURE SelectAllAdvertisment (@AddType INT, @IsActive INT = - 1, @IsApproved INT = - 1)
AS
BEGIN
	BEGIN TRY
		IF (@IsActive = - 1 AND @IsApproved = - 1)
		BEGIN
			SELECT AdvertismentID, DisplayOrder, Heading, WebUrl, WebLink, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified
			FROM Advertisment
			WHERE AdvertismentType = @AddType
		END

		IF (@IsActive = - 1 AND @IsApproved <> - 1)
		BEGIN
			SELECT AdvertismentID, DisplayOrder, Heading, WebUrl, WebLink, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified
			FROM Advertisment
			WHERE AdvertismentType = @AddType AND IsApproved = @IsApproved
		END

		IF (@IsActive <> - 1 AND @IsApproved = - 1)
		BEGIN
			SELECT AdvertismentID, DisplayOrder, Heading, WebUrl, WebLink, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified
			FROM Advertisment
			WHERE AdvertismentType = @AddType AND IsActive = @IsActive
		END

		IF (@IsActive <> - 1 AND @IsApproved <> - 1)
		BEGIN
			SELECT AdvertismentID, DisplayOrder, Heading, WebUrl, WebLink, ShortDesc, ImgUrl, AdvertismentType, Position, IsApproved, IsActive, DttmCreated, DttmModified
			FROM Advertisment
			WHERE AdvertismentType = @AddType AND IsActive = @IsActive AND IsApproved = @IsApproved
		END
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'SelectAdvertisment', 'Error from SelectAdvertisment Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
