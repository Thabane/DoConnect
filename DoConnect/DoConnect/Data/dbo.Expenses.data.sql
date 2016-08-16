SET IDENTITY_INSERT [dbo].[Expenses] ON
INSERT INTO [dbo].[Expenses] ([ID], [Description], [Date], [Amount], [Practice_ID], [User_ID]) VALUES (1, N'Bought office lights', N'2016-07-27', N'200', 1, N'jc@yahoo.com')
SET IDENTITY_INSERT [dbo].[Expenses] OFF
