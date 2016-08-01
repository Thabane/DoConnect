CREATE TABLE [dbo].[Patient_Medical_Aid] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [Scheme_Name]         NVARCHAR (50) NOT NULL,
    [Membership_Number]   NVARCHAR (50) NOT NULL,
    [Status]              BIT           NOT NULL,
    [Registration_Date]   DATE          NOT NULL,
    [Deregistration_Date] DATE          NOT NULL,
    [Patient_ID]          INT           NOT NULL,
    [Medical_Aid_ID]      INT           NOT NULL,
    CONSTRAINT [PK_Patient_Medical_Aid] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Patient_Medical_Aid_Medical_Aid] FOREIGN KEY ([Medical_Aid_ID]) REFERENCES [dbo].[Medical_Aid] ([ID]),
    CONSTRAINT [FK_Patient_Medical_Aid_Patient] FOREIGN KEY ([Patient_ID]) REFERENCES [dbo].[Patient] ([ID])
);

