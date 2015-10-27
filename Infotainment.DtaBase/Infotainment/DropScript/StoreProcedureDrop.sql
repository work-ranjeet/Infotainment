CREATE PROCEDURE DropStoreProceuder
AS
BEGIN
		IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'InsertImageDetail')
			AND type IN (
				N'P',
				N'PC'
				)
		)
	DROP PROCEDURE InsertImageDetail

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'InsertLatestNews')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE InsertLatestNews

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'SelectAllTopNews')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE SelectAllTopNews

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'SelectTopNews')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE SelectTopNews

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'SelectUser')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE SelectUser

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'SelectUserEmail')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE SelectUserEmail

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'UpdateImageDetail')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE UpdateImageDetail

		IF EXISTS (
				SELECT *
				FROM sys.objects
				WHERE object_id = OBJECT_ID(N'UpdateLatestNews')
					AND type IN (
						N'P',
						N'PC'
						)
				)
			DROP PROCEDURE UpdateLatestNews
END


