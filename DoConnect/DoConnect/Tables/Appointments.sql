CREATE TABLE [dbo].[Appointments] (
    [ID] [int] IDENTITY(1,1) NOT NULL,
	[App_Status] [int] NOT NULL,
	[Date_Time] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](50) NOT NULL,
	[Patient_ID] [int] NOT NULL,
	[Doctor_ID] [int] NOT NULL,
    [Practice_ID] INT NOT NULL, 
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Appointments_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID]),
	CONSTRAINT [FK_Appointments_Practice] FOREIGN KEY ([Practice_ID]) REFERENCES [dbo].[Practice] ([ID])
);