CREATE TABLE [dbo].[UserLoginDetails] (
    [UserLoginDetailsID] NVARCHAR (300) DEFAULT (newid()) NOT NULL,
    [UserID]             BIGINT         NULL,
    [LoginCount]         BIGINT         DEFAULT ((0)) NULL,
    [LoginDateTime]      DATETIME       DEFAULT (getdate()) NULL,
    [LogOutDateTime]     DATETIME       DEFAULT (getdate()) NULL,
    [IsActive]           SMALLINT       DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([UserLoginDetailsID] ASC)
);

