USE Infotainment
GO

---------------------ErrorLog-------------------------
CREATE TABLE ErrorLog (
	ErrorLogID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	ErrorType INT,
	ErrorName NVARCHAR(200) NOT NULL,
	CustomMesage NVARCHAR(200) NOT NULL,
	ErrorNumber NVARCHAR(MAX) NOT NULL,
	ErrorMessage NVARCHAR(MAX) NOT NULL
	)
GO

CREATE TABLE ErrorType (
	TypeID INT,
	EnumWord nvarchar(50),
	Detail NVARCHAR(100)
	)
GO

--CREATE TABLE SocialMediaDetail (
--	SMDetailID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
--	SMKey NVARCHAR(500),
--	IsFaceBook INT
--	)
--GO
----------------- Language -------------
CREATE TABLE [Language] (
	LanguageID INT,
	LanguageDesc NVARCHAR(100)
	)
GO

CREATE TABLE NewsStatus (
	NewsStatusID INT,
	EnumWord NVARCHAR(50),
	Detail NVARCHAR(200)
	)
GO

----------------- ImageType -------------
CREATE TABLE ImageType (
	ImageType INT,
	EnumWord NVARCHAR(100),
	ImageDesc NVARCHAR(100)
	)
GO

----------------- ImageDetail -------------
CREATE TABLE ImageDetail (
	ImageID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	ImageUrl NVARCHAR(500),
	ImageType INT,
	Caption NVARCHAR(200),
	IsFirst INT DEFAULT 0,
	IsActive INT DEFAULT 1,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO

----------------- TopNews -------------
CREATE TABLE NewsType (
	NewsType INT,
	EnumWord NVARCHAR(100),
	NewsDesc NVARCHAR(100)
	)
GO

CREATE TABLE TopNews (
	TopNewsID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	EditorID NVARCHAR(50),
	DisplayOrder INT NOT NULL,
	Heading NVARCHAR(300) NOT NULL,
	ShortDescription NVARCHAR(1000),
	NewsDescription NVARCHAR(MAX),
	LanguageID INT,
	NewsType INT DEFAULT(0),
	IsApproved INT DEFAULT 0,
	IsActive INT DEFAULT 0,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	);
GO

CREATE TABLE TopNewsImage (
	TopNewsID NVARCHAR(50),
	ImageID NVARCHAR(50),
	IsActive INT DEFAULT 1
	)
GO

CREATE TABLE TopNewsTacking (
	TackingID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	TopNewsID NVARCHAR(50),
	NewsStatusID INT,
	UserID NVARCHAR(50),
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO

----------------- TopNews -------------
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
	UserID INT,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO


