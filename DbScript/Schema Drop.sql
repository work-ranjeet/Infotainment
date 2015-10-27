USE Infotainment
GO

----------------table Drop ----------------
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'PwdManagement')
			AND type IN (N'U')
		)
	DROP TABLE PwdManagement
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserAddress')
			AND type IN (N'U')
		)
	DROP TABLE UserAddress
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserEmail')
			AND type IN (N'U')
		)
	DROP TABLE UserEmail
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserLoginDetails')
			AND type IN (N'U')
		)
	DROP TABLE UserLoginDetails
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'UserGroups')
			AND type IN (N'U')
		)
	DROP TABLE UserGroups
GO

IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Groups')
			AND type IN (N'U')
		)
	DROP TABLE Groups
GO
IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Users')
			AND type IN (N'U')
		)
	DROP TABLE Users
GO



