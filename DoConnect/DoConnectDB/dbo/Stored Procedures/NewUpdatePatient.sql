CREATE PROCEDURE [NewUpdatePatient] 
	  @FirstName NVARCHAR(50)
	 ,@LastName NVARCHAR(50)
	 ,@ID_Number NVARCHAR(50)
	 ,@Gender NVARCHAR(50)
	 ,@DOB DATETIME
	 ,@Cell_Number NVARCHAR(50)
	 ,@Street_Address NVARCHAR(50)
	 ,@Suburb NVARCHAR(50)
	 ,@City NVARCHAR(50)
	 ,@Country NVARCHAR(50)
	 ,@Medical_Aid_ID INT
	 ,@Doctor_ID INT
	 ,@User_ID INT
	 ,@Allergies NVARCHAR(500)
	 ,@PreviousIllnesses NVARCHAR(500) 
	 ,@PreviousMedication NVARCHAR(500)
	 ,@RiskFactors NVARCHAR(500)
	 ,@SocialHistory NVARCHAR(500)
	 ,@FamilyHistory NVARCHAR(500)
	 ,@Email NVARCHAR(50)

AS
BEGIN

    MERGE [Patient] AS TARGET
	USING
	(
		SELECT
			 @FirstName
			,@LastName 
			,@ID_Number 
			,@Gender 
			,@DOB 
			,@Cell_Number 
			,@Street_Address 
			,@Suburb 
			,@City 
			,@Country 
			,@Medical_Aid_ID 
			,@Doctor_ID 
			,@User_ID 
			,@Allergies 
			,@PreviousIllnesses 
			,@PreviousMedication
			,@RiskFactors 
			,@SocialHistory 
			,@FamilyHistory 
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
			,[Cell_Number] 
			,[Street_Address] 
			,[Suburb] 
			,[City]
			,[Country] 
			,[Medical_Aid_ID] 
			,[Doctor_ID] 
			,[User_ID] 
			,[Allergies] 
			,[PreviousIllnesses] 
			,[PreviousMedication]
			,[RiskFactors] 
			,[SocialHistory] 
			,[FamilyHistory]
			,[Email] 
	)
	ON
		[TARGET].[ID_Number] = [SOURCE].[ID_Number] AND [TARGET].[Email] = [SOURCE].[Email]
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
	   ,[Medical_Aid_ID] = @Medical_Aid_ID 
	   ,[Doctor_ID] = @Doctor_ID 
	   ,[User_ID] = @User_ID
	   ,[Allergies] = @Allergies
	   ,[PreviousIllnesses] = @PreviousIllnesses
	   ,[PreviousMedication] = @PreviousMedication
	   ,[RiskFactors] = @RiskFactors
	   ,[SocialHistory] = @SocialHistory 
	   ,[FamilyHistory] = @FamilyHistory
	   ,[Email] = @Email 
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
	   ,[Allergies] 
	   ,[PreviousIllnesses] 
	   ,[PreviousMedication]
	   ,[RiskFactors] 
	   ,[SocialHistory] 
	   ,[FamilyHistory]
	   ,[Email] 
	)
	VALUES        
	(
		@FirstName
	   ,@LastName
	   ,@ID_Number 
	   ,@Gender 
	   ,@DOB 
	   ,@Cell_Number 
	   ,@Street_Address 
	   ,@Suburb 
	   ,@City
	   ,@Country 
	   ,@Medical_Aid_ID 
	   ,@Doctor_ID 
	   ,@User_ID 
	   ,@Allergies 
	   ,@PreviousIllnesses
	   ,@PreviousMedication
	   ,@RiskFactors
	   ,@SocialHistory 
	   ,@FamilyHistory
	   ,@Email
	);

END
