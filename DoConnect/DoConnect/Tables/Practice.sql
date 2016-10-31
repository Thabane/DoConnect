CREATE TABLE [dbo].[Practice] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Phone_Number] [nvarchar](50) NOT NULL,
	[Fax_Number] [nvarchar](50) NOT NULL,
	[Street_Address] [nvarchar](200) NOT NULL,
	[Suburb] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Latitude] [nvarchar](50) NOT NULL,
	[Longitude] [nvarchar](50) NOT NULL,
	[Trading_Times] [nvarchar](200) NOT NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
    CONSTRAINT [PK_Practice] PRIMARY KEY CLUSTERED ([ID] ASC)
);