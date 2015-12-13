USE anandinfotainment
GO

DROP TABLE StateCode
GO

DROP TABLE StateNews
GO

DROP TABLE StateNewsImage
GO

DROP TABLE StateNewsTacking
GO

----------------- InternationalNews -------------
CREATE TABLE StateCode (
	StateID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	StateCode NVARCHAR(20),
	StateName NVARCHAR(100),
	StateNameHindi NVARCHAR(100)
	)
GO

CREATE TABLE StateNews (
	NewsID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	EditorID NVARCHAR(50),
	DisplayOrder INT NOT NULL,
	Heading NVARCHAR(300) NOT NULL,
	ShortDescription NVARCHAR(1000),
	NewsDescription NVARCHAR(MAX),
	LanguageID INT,
	NewsType INT,
	StateCode NVARCHAR(20),
	IsApproved INT DEFAULT 0,
	IsActive INT DEFAULT 0,
	IsTopNews INT DEFAULT 0,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	);
GO

CREATE TABLE StateNewsImage (
	NewsID NVARCHAR(50),
	ImageID NVARCHAR(50),
	IsActive INT DEFAULT 1
	)
GO

CREATE TABLE StateNewsTacking (
	TackingID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	NewsID NVARCHAR(50),
	NewsStatusID INT,
	UserID BIGINT,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO


