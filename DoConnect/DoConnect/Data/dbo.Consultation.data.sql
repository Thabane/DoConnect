SET IDENTITY_INSERT [dbo].[Consultation] ON
INSERT INTO [dbo].[Consultation] ([ID], [Patient_ID], [Doctor_ID], [Date], [ReasonForConsultation], [Symptoms], [ClinicalFindings], [Diagnosis], [TestResultSummary], [TreatmentPlan], [Presciption_ID], [Referral_ID]) VALUES (1, 1, 1, N'2016-07-27', N'Patient has Fever and Pain', N'High temp', N'High temp', N'Cold Fever', N'lll', N'Administer medicine', 1, 1)
SET IDENTITY_INSERT [dbo].[Consultation] OFF
