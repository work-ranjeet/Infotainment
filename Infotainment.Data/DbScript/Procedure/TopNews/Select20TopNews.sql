IF EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'Select20TopNews')
			AND type IN (N'P', N'PC')
		)
	DROP PROCEDURE Select20TopNews
GO

CREATE PROCEDURE Select20TopNews
AS
BEGIN
	BEGIN TRY
		DECLARE @NewsType INT

		SELECT @NewsType = NewsType
		FROM NewsTYpe
		WHERE EnumWord LIKE 'TopNews'

		SELECT TOP 20 *
		FROM (
			SELECT TOP 20 TN.TopNewsID, TN.EditorID, TN.DisplayOrder, TN.Heading, TN.ShortDescription, TN.NewsDescription, TN.LanguageID, TN.IsApproved, TN.IsActive, TN.DttmCreated, TN.DttmModified, ImgD.ImageUrl, Imgd.Caption
			FROM TopNews TN
			LEFT OUTER JOIN TopNewsImage TPI ON TPI.TopNewsID = TN.TopNewsID
			LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
				AND ImgD.IsActive = 1
				AND ImgD.IsFirst = 1
			WHERE TN.IsActive = 1
				AND TN.IsApproved = 1
				AND TN.NewsType = @NewsType
			--ORDER BY TN.DttmCreated DESC
			
			UNION
			
			SELECT TOP 20 TN.NewsID AS TopNewsID, TN.EditorID, TN.DisplayOrder, TN.Heading, TN.ShortDescription, TN.NewsDescription, TN.LanguageID,
				--TN.CountryCode,
				TN.IsApproved, TN.IsActive, TN.DttmCreated, TN.DttmModified, ImgD.ImageUrl, ImgD.Caption
			FROM InternationalNews TN
			LEFT OUTER JOIN InterNewsImage TPI ON TPI.NewsID = TN.NewsID
			LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
				AND ImgD.IsActive = 1
				AND ImgD.IsFirst = 1
			WHERE TN.IsActive = 1
				AND TN.IsApproved = 1
				AND TN.IsTopNews = 1
				AND TN.NewsType = (
					SELECT NewsType
					FROM NewsTYpe
					WHERE EnumWord LIKE 'InternationalNews'
					)
			
			UNION
			
			SELECT TOP 20 TN.NewsID AS TopNewsID, TN.EditorID, TN.DisplayOrder, TN.Heading, TN.ShortDescription, TN.NewsDescription, TN.LanguageID,
				--TN.StateCode,
				--SC.StateNameHindi,
				TN.IsApproved, TN.IsActive, TN.DttmCreated, TN.DttmModified, ImgD.ImageUrl, ImgD.Caption
			FROM StateNews TN
			LEFT OUTER JOIN StateNewsImage TPI ON TPI.NewsID = TN.NewsID
			LEFT OUTER JOIN ImageDetail ImgD ON ImgD.ImageID = TPI.ImageID
			LEFT OUTER JOIN StateCode SC ON SC.StateCode = TN.StateCode
				AND ImgD.IsActive = 1
				AND ImgD.IsFirst = 1
			WHERE TN.IsActive = 1
				AND TN.IsApproved = 1
				AND tn.IsTopNews = 1
				AND TN.NewsType = (
					SELECT NewsType
					FROM NewsTYpe
					WHERE EnumWord LIKE 'StateNews'
					)
			) AS tempTable ORDER BY DttmCreated DESC
	END TRY

	BEGIN CATCH
		INSERT INTO ErrorLog (ErrorType, ErrorName, CustomMesage, ErrorNumber, ErrorMessage)
		VALUES (1, 'Select20TopNews', 'Error from Select20TopNews Store Procedure', ERROR_NUMBER(), ERROR_MESSAGE())
	END CATCH
END
	--EXEC Select20TopNews
