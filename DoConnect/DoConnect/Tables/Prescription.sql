CREATE TABLE [dbo].[Prescription] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [Date]        DATE          NOT NULL,
    [Patient_ID]  INT           NOT NULL,
    [Doctor_ID]   INT           NOT NULL,
    CONSTRAINT [PK_Prescription] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Prescription_Doctors] FOREIGN KEY ([Doctor_ID]) REFERENCES [dbo].[Doctors] ([ID]),
    CONSTRAINT [FK_Prescription_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);