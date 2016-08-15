SET IDENTITY_INSERT [dbo].[Medicine_Inventory] ON
INSERT INTO [dbo].[Medicine_Inventory] ([ID], [DrugName], [Description], [QuantityPurchased], [PurchaseDate], [QuantityInStock], [ExpiryDate], [DrugConcentration], [Practice_ID]) VALUES (1, N'Acetaminophen', N'Acetaminophen is a pain reliever and a fever reducer.', 400, N'2016-07-27', 300, N'2016-07-27', N'1000mg', 1)
SET IDENTITY_INSERT [dbo].[Medicine_Inventory] OFF
