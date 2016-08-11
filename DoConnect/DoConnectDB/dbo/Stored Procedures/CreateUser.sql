CREATE PROCEDURE [CreateUser] 
		@AccessLevel INT
AS
BEGIN

SET NOCOUNT ON;

	INSERT INTO [Users]
	(
		[Password], 
		[Last_Login],
		[AccessLevel]
	)
	OUTPUT
		[inserted].[ID]
	VALUES   
	(
		'p4ssworD',
		SYSDATETIME(),
		@AccessLevel
	)
END