USE Infotainment
GO
------------------------------------------------Groups------------------------------------------------
CREATE TABLE Groups (
	GroupID INT NOT NULL PRIMARY KEY,
	GroupType NVARCHAR(250) NOT NULL,
	GroupDetails NVARCHAR(250),
	IsActive SMALLINT NOT NULL DEFAULT 1,
	DttmCreate DATETIME DEFAULT GETDATE(),
	DttmModified DATETIME DEFAULT GETDATE()
	)
GO

------------------------Users-----------------------
CREATE TABLE Users (
	UserID BIGINT PRIMARY KEY IDENTITY(1, 1),
	FName NVARCHAR(100) NOT NULL,
	MName NVARCHAR(100) NOT NULL,
	LName NVARCHAR(100) NOT NULL,
	Gender VARCHAR(1) NOT NULL,
	Dob DATETIME NOT NULL,
	Age INT NULL,
	MariedSatus SMALLINT NOT NULL DEFAULT 0,
	IsActive SMALLINT NOT NULL DEFAULT 1,
	IsNew SMALLINT NOT NULL DEFAULT 1,
	GroupID INT NOT NULL,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
	)
GO

------------------------------------------------UserGroups------------------------------------------------
CREATE TABLE UserGroups (
	UserID BIGINT,
	GroupID INT 
	FOREIGN KEY (UserID) REFERENCES [Users](UserID),
	FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
	)
GO
------------------------PwdManagement-----------------------
CREATE TABLE PwdManagement (
	PwdID NVARCHAR(50) PRIMARY KEY DEFAULT NEWID(),
	UserID BIGINT,
	[Password] NVARCHAR(200) NOT NULL,
	IsPwdReset SMALLINT NOT NULL DEFAULT 0,
	IsNew SMALLINT NOT NULL DEFAULT 1,
	DttmCreated DATETIME DEFAULT(getdate()),
	DttmModified DATETIME DEFAULT(getdate())
	)
GO

-----------------------UserAddress------------------
CREATE TABLE UserAddress (
	AddressID NVARCHAR(50) NOT NULL PRIMARY KEY DEFAULT NEWID(),
	UserID BIGINT,
	CareOf NVARCHAR(30),
	Address1 NVARCHAR(100),
	Address2 NVARCHAR(100),
	City NVARCHAR(20),
	[State] NVARCHAR(20),
	Country NVARCHAR(20) NOT NULL DEFAULT('Ind'),
	MobileNo NVARCHAR(10) NOT NULL,
	PhoneNo NVARCHAR(10),
	IsPrimary INT NOT NULL DEFAULT 1,
	DttmCreated DATETIME DEFAULT GETDATE(),
	DttmModified DATETIME DEFAULT GETDATE()
	FOREIGN KEY (UserID) REFERENCES [Users](UserID),
	)
GO

-----------------------UserEmail------------------
CREATE TABLE UserEmail (
	EmailID NVARCHAR(50) NOT NULL PRIMARY KEY DEFAULT NEWID(),
	UserID BIGINT,
	Email NVARCHAR(100) NOT NULL UNIQUE,
	IsActive INT DEFAULT 1,
	IsVerified INT DEFAULT 1,
	IsVerCodeSent INT DEFAULT 0,
	VerificationCode NVARCHAR(500),
	DttmCreated DATETIME DEFAULT GETDATE(),
	DttmModified DATETIME DEFAULT GETDATE()
	)
GO

-----------------------------------UserLoginDetails------------------------------------------------
CREATE TABLE UserLoginDetails (
	UserLoginDetailsID NVARCHAR(300) NOT NULL PRIMARY KEY DEFAULT NEWID(),
	UserID BIGINT,
	LoginCount BIGINT DEFAULT 0,
	LoginDateTime DATETIME DEFAULT GETDATE(),
	LogOutDateTime DATETIME DEFAULT GETDATE(),
	IsActive SMALLINT DEFAULT 0
	)
GO


