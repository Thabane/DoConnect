CREATE PROCEDURE [GetAllAppointments] 

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

END
GO
