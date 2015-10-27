CREATE TABLE [dbo].[UserEmail] (
    [EmailID]          NVARCHAR (50)  DEFAULT (newid()) NOT NULL,
    [UserID]           BIGINT         NULL,
    [Email]            NVARCHAR (100) NOT NULL,
    [IsActive]         INT            DEFAULT ((1)) NULL,
    [IsVerified]       INT            DEFAULT ((1)) NULL,
    [IsVerCodeSent]    INT            DEFAULT ((0)) NULL,
    [VerificationCode] NVARCHAR (500) NULL,
    [DttmCreated]      DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified]     DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([EmailID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

