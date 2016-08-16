CREATE TABLE [dbo].[Practice] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
    [Phone_Number]    NVARCHAR (50) NOT NULL,
    [Fax_Number]     NVARCHAR (50) NOT NULL,
    [Street_Address] NVARCHAR (50) NOT NULL,
    [Suburb]         NVARCHAR (50) NOT NULL,
    [City]           NVARCHAR (50) NOT NULL,
    [Country]        NVARCHAR (50) NOT NULL,
    [Latitude]       NVARCHAR (50) NOT NULL,
    [Longitude]      NVARCHAR (50) NOT NULL,
    [Trading_Times]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Practice] PRIMARY KEY CLUSTERED ([ID] ASC)
);