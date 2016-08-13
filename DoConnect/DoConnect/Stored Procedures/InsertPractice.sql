CREATE PROCEDURE [dbo].[InsertPractice]
		@Name		   NVARCHAR (50) ,       
		@Phone_Number  NVARCHAR (50),
		@Fax_Number    NVARCHAR (50),
		@Street_Address NVARCHAR (100),
		@Suburb        NVARCHAR (50),
		@City          NVARCHAR (50),  
		@Country	   NVARCHAR (50),  
		@Latitude      NVARCHAR (50),
		@Longitude     NVARCHAR (50),
		@Trading_Times NVARCHAR (100)
AS
BEGIN
SET NOCOUNT ON;
	INSERT INTO [Practice]
	(
		[Name],			
		[Phone_Number] ,	
		[Fax_Number], 	
		[Street_Address],
		[Suburb], 		
		[City], 			
		[Country] ,		
		[Latitude] ,		
		[Longitude] ,	
		[Trading_Times] 
	)
	OUTPUT
		[inserted].[ID]
	VALUES   
	(
		@Name, 
		@Phone_Number,
		@Fax_Number,
		@Street_Address,
		@Suburb ,
		@City,
		@Country,
		@Latitude,
		@Longitude,
		@Trading_Times 
	)
END