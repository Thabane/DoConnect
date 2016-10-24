CREATE TABLE [dbo].[Doctors] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[Practice_ID] [int] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Job_Title] [nvarchar](50) NOT NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
    CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Doctors_Practice] FOREIGN KEY ([Practice_ID]) REFERENCES [dbo].[Practice] ([ID]),
    CONSTRAINT [FK_Doctors_Users] FOREIGN KEY ([User_ID]) REFERENCES [dbo].[Users] ([ID])
);