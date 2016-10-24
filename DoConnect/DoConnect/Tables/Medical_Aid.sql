CREATE TABLE [dbo].[Medical_Aid] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Cell_Number] [nvarchar](50) NOT NULL,
	[Fax_Number] [nvarchar](50) NOT NULL,
	[Email_Address] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
    CONSTRAINT [PK_Medical_Aid] PRIMARY KEY CLUSTERED ([ID] ASC)
);
