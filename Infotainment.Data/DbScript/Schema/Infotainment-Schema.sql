USE Infotainment
GO

---------------------ErrorLog-------------------------
CREATE TABLE ErrorLog (
	ErrorLogID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	ErrorType NVARCHAR(200) NOT NULL,
	ProcedureName NVARCHAR(200) NOT NULL,
	CustomMesage NVARCHAR(200) NOT NULL,
	ErrorNumber NVARCHAR(MAX) NOT NULL,
	ErrorMessage NVARCHAR(MAX) NOT NULL
	)
GO
----------------- Language -------------
CREATE TABLE [Language] (
	LanguageID INT,
	LanguageDesc NVARCHAR(100)
	)
GO

----------------- ImageType -------------
CREATE TABLE ImageType (
	ImageType INT,
	ImageDesc NVARCHAR(100)
	)
GO

----------------- ImageDetail -------------
CREATE TABLE ImageDetail (
	ImageID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	ImageUrl NVARCHAR(500),
	ImageType INT,
	IsFirst INT DEFAULT 0,
	IsActive INT DEFAULT 1,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO

----------------- TopNews -------------
CREATE TABLE TopNews (
	TopNewsID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	EditorID NVARCHAR(50),
	DisplayOrder INT NOT NULL,
	Heading NVARCHAR(300) NOT NULL,
	ShortDescription NVARCHAR(1000),
	NewsDescription NVARCHAR(MAX),
	LanguageID INT,
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

