app.factory('AccountingService',
    function ($http) {
            
        var GetAllInvoices = function () {
            return $http.get("api/Accounting/GetAllInvoices");
        };            
                               
        var GetInvoiceByID = function (ID) {
            return $http.get("api/Accounting/GetInvoice/" + ID);
        };

        var GetAllPatients = function () {
            return $http.get("api/Accounting/GetAllPatients");
        }

        var GetAllDiagnosisByPatientID = function (ID) {
            return $http.get("api/Accounting/GetAllDiagnosisByPatientID/" + ID);
        }
            
        var GetAllDoctors = function () {
            return $http.get("api/Appointments/GetAllDoctors");
        }

        var InsertInvoice = function (InvoiceSummary, Total, AmountPaid, Medical_Aid_ID, Patient_ID, Doctor_ID) {
            return $http.post("api/Accounting/InsertInvoice",
            {
                'InvoiceSummary': InvoiceSummary,
                'Total': Total,
                'AmountPaid': AmountPaid,
                'Medical_Aid_ID': Medical_Aid_ID,
                'Patient_ID': Patient_ID,
                'Doctor_ID': Doctor_ID
            });
        };

        var UpdateInvoice = function (InvoiceSummary, Total, AmountPaid, Medical_Aid_ID, Patient_ID, Doctor_ID) {
            return $http.post("api/Accounting/UpdateInvoice",
            {
                'InvoiceSummary': InvoiceSummary,
                'Total': Total,
                'AmountPaid': AmountPaid,
                'Medical_Aid_ID': Medical_Aid_ID,
                'Patient_ID': Patient_ID,
                'Doctor_ID': Doctor_ID
            });
        };
            
        var DeleteInvoice = function (ID) {
            return $http.post("api/Accounting/DeleteInvoice/" + ID);
        };

        //--#region Expenses-------------------------------------------------------------------------------------------------------

        var GetAllExpenses = function () {
            return $http.get("api/Expenses/GetAllExpenses");
        };
                
        var GetAllPractices = function () {
            return $http.get("api/Practices/GetAllPractices");
        };

        var GetExpenseByID = function (ID) {
            return $http.get("api/Expenses/GetExpense/" + ID);
        };

        var GetPracticeIDByUser_ID = function (ID) {
            return $http.get("api/Expenses/GetPracticeIDByUser_ID/" + ID);
        };

        var InsertExpense = function (Description, Date, Amount, Practice_ID, User_ID) {
            return $http.post("api/Expenses/InsertExpense",
            {
                'Description': Description,
                'Date': Date,
                'Amount': Amount,
                'Practice_ID': Practice_ID,
                'User_ID': User_ID
            });
        };

        var UpdateExpense = function (ID, Description, Amount) {
            return $http.post("api/Expenses/UpdateExpense",
            {
                'ID': ID,
                'Description': Description,
                'Amount': Amount
            });
        };

        var DeleteExpense = function (ID) {
            return $http.post("api/Expenses/DeleteExpense/" + ID);
        };

        return {
            GetAllInvoices: GetAllInvoices,
            GetInvoiceByID: GetInvoiceByID,
            GetAllPatients: GetAllPatients,
            GetAllDoctors: GetAllDoctors,
            GetAllDiagnosisByPatientID: GetAllDiagnosisByPatientID,
            InsertInvoice: InsertInvoice,
            UpdateInvoice: UpdateInvoice,
            DeleteInvoice: DeleteInvoice,

            GetAllExpenses: GetAllExpenses,
            GetAllPractices: GetAllPractices,
            GetExpenseByID: GetExpenseByID,
            GetPracticeIDByUser_ID: GetPracticeIDByUser_ID,
            InsertExpense: InsertExpense,
            UpdateExpense: UpdateExpense,
            DeleteExpense: DeleteExpense
        };
    }
);