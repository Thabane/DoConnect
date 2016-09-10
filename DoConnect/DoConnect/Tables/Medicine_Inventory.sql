CREATE TABLE [dbo].[Medicine_Inventory](
	[ID] [int]			IDENTITY(1,1) NOT NULL,
	[DrugName]			NVARCHAR(200) NOT NULL,
	[Description]		NVARCHAR(200) NOT NULL,
	[QuantityPurchased] INT NOT NULL,
	[PurchaseDate]		DATE NOT NULL,
	[QuantityInStock]	INT NOT NULL,
	[ExpiryDate]		DATE NOT NULL,
	[DrugConcentration] NVARCHAR(200) NOT NULL,
	[Practice_ID]		INT NOT NULL,
	CONSTRAINT [PK_Medicine_Inventory] PRIMARY KEY CLUSTERED ([ID] ASC)
);