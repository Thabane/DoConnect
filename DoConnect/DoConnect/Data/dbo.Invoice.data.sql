SET IDENTITY_INSERT [dbo].[Invoice] ON
INSERT INTO [dbo].[Invoice] ([ID], [Date], [Invoice Summary], [Total], [Medical_Aid_ID], [Patient_ID], [Doctor_ID]) VALUES (1, N'2016-02-03', N'Stomach pains', CAST(120.0000 AS Money), 1, 1, 1)
INSERT INTO [dbo].[Invoice] ([ID], [Date], [Invoice Summary], [Total], [Medical_Aid_ID], [Patient_ID], [Doctor_ID]) VALUES (2, N'2016-04-15', N'Back Pain', CAST(650.0000 AS Money), 2, 2, 2)
INSERT INTO [dbo].[Invoice] ([ID], [Date], [Invoice Summary], [Total], [Medical_Aid_ID], [Patient_ID], [Doctor_ID]) VALUES (3, N'2016-05-30', N'HIV Test', CAST(170.0000 AS Money), 3, 3, 3)
INSERT INTO [dbo].[Invoice] ([ID], [Date], [Invoice Summary], [Total], [Medical_Aid_ID], [Patient_ID], [Doctor_ID]) VALUES (4, N'2016-06-17', N'Scan', CAST(550.0000 AS Money), 4, 4, 4)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
