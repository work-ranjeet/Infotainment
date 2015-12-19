USE anandinfotainment
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
VALUES (2, 'EVGYDGz9wwKk1xi1rzxZ38AE17G4o6kVDDU3qD7Rsgx/fZe1z6S8RA==', 0, 0)

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

INSERT INTO ImageType (ImageType, EnumWord, ImageDesc)
VALUES (3, 'StateNewsImage', 'State News Image')

-------------------- AdvertismentType --------------------
INSERT INTO AdvertismentType (AddType, EnumWord, AddTypeDesc)
VALUES (1, 'TopNews', 'Top News Advertisment')

--------------------ImageType---------------------------
INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (1, 'TopNews', 'Top News')

INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (2, 'StateNews', 'State News')

INSERT INTO NewsType (NewsType, EnumWord, NewsDesc)
VALUES (3, 'InternationalNews', 'International News')

------------------- State Code ----------------------
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('BR','Bihar', N'बिहार', 1)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('UP','Uttar Pradesh', N'उत्तर प्रदेश', 2)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('CT','Chhattisgarh', N'छत्तीसगढ़', 3)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('MP','Madhya Pradesh', N'मध्य प्रदेश', 4)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('RJ','Rajasthan', N'राजस्थान', 5)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('HP','Himachal Pradesh', N'हिमाचल प्रदेश', 6)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('JH','Jharkhand', N'झारखण्ड', 7)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('DL','Delhi', N'देल्ही', 8)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('PB','Punjab', N'पंजाब', 9)
INSERT INTO StateCode(StateCode, StateName, StateNameHindi, DisplayOrder)VALUES('HR','Haryana', N'हरयाना', 10)

--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('AN','Andaman and Nicobar Islands','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('AP','Andhra Pradesh', N'आंध्रा प्रदेश')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('AR','Arunachal Pradesh','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('AS','Assam','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('CH','Chandigarh','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('DN','Dadra and Nagar Haveli','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('DD','Daman and Diu','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('GA','Goa','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('GJ','Gujarat','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('JK','Jammu and Kashmir','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('KA','Karnataka','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('KL','Kerala','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('LD','Lakshadweep','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('MH','Maharashtra','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('MN','Manipur','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('ML','Meghalaya','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('MZ','Mizoram','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('NL','Nagaland','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('OR','Odisha','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('PY','Puducherry','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('SK','Sikkim','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('TN','Tamil Nadu','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('TG','Telangana','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('TR','Tripura','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('UT','Uttarakhand','')
--INSERT INTO StateCode(StateCode, StateName, StateNameHindi)VALUES('WB','West Bengal','')

