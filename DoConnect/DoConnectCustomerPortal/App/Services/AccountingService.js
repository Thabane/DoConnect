app.factory('AccountingService',
    ['$http',
        function ($http) {
            //Invoice Regin.
            return GetAllInvoices = function () {
                return $http.get("/api/Accounting/GetExpenses");
            }
            return { GetAllInvoices: GetAllInvoices }

            //Expenses Regin.
            return GetAllExpenses = function () {
                return $http.get("/api/Accounting/GetAllExpenses");
            }
            return { GetAllExpenses: GetAllExpenses }
        }
    ]);