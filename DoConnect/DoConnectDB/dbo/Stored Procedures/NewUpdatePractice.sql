CREATE PROCEDURE [NewUpdatePractice] 
       @Name NVARCHAR(50)
	  ,@Phone_Number NVARCHAR(10)
	  ,@Fax_Number NVARCHAR(10)
	  ,@Street_Address NVARCHAR(200)
	  ,@Suburb NVARCHAR(50)
	  ,@City NVARCHAR(50)
	  ,@Country NVARCHAR(50)
	  ,@Latitude NVARCHAR(50)
	  ,@Longitude NVARCHAR(50)
	  ,@Trading_Times NVARCHAR(200)

AS
BEGIN

    MERGE [Practice] AS TARGET
	USING
	(
		SELECT
			  @Name
			 ,@Phone_Number 
			 ,@Fax_Number
			 ,@Street_Address
			 ,@Suburb
			 ,@City
			 ,@Country
			 ,@Latitude
			 ,@Longitude
			 ,@Trading_Times
	)
	AS
    [SOURCE]
	(
			 [Name]
			,[Phone_Number]
			,[Fax_Number]
			,[Street_Address]
			,[Suburb]
			,[City]
			,[Country]
			,[Latitude]
			,[Longitude]
			,[Trading_Times]
	)
	ON
		[TARGET].[Name] = [SOURCE].[Name] AND [TARGET].[Phone_Number] = [SOURCE].[Phone_Number]
	WHEN MATCHED THEN
	UPDATE
	SET
			 [Name] = @Name
			,[Phone_Number] = @Phone_Number
			,[Fax_Number] = @Fax_Number
			,[Street_Address] = @Street_Address
			,[Suburb] = @Suburb
			,[City] = @City
			,[Country] = @Country
			,[Latitude] = @Latitude
			,[Longitude] = @Longitude
			,[Trading_Times] = @Trading_Times
	WHEN NOT MATCHED THEN
	INSERT
	(
		     [Name]
			,[Phone_Number]
			,[Fax_Number]
			,[Street_Address]
			,[Suburb]
			,[City]
			,[Country]
			,[Latitude]
			,[Longitude]
			,[Trading_Times]
	)
	VALUES        
	(
			  @Name
			 ,@Phone_Number 
			 ,@Fax_Number
			 ,@Street_Address
			 ,@Suburb
			 ,@City
			 ,@Country
			 ,@Latitude
			 ,@Longitude
			 ,@Trading_Times
	);

END
