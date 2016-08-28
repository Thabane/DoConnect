CREATE PROCEDURE [GetAllPatients]

AS
BEGIN
	SELECT 
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
	FROM 
		Patient
END
