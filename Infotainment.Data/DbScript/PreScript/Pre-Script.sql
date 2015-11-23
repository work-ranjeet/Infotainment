USE Infotainment
GO

-------------------------------Groups-------------------------
INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (1, 'SuperAdmin', 'Super Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (2, 'Admin', 'Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (3, 'General', 'General users', 1)

--------------------------------Usrs ------------------------
INSERT INTO Users (FName, MName, LName, Gender, Dob, Age, MariedSatus, IsActive, IsNew, GroupID)
VALUES (
	'Ranjeet', '', 'Kumar', 'M', '1983-10-17', (
		SELECT FLOOR(DATEDIFF(day, '1983-10-17', getDate()) / 365.25)
		), 0, 1, 0, 1
	)
GO

INSERT INTO UserAddress (UserID, CareOf, Address1, Address2, City, STATE, Country, MobileNo, PhoneNo, IsPrimary)
VALUES (1, 'Shri Ram Kishor Singha', 'add1', 'add2', 'Patna', 'Bihar', 'India', '9535304488', '0000000000', 1)
GO

INSERT INTO UserEmail (UserID, Email, IsActive, IsVerified, IsVerCodeSent, VerificationCode)
VALUES (1, 'er.ranjeetkumar@gmail.com', 1, 1, 1, '')
GO

INSERT INTO Infotainment.dbo.PwdManagement (UserID, Password, IsPwdReset, IsNew)
VALUES (1, 'janeman', 0, 0)
GO

--------------------ImageType---------------------------
INSERT INTO ImageType (ImageType, EnumWord, ImageDesc)
VALUES (1, 'TopImage', 'Top News Image')

-------------------- AdvertismentType --------------------
INSERT INTO AdvertismentType (AddType, EnumWord, AddTypeDesc)
VALUES (1, 'TopNews', 'Top News Advertisment')

--------------------ImageType---------------------------
INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (1, 'TopNews', 'Top News')

INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (3, 'InternationalNews', 'International News')
