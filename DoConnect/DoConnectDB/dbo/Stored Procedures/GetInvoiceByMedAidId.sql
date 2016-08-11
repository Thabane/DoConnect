CREATE PROCEDURE [GetInvoiceByMedAidId] 
		@ID	INT

AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	   [ID]
      ,[Date]
	  ,[Medical_Aid_ID]
      ,[Total]
      ,[Medical_Aid_ID]
      ,[Patient_ID]
      ,[Doctor_ID]
	FROM 
	   [dbo].[Invoice]
	WHERE
	   [Medical_Aid_ID] = @ID

END
GO
