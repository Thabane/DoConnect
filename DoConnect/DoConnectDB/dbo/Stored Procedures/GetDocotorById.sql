CREATE PROCEDURE [GetDocotorById] 
		@UserId INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT        
		[FirstName], 
		[LastName], 
		[Gender], 
		[ID], 
		[Address], 
		[Practice_ID], 
		[User_ID], 
		[Job_Title]
	FROM            
		[Doctors]
	WHERE
		[User_ID] = @UserId	

END
GO
