USE Infotainment
GO


----------------- InternationalNews -------------
CREATE TABLE InternationalNews (
	NewsID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	EditorID NVARCHAR(50),
	DisplayOrder INT NOT NULL,
	Heading NVARCHAR(300) NOT NULL,
	ShortDescription NVARCHAR(1000),
	NewsDescription NVARCHAR(MAX),
	LanguageID INT,
	NewsType INT,
	CountryCode NVARCHAR(100),
	IsApproved INT DEFAULT 0,
	IsActive INT DEFAULT 0,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	);
GO

CREATE TABLE InterNewsImage (
	NewsID NVARCHAR(50),
	ImageID NVARCHAR(50),
	IsActive INT DEFAULT 1
	)
GO

CREATE TABLE InternationalNewsTacking (
	TackingID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	NewsID NVARCHAR(50),
	NewsStatusID INT,
	UserID BIGINT,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO


