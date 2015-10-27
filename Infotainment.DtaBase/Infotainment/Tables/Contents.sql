CREATE TABLE [dbo].[Contents] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX)  NULL,
    [Description] NVARCHAR (MAX)  NULL,
    [Contents]    NVARCHAR (MAX)  NULL,
    [Image]       VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.Contents] PRIMARY KEY CLUSTERED ([ID] ASC)
);

