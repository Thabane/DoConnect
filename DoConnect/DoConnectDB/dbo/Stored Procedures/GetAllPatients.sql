CREATE PROCEDURE [GetAllPatients] 

AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	   [ID]
      ,[FirstName]
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
  FROM 
	   [dbo].[Patient]

END
GO
