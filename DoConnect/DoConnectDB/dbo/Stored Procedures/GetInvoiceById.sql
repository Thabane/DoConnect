CREATE PROCEDURE [GetInvoiceById] 
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
	   [DoConnect].[dbo].[Invoice]
	WHERE
	   [ID] = @ID

END
GO
