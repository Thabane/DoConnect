CREATE TABLE [dbo].[Prescription] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Doctor_ID] [int] NOT NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Prescription_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Prescription_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);