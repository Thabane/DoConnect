CREATE PROCEDURE [dbo].[NewUpdateAppointment] 
		@ID INT,
		@App_Status BIT,
		@Date_Time DATETIME,
		@Details NVARCHAR(50),
		@Patient_ID INT,
		@Doctor_ID INT
AS
BEGIN

	SET NOCOUNT ON;

    MERGE [Appointments] AS TARGET
	USING
	(
		SELECT
			@ID,
			@App_Status,
			@Date_Time,
			@Details,
			@Patient_ID,
			@Doctor_ID
	)
	AS
    [SOURCE]
	(
       [ID]
      ,[App_Status]
      ,[Date_Time]
      ,[Details]
      ,[Patient_ID]
      ,[Doctor_ID]
	)
	ON
		[TARGET].[ID] = [SOURCE].[ID]
	WHEN MATCHED THEN
	UPDATE
	SET
	   [App_Status] = @App_Status
      ,[Date_Time] = @Date_Time
      ,[Details] = @Details
      ,[Patient_ID] = @Patient_ID
      ,[Doctor_ID] = @Doctor_ID
	WHEN NOT MATCHED THEN
	INSERT
	(
		[App_Status],	
		[Date_Time],	
		[Details],	
		[Patient_ID],	
		[Doctor_ID]
	)
	VALUES        
	(
		@App_Status,
		@Date_Time,
		@Details,
		@Patient_ID,
		@Doctor_ID
	);

END
