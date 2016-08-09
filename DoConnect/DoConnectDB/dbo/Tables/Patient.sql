﻿CREATE TABLE [dbo].[Patient] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (50) NOT NULL,
    [LastName]       NVARCHAR (50) NOT NULL,
    [ID_Number]      NVARCHAR (50) NOT NULL,
    [Gender]         CHAR (1)      NOT NULL,
    [DOB]            DATE          NOT NULL,
    [Cell_Number]    NVARCHAR (50) NOT NULL,
    [Street_Address] NVARCHAR (50) NOT NULL,
    [Suburb]         NVARCHAR (50) NOT NULL,
    [City]           NVARCHAR (50) NOT NULL,
    [Country]        NVARCHAR (50) NOT NULL,
    [Medical_Aid_ID] INT           NOT NULL,
    [Doctor_ID]      INT           NOT NULL,
    [User_ID]        INT           NOT NULL,
    CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Patient_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Patient_Medical_Aid] FOREIGN KEY ([Medical_Aid_ID]) REFERENCES [dbo].[Medical_Aid] ([ID]),
    CONSTRAINT [FK_Patient_Users] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[Users] ([ID])
);

