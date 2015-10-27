CREATE TABLE [dbo].[PwdManagement] (
    [PwdID]        NVARCHAR (50)  DEFAULT (newid()) NOT NULL,
    [UserID]       BIGINT         NULL,
    [Password]     NVARCHAR (200) NOT NULL,
    [IsPwdReset]   SMALLINT       DEFAULT ((0)) NOT NULL,
    [IsNew]        SMALLINT       DEFAULT ((1)) NOT NULL,
    [DttmCreated]  DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([PwdID] ASC)
);

