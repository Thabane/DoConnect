CREATE PROCEDURE [dbo].[NewUpdatePatient] 

	    @FirstName NVARCHAR(50),
		@LastName NVARCHAR(50),
		@ID_Number NVARCHAR(50),
		@Gender CHAR(1),
		@DOB DATE,
		@Cell_Number NVARCHAR(50),
		@Street_Address NVARCHAR(50),
		@Suburb NVARCHAR(50),
		@City NVARCHAR(50),
		@Country NVARCHAR(50),
		@Medical_Aid_ID INT,
		@Doctor_ID INT,
		@User_ID INT
AS
BEGIN

	SET NOCOUNT ON;

    MERGE [Patient] AS TARGET
	USING
	(
		SELECT
		    @FirstName,
			@LastName,
			@ID_Number,
			@Gender,
			@DOB,
			@Cell_Number,
			@Street_Address,
			@Suburb,
			@City,
			@Country,
			@Medical_Aid_ID,
			@Doctor_ID,
			@User_ID
	)
	AS
    [SOURCE]
	(
       [FirstName]
      ,[LastName]
      ,[ID_Number]
      ,[Gender]
      ,[DOB]
      ,[Cell_Number]
      ,[Street_Address]
      ,[Suburb]
      ,[City]
      ,[Country]
      ,[Medical_Aid_ID]
      ,[Doctor_ID]
      ,[User_ID]
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
      ,[Cell_Number] = @Cell_Number
      ,[Street_Address] = @Street_Address
      ,[Suburb] = @Suburb
      ,[City] = @City
      ,[Country] = @Country
	WHEN NOT MATCHED THEN
	INSERT
	(
       [FirstName]
      ,[LastName]
      ,[ID_Number]
      ,[Gender]
      ,[DOB]
      ,[Cell_Number]
      ,[Street_Address]
      ,[Suburb]
      ,[City]
      ,[Country]
      ,[Medical_Aid_ID]
      ,[Doctor_ID]
      ,[User_ID]
	)
	VALUES        
	(
		@FirstName,
		@LastName,
		@ID_Number,
		@Gender,
		@DOB,
		@Cell_Number,
		@Street_Address,
		@Suburb,
		@City,
		@Country,
		@Medical_Aid_ID,
		@Doctor_ID,
		@User_ID
	);

END
