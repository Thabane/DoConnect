CREATE TABLE [dbo].[Appointments] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [App_Status] BIT           NOT NULL,
    [Date_Time]  DATETIME      NOT NULL,
    [Details]    NVARCHAR (50) NOT NULL,
    [Patient_ID] INT           NOT NULL,
    [Doctor_ID]  INT           NOT NULL,
    CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Appointments_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);