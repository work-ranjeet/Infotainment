IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'AdvertismentType') AND type IN (N'U')
		)
	DROP TABLE AdvertismentType
GO

CREATE TABLE AdvertismentType (
	AddTypeID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	AddType INT DEFAULT(1),
	AddTypeDesc NVARCHAR(300)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Position') AND type IN (N'U')
		)
	DROP TABLE Position
GO

CREATE TABLE Position (
	PositionID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	Position INT DEFAULT(1),
	PositionDesc NVARCHAR(300)
	)
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Advertisment') AND type IN (N'U')
		)
	DROP TABLE Advertisment
GO

CREATE TABLE Advertisment (
	AdvertismentID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	DisplayOrder INT NOT NULL DEFAULT(0),
	Heading NVARCHAR(300) NOT NULL,
	WebUrl NVARCHAR(200),
	ShortDesc NVARCHAR(300),
	ImgUrl NVARCHAR(1000),
	AdvertismentType INT DEFAULT(0),
	Position INT DEFAULT(0),
	IsApproved INT DEFAULT(0),
	IsActive INT DEFAULT(0),
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	);
