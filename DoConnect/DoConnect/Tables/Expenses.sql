CREATE TABLE [dbo].[Expenses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[Amount] [nvarchar](200) NOT NULL,
	[Practice_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	CONSTRAINT [PK_Expenses] PRIMARY KEY CLUSTERED ([ID] ASC)
);