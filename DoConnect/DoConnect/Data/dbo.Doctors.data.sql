SET IDENTITY_INSERT [dbo].[Doctors] ON
INSERT INTO [dbo].[Doctors] ([ID], [FirstName], [LastName], [Email], [Gender], [Address], [Practice_ID], [User_ID], [Job_Title]) VALUES (1, N'Ana', N'Cruz', N'anacruz@gmail.com', N'F', N'40 Moncgique Complex, Stonehaven Road, Paulshof', 1, 1, N'General Practitioner')
INSERT INTO [dbo].[Doctors] ([ID], [FirstName], [LastName], [Email], [Gender], [Address], [Practice_ID], [User_ID], [Job_Title]) VALUES (2, N'Dr', N' Mbuyamba', N'mbuyamba@gmail.com', N'M', N'13th Floor Marble Towers, Von Wielligh St', 2, 2, N'General Practitioner')
INSERT INTO [dbo].[Doctors] ([ID], [FirstName], [LastName], [Email], [Gender], [Address], [Practice_ID], [User_ID], [Job_Title]) VALUES (3, N'Dipna', N'Mopapau', N'Dipna@gmail.com', N'F', N'Marlin Ave, Lenasia, Johannesburg, 1821', 3, 3, N'Physio Therapist')
INSERT INTO [dbo].[Doctors] ([ID], [FirstName], [LastName], [Email], [Gender], [Address], [Practice_ID], [User_ID], [Job_Title]) VALUES (4, N'Sammy', N'Mohadeo', N'Mohadeo@gmail.com', N'M', N'7 Hummingbird Complex, Lenasia', 4, 4, N'Oncologist')
SET IDENTITY_INSERT [dbo].[Doctors] OFF
