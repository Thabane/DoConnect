CREATE PROCEDURE [dbo].[NewUpdateExpense] 
	   @ID INT,
       @Description NVARCHAR(50),
       @Date DATETIME,
       @Amount DECIMAL,
       @Practice_ID INT,
       @User_ID INT

AS
BEGIN

SET NOCOUNT ON;

	MERGE [Expenses] AS TARGET
	USING
	(
		SELECT
			@ID,
			@Description,
			@Date,
			@Amount,
			@Practice_ID,
			@User_ID
	)
	AS
	[SOURCE]
	(
	   [ID]
      ,[Description]
      ,[Date]
      ,[Amount]
      ,[Practice_ID]
      ,[User_ID]
	)
	ON
	[TARGET].[User_ID] = [SOURCE].[User_ID]
	WHEN MATCHED THEN
	UPDATE
	SET
	   [Description] = @Description,
       [Date] = @Date,
       [Amount] = @Amount
	WHEN NOT MATCHED THEN
	INSERT
	(
       [Description]
      ,[Date]
      ,[Amount]
      ,[Practice_ID]
      ,[User_ID]
	)
	VALUES        
	(		
		@Description,
		@Date,
		@Amount,
		@Practice_ID,
		@User_ID
	);

END
