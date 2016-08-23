CREATE TABLE [dbo].[Consultation](
	[ID]					INT IDENTITY(1,1) NOT NULL,
	[Patient_ID]			INT NOT NULL,
	[Doctor_ID]				INT NOT NULL,
	[Date]					DATE NOT NULL,
	[ReasonForConsultation] NVARCHAR (200) NOT NULL,
	[Symptoms]				NVARCHAR(200) NOT NULL,
	[ClinicalFindings]		NVARCHAR(200) NOT NULL,
	[Diagnosis]				NVARCHAR(200) NOT NULL,
	[TestResultSummary]	    NVARCHAR(200) NOT NULL,
	[TreatmentPlan]			NVARCHAR(200) NOT NULL,
	[Presciption_ID]		INT NULL,
	[Referral_ID]			INT NULL,
	CONSTRAINT [PK_Consultation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Consultation_Patient] FOREIGN KEY([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);