CREATE TABLE [dbo].[Messages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sender] [int] NOT NULL,
	[Receiver] [int] NOT NULL,
	[Subject] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[ReadStatus] [int] NULL DEFAULT ((0)),
	CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([ID] ASC)
 );