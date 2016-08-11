CREATE TABLE [dbo].[Invoice] (
    [ID]             INT   IDENTITY (1, 1) NOT NULL,
    [Date]           DATE  NOT NULL,
	[InvoiceSummary] nvarchar (200) NOT NULL,
    [Total]          MONEY NOT NULL,
    [Medical_Aid_ID] INT   NOT NULL,
    [Patient_ID]     INT   NOT NULL,
    [Doctor_ID]      INT   NOT NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Invoice_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Invoice_Medical_Aid] FOREIGN KEY ([Medical_Aid_ID]) REFERENCES [dbo].[Medical_Aid] ([ID]),
    CONSTRAINT [FK_Invoice_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);

