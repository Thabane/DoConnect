CREATE TABLE [dbo].[Staff] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50) NOT NULL,
    [LastName]      NVARCHAR (50) NOT NULL,
    [ID_Number]     NVARCHAR (50) NOT NULL,
    [Gender]        CHAR (1)      NOT NULL,
    [DOB]           DATE          NOT NULL,
    [Phone]         NVARCHAR (50) NOT NULL,
    [Employee_Type] NVARCHAR (50) NOT NULL,
    [Practice_ID]   INT           NOT NULL,
    [User_ID]       INT           NOT NULL,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Staff_Practice] FOREIGN KEY ([Practice_ID]) REFERENCES [dbo].[Practice] ([ID]),
    CONSTRAINT [FK_Staff_Users] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[Users] ([ID])
);
