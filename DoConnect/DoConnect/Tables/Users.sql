CREATE TABLE [dbo].[Users] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Last_Login] [datetime] NOT NULL,
	[AccessLevel] [int] NOT NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);
