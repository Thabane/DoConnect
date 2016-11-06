CREATE TABLE [dbo].[Patient_Medical_Aid] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[Scheme_Name] [nvarchar](50) NOT NULL,
	[Membership_Number] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Registration_Date] [nvarchar](50) NOT NULL,
	[Deregistration_Date] [nvarchar](50) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Medical_Aid_ID] [int] NOT NULL,
    CONSTRAINT [PK_Patient_Medical_Aid] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Patient_Medical_Aid_Medical_Aid] FOREIGN KEY ([Medical_Aid_ID]) REFERENCES [dbo].[Medical_Aid] ([ID]),
    CONSTRAINT [FK_Patient_Medical_Aid_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);
