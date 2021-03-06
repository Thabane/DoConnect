﻿CREATE PROCEDURE [GetPracticeById] 
		@ID INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT
		[ID],        
		[Name], 
		[Phone_Number], 
		[Fax_Number], 
		[Street_Address], 
		[Suburb], 
		[City], 
		[Country], 
		[Longitude], 
		[Latitude], 
		[Trading_Times]		
	FROM            
		[Practice]
	WHERE
		[ID] = @ID

END
GO
