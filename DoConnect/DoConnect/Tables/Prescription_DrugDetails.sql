CREATE TABLE [dbo].[Prescription_DrugDetails](
	[ID] INT IDENTITY(1,1) NOT NULL,
	[Prescription_ID] INT NOT NULL,
	[DrugName] NVARCHAR(200) NOT NULL,
	[Strength] NVARCHAR(15) NOT NULL,
	[IntakeRoute] NVARCHAR(50) NOT NULL,
	[Frequency] NVARCHAR(50) NOT NULL,
	[DispenseNumber] INT NOT NULL,
	[RefillNumber] INT NOT NULL,
    CONSTRAINT [PK_Prescription_DrugDetails] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Prescription_DrugDetails_Prescription] FOREIGN KEY([ID]) REFERENCES [dbo].[Prescription] ([ID])
);