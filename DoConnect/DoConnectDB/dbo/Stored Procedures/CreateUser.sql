CREATE PROCEDURE [CreateUser] 

AS
BEGIN

SET NOCOUNT ON;

	INSERT INTO [Users]
	(
		[Password], 
		[Last_Login]
	)
	OUTPUT
		[inserted].[ID]
	VALUES   
	(
		'p4ssworD',
		SYSDATETIME()
	)

END
