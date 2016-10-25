CREATE TABLE [dbo].[Prescription_DrugDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Prescription_ID] [int] NOT NULL,
	[DrugName] [nvarchar](200) NOT NULL,
	[Strength] [nvarchar](15) NOT NULL,
	[IntakeRoute] [nvarchar](50) NOT NULL,
	[Frequency] [nvarchar](50) NOT NULL,
	[DispenseNumber] [int] NOT NULL,
	[RefillNumber] [int] NOT NULL,
    CONSTRAINT [PK_Prescription_DrugDetails] PRIMARY KEY CLUSTERED ([ID] ASC), 
    CONSTRAINT [FK_Prescription_DrugDetails_Prescription] FOREIGN KEY([ID]) REFERENCES [dbo].[Prescription] ([ID])
);