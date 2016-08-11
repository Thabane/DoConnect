CREATE PROCEDURE [GetAllInvoices] 

AS
BEGIN

	SET NOCOUNT ON;

	SELECT 
	   [ID]
      ,[Date]
	  ,[InvoiceSummary]
      ,[Total]
      ,[Medical_Aid_ID]
      ,[Patient_ID]
      ,[Doctor_ID]
	FROM 
	   [dbo].[Invoice]

END
GO
