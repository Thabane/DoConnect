CREATE PROCEDURE [GetAppointmentById] 
		@AppId INT
AS
BEGIN

	SET NOCOUNT ON;

	SELECT        
		[ID], 
		[App_Status], 
		[Date_Time], 
		[Details], 
		[Patient_ID], 
		[Doctor_ID]
	FROM            
		[Appointments]
	WHERE
		[ID] = @AppId

END
GO
