CREATE TABLE [dbo].[Medical_Aid] (
    [ID]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50) NOT NULL,
    [Cell_Number]   NVARCHAR (50) NOT NULL,
    [Fax_Number]    NVARCHAR (50) NOT NULL,
    [Email_Address] NVARCHAR (50) NOT NULL,
    [Address]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Medical_Aid] PRIMARY KEY CLUSTERED ([ID] ASC)
);
