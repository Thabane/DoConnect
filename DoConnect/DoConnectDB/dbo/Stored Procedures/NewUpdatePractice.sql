CREATE PROCEDURE [dbo].[NewUpdatePractice] 
		@ID INT,
		@Name NVARCHAR(50),
		@Phone_Number NVARCHAR(50),
		@Fax_Number NVARCHAR(50),
		@Street_Address NVARCHAR(100),
		@Suburb NVARCHAR(50),
		@City NVARCHAR(50),
		@Country NVARCHAR(50),
		@Latitude NVARCHAR(50),
		@Longitude NVARCHAR(50),
		@Trading_Times NVARCHAR(100)
AS
BEGIN

	SET NOCOUNT ON;

    MERGE [Practice] AS TARGET
	USING
	(
		SELECT
			@ID,
			@Name,
			@Phone_Number,
			@Fax_Number,
			@Street_Address,
			@Suburb,
			@City,
			@Country,
			@Latitude,
			@Longitude,
			@Trading_Times
	)
	AS
    [SOURCE]
	(
		[ID],
      	[Name],
		[Phone_Number],
      	[Fax_Number],
      	[Street_Address],
      	[Suburb],
        [City],
        [Country],
        [Latitude],
        [Longitude],
        [Trading_Times]
	)
	ON
		[TARGET].[ID] = [SOURCE].[ID]
	WHEN MATCHED THEN
	UPDATE
	SET
      	[Name] = @Name,
		[Phone_Number] = @Phone_Number,
      	[Fax_Number] = @Fax_Number,
      	[Street_Address] = @Street_Address,
      	[Suburb] = @Suburb,
        [City] = @City,
        [Country] = @Country,
        [Latitude] = @Latitude,
        [Longitude] = @Longitude,
        [Trading_Times] = @Trading_Times
	WHEN NOT MATCHED THEN
	INSERT
	(
      	[Name],
		[Phone_Number],
      	[Fax_Number],
      	[Street_Address],
      	[Suburb],
        [City],
        [Country],
        [Latitude],
        [Longitude],
        [Trading_Times]
	)
	VALUES        
	(
		@Name,
		@Phone_Number,
		@Fax_Number,
		@Street_Address,
		@Suburb,
		@City,
		@Country,
		@Latitude,
		@Longitude,
		@Trading_Times
	);

END
