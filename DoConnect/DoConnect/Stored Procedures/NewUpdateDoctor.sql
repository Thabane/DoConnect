CREATE PROCEDURE [NewUpdateDoctor] 
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Gender CHAR(1),
	@Address NVARCHAR(50),
	@PracticeID INT,
	@UserID INT,
	@JobTitle NVARCHAR(50)

AS
BEGIN

SET NOCOUNT ON;

	MERGE [Doctors] AS TARGET
	USING
	(
		SELECT
			@FirstName,
			@LastName,
			@Gender,
			@Address,
			@PracticeID,
			@UserID,
			@JobTitle
	)
	AS
	[SOURCE]
	(
		[FirstName], 
		[LastName], 
		[Gender], 
		[Address], 
		[Practice_ID], 
		[User_ID], 
		[Job_Title]
	)
	ON
	[TARGET].[User_ID] = [SOURCE].[User_ID]
	WHEN MATCHED THEN
	UPDATE
	SET
		[FirstName] = @FirstName, 
		[LastName] = @LastName, 
		[Gender] = @Gender, 
		[Address] = @Address, 
		[Practice_ID] = @PracticeID, 
		[User_ID] = @UserID, 
		[Job_Title] = @JobTitle
	WHEN NOT MATCHED THEN
	INSERT
	(
		[FirstName], 
		[LastName], 
		[Gender], 
		[Address], 
		[Practice_ID], 
		[User_ID], 
		[Job_Title]
	)
	VALUES        
	(
		@FirstName,
		@LastName,
		@Gender,
		@Address,
		@PracticeID,
		@UserID,
		@JobTitle
	);

END
