CREATE TABLE [dbo].[Users] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Password]   NVARCHAR (50) NOT NULL,
    [Last_Login] DATETIME      NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

