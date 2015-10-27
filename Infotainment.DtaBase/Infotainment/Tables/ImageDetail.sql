CREATE TABLE [dbo].[ImageDetail] (
    [ImageID]      NVARCHAR (50)  DEFAULT (newid()) NOT NULL,
    [ImageUrl]     NVARCHAR (500) NULL,
    [ImageType]    INT            NULL,
    [IsNewsImage]  INT            DEFAULT ((0)) NULL,
    [IsActive]     INT            DEFAULT ((1)) NULL,
    [DttmCreated]  DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([ImageID] ASC)
);

