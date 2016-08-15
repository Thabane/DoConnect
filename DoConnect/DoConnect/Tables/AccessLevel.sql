CREATE TABLE [dbo].[AccessLevel] (
    [ID]    INT           IDENTITY (1, 1) NOT NULL,
    [Level] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_AccessLevel] PRIMARY KEY CLUSTERED ([ID] ASC)
);

