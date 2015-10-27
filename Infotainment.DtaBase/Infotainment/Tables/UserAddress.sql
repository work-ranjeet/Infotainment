CREATE TABLE [dbo].[UserAddress] (
    [AddressID]    NVARCHAR (50)  DEFAULT (newid()) NOT NULL,
    [UserID]       BIGINT         NULL,
    [CareOf]       NVARCHAR (30)  NULL,
    [Address1]     NVARCHAR (100) NULL,
    [Address2]     NVARCHAR (100) NULL,
    [City]         NVARCHAR (20)  NULL,
    [State]        NVARCHAR (20)  NULL,
    [Country]      NVARCHAR (20)  DEFAULT ('Ind') NOT NULL,
    [MobileNo]     NVARCHAR (10)  NOT NULL,
    [PhoneNo]      NVARCHAR (10)  NULL,
    [IsPrimary]    INT            DEFAULT ((1)) NOT NULL,
    [DttmCreated]  DATETIME       DEFAULT (getdate()) NULL,
    [DttmModified] DATETIME       DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([AddressID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

