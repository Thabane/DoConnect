CREATE TABLE [dbo].[Consultation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Doctor_ID] [int] NOT NULL,
	[Date] [nvarchar](50) NOT NULL,
	[ReasonForConsultation] [nvarchar](200) NOT NULL,
	[Symptoms] [nvarchar](200) NOT NULL,
	[ClinicalFindings] [nvarchar](200) NOT NULL,
	[Diagnosis] [nvarchar](200) NOT NULL,
	[TestResultSummary] [nvarchar](200) NOT NULL,
	[TreatmentPlan] [nvarchar](200) NOT NULL,
	[Presciption_ID] [int] NULL,
	[Referral_ID] [int] NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
	CONSTRAINT [PK_Consultation] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Consultation_Patient] FOREIGN KEY([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);