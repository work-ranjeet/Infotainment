CREATE PROCEDURE DropTableScema
AS
BEGIN
	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'ErrorLog')
				AND type IN (N'U')
			)
		DROP TABLE ErrorLog

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'Language')
				AND type IN (N'U')
			)
		DROP TABLE LANGUAGE

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'ImageType')
				AND type IN (N'U')
			)
		DROP TABLE ImageType

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'ImageDetail')
				AND type IN (N'U')
			)
		DROP TABLE ImageDetail

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'TopNews')
				AND type IN (N'U')
			)
		DROP TABLE TopNews

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'PwdManagement')
				AND type IN (N'U')
			)
		DROP TABLE PwdManagement

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserAddress')
				AND type IN (N'U')
			)
		DROP TABLE UserAddress

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserEmail')
				AND type IN (N'U')
			)
		DROP TABLE UserEmail

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserLoginDetails')
				AND type IN (N'U')
			)
		DROP TABLE UserLoginDetails

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserGroups')
				AND type IN (N'U')
			)
		DROP TABLE UserGroups

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'Groups')
				AND type IN (N'U')
			)
		DROP TABLE Groups

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'Users')
				AND type IN (N'U')
			)
		DROP TABLE Users

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'PwdManagement')
				AND type IN (N'U')
			)
		DROP TABLE PwdManagement

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserAddress')
				AND type IN (N'U')
			)
		DROP TABLE UserAddress

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserEmail')
				AND type IN (N'U')
			)
		DROP TABLE UserEmail

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserLoginDetails')
				AND type IN (N'U')
			)
		DROP TABLE UserLoginDetails

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'UserGroups')
				AND type IN (N'U')
			)
		DROP TABLE UserGroups

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'Groups')
				AND type IN (N'U')
			)
		DROP TABLE Groups

	IF EXISTS (
			SELECT *
			FROM sys.objects
			WHERE object_id = OBJECT_ID(N'Users')
				AND type IN (N'U')
			)
		DROP TABLE Users
END





