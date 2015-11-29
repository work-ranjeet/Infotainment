USE Infotainment
GO

INSERT INTO ErrorType (TypeID, EnumWord, Detail)
VALUES (1, 'DataBaseError', 'Error from store procedure')

-------------------------------Groups-------------------------
INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (1, 'SuperAdmin', 'Super Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (2, 'Admin', 'Admin users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (3, 'General', 'General users', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (4, 'InsertUpdate', 'Can insert and update.', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (5, 'InsertOnly', 'Can insert only.', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (6, 'UpdateOnly', 'Can update only.', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (7, 'Approver', 'Can approve.', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (8, 'Activeter', 'Can activate.', 1)

INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive)
VALUES (9, 'ActiveApprove', 'Can activate.', 1)

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

INSERT INTO PwdManagement (UserID, Password, IsPwdReset, IsNew)
VALUES (1, 'H4voJgFDZ0yZiYLOzUAcMQ==', 0, 0)

INSERT INTO UserGroups (UserID, GroupID)
VALUES (1, 1)
GO
---------------------------------
INSERT INTO Users (FName, MName, LName, Gender, Dob, Age, MariedSatus, IsActive, IsNew, GroupID)
VALUES (
	'Ravi', '', 'Singh', 'M', '1983-10-17', (
		SELECT FLOOR(DATEDIFF(day, '1983-10-17', getDate()) / 365.25)
		), 0, 1, 0, 1
	)
GO

INSERT INTO UserAddress (UserID, CareOf, Address1, Address2, City, STATE, Country, MobileNo, PhoneNo, IsPrimary)
VALUES (2, 'Shri Ram Kishor Singha', 'add1', 'Chandmari Road', 'Patna', 'Bihar', 'India', '9871213766', '0000000000', 1)
GO

INSERT INTO UserEmail (UserID, Email, IsActive, IsVerified, IsVerCodeSent, VerificationCode)
VALUES (2, 'ravianandpat@gmail.com', 1, 1, 1, '')
GO

INSERT INTO PwdManagement (UserID, Password, IsPwdReset, IsNew)
VALUES (2, 'H4voJgFDZ0yZiYLOzUAcMQ==', 0, 0)

INSERT INTO UserGroups (UserID, GroupID)
VALUES (2, 1)
GO

------------------- News Status ------------------------
INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (1, 'Entry', 'News entered')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (2, 'Update', 'News updated')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (3, 'Approved', 'News approved')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (4, 'Active', 'News activeted')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (5, 'NotApprove', 'News not approved')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (6, 'NotActive', 'News not active')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (7, 'UnApproved', 'News again un-approved')

INSERT INTO NewsStatus (NewsStatusID, EnumWord, Detail)
VALUES (8, 'UnActive', 'News again un-activated')

--------------------ImageType---------------------------
INSERT INTO ImageType (ImageType, EnumWord, ImageDesc)
VALUES (1, 'TopImage', 'Top News Image')

INSERT INTO ImageType (ImageType, EnumWord, ImageDesc)
VALUES (2, 'InterNewsImage', 'Inter News Image')

-------------------- AdvertismentType --------------------
INSERT INTO AdvertismentType (AddType, EnumWord, AddTypeDesc)
VALUES (1, 'TopNews', 'Top News Advertisment')

--------------------ImageType---------------------------
INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (1, 'TopNews', 'Top News')

INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (3, 'InternationalNews', 'International News')
