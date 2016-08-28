CREATE PROCEDURE [GetAllPractices]

AS
BEGIN
	SELECT 
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
	FROM 
		[Practice]
END
