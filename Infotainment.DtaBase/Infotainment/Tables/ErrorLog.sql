CREATE TABLE [dbo].[ErrorLog] (
    [ErrorLogID]    NVARCHAR (50)  DEFAULT (newid()) NOT NULL,
    [ErrorType]     NVARCHAR (200) NOT NULL,
    [ProcedureName] NVARCHAR (200) NOT NULL,
    [CustomMesage]  NVARCHAR (200) NOT NULL,
    [ErrorNumber]   NVARCHAR (MAX) NOT NULL,
    [ErrorMessage]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([ErrorLogID] ASC)
);

