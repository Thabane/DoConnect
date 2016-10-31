CREATE TABLE [dbo].[Medicine_Inventory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DrugName] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[QuantityPurchased] [int] NOT NULL,
	[PurchaseDate] [nvarchar](50) NOT NULL,
	[QuantityInStock] [int] NOT NULL,
	[ExpiryDate] [nvarchar](50) NOT NULL,
	[DrugConcentration] [nvarchar](200) NOT NULL,
	[Practice_ID] [int] NOT NULL,
	[DeletedStatus] [int] NULL DEFAULT ((0)),
	CONSTRAINT [PK_Medicine_Inventory] PRIMARY KEY CLUSTERED ([ID] ASC)
);