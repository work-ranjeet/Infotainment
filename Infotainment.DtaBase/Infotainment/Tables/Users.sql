CREATE TABLE [dbo].[Users] (
    [UserID]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [FName]        NVARCHAR (100) NOT NULL,
    [MName]        NVARCHAR (100) NOT NULL,
    [LName]        NVARCHAR (100) NOT NULL,
    [Gender]       VARCHAR (1)    NOT NULL,
    [Dob]          DATETIME       NOT NULL,
    [Age]          INT            NULL,
    [MariedSatus]  SMALLINT       DEFAULT ((0)) NOT NULL,
    [IsActive]     SMALLINT       DEFAULT ((1)) NOT NULL,
    [IsNew]        SMALLINT       DEFAULT ((1)) NOT NULL,
    [GroupID]      INT            NOT NULL,
    [DttmCreated]  DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Groups] ([GroupID])
);

