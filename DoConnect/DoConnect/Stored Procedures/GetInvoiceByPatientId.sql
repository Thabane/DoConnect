CREATE PROCEDURE [GetInvoiceByPatientId] 
		@ID	INT

AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	   [ID]
      ,[Date]
      ,[Total]
      ,[Medical_Aid_ID]
      ,[Patient_ID]
      ,[Doctor_ID]
	FROM 
	   [Invoice]
	WHERE
	   [Patient_ID] = @ID

END
GO
