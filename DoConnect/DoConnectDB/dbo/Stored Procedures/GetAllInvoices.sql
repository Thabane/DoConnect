CREATE PROCEDURE [GetAllInvoices]

AS
BEGIN
	SELECT 
		[Date],
		[InvoiceSummary],
		[Total],
		[Medical_Aid_ID],
		[Patient_ID],
		[Doctor_ID]
	FROM 
		Invoice
END
