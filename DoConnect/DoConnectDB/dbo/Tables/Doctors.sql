CREATE TABLE [dbo].[Doctors] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NOT NULL,
    [Gender]      CHAR (1)      NOT NULL,
    [Address]     NVARCHAR (50) NOT NULL,
    [Practice_ID] INT           NOT NULL,
    [User_ID]     INT           NOT NULL,
    [Job_Title]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Doctors_Practice] FOREIGN KEY ([Practice_ID]) REFERENCES [dbo].[Practice] ([ID]),
    CONSTRAINT [FK_Doctors_Users] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[Users] ([ID])
);

