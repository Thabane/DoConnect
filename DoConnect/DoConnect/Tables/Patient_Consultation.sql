CREATE TABLE [dbo].[Patient_Consultation](
	[ID]			INT NOT NULL,
	[Patient_ID]	INT NOT NULL,
	CONSTRAINT [PK_Patient_Consultation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Patient_Consultation_Consultation] FOREIGN KEY([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);