CREATE TABLE [dbo].[Invoice] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[InvoiceSummary] [nvarchar](500) NOT NULL,
	[Total] [money] NOT NULL,
	[AmountPaid] [money] NOT NULL DEFAULT ((0)),
	[BalanceOwing] [money] NULL DEFAULT ((0)),
	[Medical_Aid_ID] [int] NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Doctor_ID] [int] NOT NULL,
	[PaidStatus] [int] NULL DEFAULT ((0)),
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Invoice_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Invoice_Medical_Aid] FOREIGN KEY ([Medical_Aid_ID]) REFERENCES [dbo].[Medical_Aid] ([ID]),
    CONSTRAINT [FK_Invoice_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);
