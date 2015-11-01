CREATE TABLE [dbo].[Groups] (
    [GroupID]      INT            NOT NULL,
    [GroupType]    NVARCHAR (250) NOT NULL,
    [GroupDetails] NVARCHAR (250) NULL,
    [IsActive]     SMALLINT       DEFAULT ((1)) NOT NULL,
    [DttmCreate]   DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([GroupID] ASC)
);

