CREATE TABLE [dbo].[UserGroups] (
    [UserID]  BIGINT NULL,
    [GroupID] INT    NULL,
    FOREIGN KEY ([GroupID]) REFERENCES [dbo].[Groups] ([GroupID]),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

