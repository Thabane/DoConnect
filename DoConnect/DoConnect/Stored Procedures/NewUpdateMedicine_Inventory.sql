CREATE PROCEDURE [NewUpdateMedicine_Inventory] 
	   @ID INT,
       @DrugName NVARCHAR(200),
       @Description NVARCHAR(200), 
	   @QuantityPurchased INT,
       @PurchaseDate DATE,
       @QuantityInStock INT,
       @ExpiryDate DATE,
       @DrugConcentration NVARCHAR(50),
	   @Practice_ID INT

AS
BEGIN

SET NOCOUNT ON;

	MERGE [Medicine_Inventory] AS TARGET
	USING
	(
		SELECT
			@ID,
			@DrugName,
			@Description, 
			@QuantityPurchased,
			@PurchaseDate,
			@QuantityInStock,
			@ExpiryDate,
			@DrugConcentration,
			@Practice_ID
	)
	AS
	[SOURCE]
	(
	   [ID]
      ,[DrugName]
      ,[Description]
      ,[QuantityPurchased]
      ,[PurchaseDate]
      ,[QuantityInStock]
      ,[ExpiryDate]
      ,[DrugConcentration]
      ,[Practice_ID]
	)
	ON
	[TARGET].[ID] = [SOURCE].[ID]
	WHEN MATCHED THEN
	UPDATE
	SET	   
       [DrugName] = @DrugName,
       [Description] = @Description,
       [QuantityPurchased] = @QuantityPurchased,
       [PurchaseDate] = @PurchaseDate,
       [QuantityInStock] = @QuantityInStock,
       [ExpiryDate] = @ExpiryDate,
       [DrugConcentration] = @DrugConcentration,
       [Practice_ID] = @Practice_ID
	WHEN NOT MATCHED THEN
	INSERT
	(
       [DrugName]
      ,[Description]
      ,[QuantityPurchased]
      ,[PurchaseDate]
      ,[QuantityInStock]
      ,[ExpiryDate]
      ,[DrugConcentration]
      ,[Practice_ID]
	)
	VALUES        
	(
			@DrugName,
			@Description, 
			@QuantityPurchased,
			@PurchaseDate,
			@QuantityInStock,
			@ExpiryDate,
			@DrugConcentration,
			@Practice_ID
	);

END
