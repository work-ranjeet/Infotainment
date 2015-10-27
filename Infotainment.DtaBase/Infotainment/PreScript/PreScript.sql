CREATE PROCEDURE iNSERTpREsCRIPT
AS
BEGIN
------------------------ Groups -------------------------------
	INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive) VALUES (1, 'SuperAdmin', 'Super Admin users', 1)
	INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive) VALUES (2, 'Admin', 'Admin users', 1)
	INSERT INTO Groups (GroupID, GroupType, GroupDetails, IsActive) VALUES (3, 'General', 'General users', 1)

	----------------------------- Imae Type-----------------------------------
	insert into ImageType(ImageType, ImageDesc) values(1, 'Top News Image')


	--------------------------------------Users ----------------------------------
	INSERT INTO Users (FName, MName, LName, Gender, Dob, Age, MariedSatus, IsActive, IsNew, GroupID) 
	VALUES ('Ranjeet', '', 'Kumar', 'M', '1983-10-17', (select FLOOR(DATEDIFF(day, '1983-10-17', getDate()) / 365.25)), 0, 1, 0, 1)

	DECLARE @userid BIGINT
	SELECT @userid = @@IDENTITY

	INSERT INTO PwdManagement (UserID, Password, IsPwdReset, IsNew) VALUES (@userid, 'janeman', 0, 0)

	INSERT INTO UserAddress (UserID, CareOf, Address1, Address2, City, STATE, Country, MobileNo,  IsPrimary)
	VALUES (@userid, 'Sri Ram Kishor Sinha', 'Near Maranchi Bahwan', 'Chandmari Road', 'Patna','Bihar','India', '9535304488',1 )

	INSERT INTO UserEmail (UserID, Email, IsActive, IsVerified, IsVerCodeSent, VerificationCode) VALUES (@userid, 'work..ranjeet@gmail.com', 1, 1, 0, '')


	--select * from Users
	--select * from PwdManagement
	--select * from UserAddress
	--select * from UserEmail


	--delete from PwdManagement 
	--delete from UserAddress  
	--delete from UserAddress 
	--delete from UserEmail 
	--delete from Users

END