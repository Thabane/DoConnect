CREATE PROCEDURE [dbo].[NewUpdateStaff] 
	   @ID INT
      ,@FirstName NVARCHAR(50)
      ,@LastName NVARCHAR(50)
      ,@ID_Number NVARCHAR(50) 
      ,@Gender CHAR(1)
      ,@DOB DATE
      ,@Phone NVARCHAR(50)
      ,@Street_Address NVARCHAR(50)
      ,@Suburb NVARCHAR(50)
      ,@City NVARCHAR(50)
      ,@Country NVARCHAR(50)
      ,@Employee_Type NVARCHAR(50)
      ,@Practice_ID INT
      ,@User_ID INT
      ,@Email NVARCHAR(50)

AS
BEGIN

SET NOCOUNT ON;

	MERGE [Staff] AS TARGET
	USING
	(
		SELECT
		   @FirstName
		  ,@LastName
		  ,@ID_Number
		  ,@Gender
		  ,@DOB
		  ,@Phone
		  ,@Street_Address
		  ,@Suburb
		  ,@City
		  ,@Country
		  ,@Employee_Type
		  ,@Practice_ID
		  ,@User_ID
		  ,@Email
	)
	AS
	[SOURCE]
	(
	   [FirstName]
      ,[LastName]
      ,[ID_Number]
      ,[Gender]
      ,[DOB]
      ,[Phone]
      ,[Street_Address]
      ,[Suburb]
      ,[City]
      ,[Country]
      ,[Employee_Type]
      ,[Practice_ID]
      ,[User_ID]
      ,[Email]
	)
	ON
	[TARGET].[User_ID] = [SOURCE].[User_ID]
	WHEN MATCHED THEN
	UPDATE
	SET
       [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[ID_Number] = @ID_Number
      ,[Gender] = @Gender
      ,[DOB] = @DOB
      ,[Phone] = @Phone
      ,[Street_Address] = @Street_Address
      ,[Suburb] = @Suburb
      ,[City] =@City
      ,[Country] = @Country
      ,[Employee_Type] = @Employee_Type
      ,[Practice_ID] = @Practice_ID
      ,[Email] = @Email
	WHEN NOT MATCHED THEN
	INSERT
	(
       [FirstName]
      ,[LastName]
      ,[ID_Number]
      ,[Gender]
      ,[DOB]
      ,[Phone]
      ,[Street_Address]
      ,[Suburb]
      ,[City]
      ,[Country]
      ,[Employee_Type]
      ,[Practice_ID]
      ,[User_ID]
      ,[Email]
	)
	VALUES        
	(
		 @FirstName
		,@LastName
		,@ID_Number
		,@Gender
		,@DOB
		,@Phone
		,@Street_Address
		,@Suburb
		,@City
		,@Country
		,@Employee_Type
		,@Practice_ID
		,@User_ID
		,@Email
	);

END
