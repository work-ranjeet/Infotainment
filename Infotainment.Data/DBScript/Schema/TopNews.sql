CREATE TABLE [dbo].[TopNews] (
    [TopNewsID]        NVARCHAR (50)   DEFAULT (newid()) NOT NULL,
    [EditorID]         NVARCHAR (50)   NULL,
    [DisplayOrder]     INT             NOT NULL,
    [Heading]          NVARCHAR (300)  NOT NULL,
    [ShortDescription] NVARCHAR (1000) NULL,
    [NewsDescription]  TEXT            NULL,
    [LanguageID]       INT             NULL,
    [ImageID]          NVARCHAR (50)   NULL,
    [IsApproved]       INT             DEFAULT ((0)) NULL,
    [IsActive]         INT             DEFAULT ((0)) NULL,
    [DttmCreated]      DATETIME        DEFAULT (getdate()) NULL,
    [DttmModified]     DATETIME        DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([TopNewsID] ASC)
);

