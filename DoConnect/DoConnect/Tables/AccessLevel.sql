CREATE TABLE [dbo].[AccessLevel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED ([ID] ASC)
);
