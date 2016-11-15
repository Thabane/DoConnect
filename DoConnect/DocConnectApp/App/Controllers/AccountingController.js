app.controller("AccountingController", ["$scope", "AccountingService", "$interval", "$filter", "$ngBootbox", "$location",
    function ($scope, AccountingService, $interval, $filter, $ngBootbox, $location) {

        $scope.PageTitleAccounting = 'Accounting';
        $scope.PageTitleExpenses = 'Expenses';
        $scope.PageTitleNewExpenseEntry = 'New Expense Entry';
        $scope.PageTitleNewPatientInvoiceEntry = 'New Patient Invoice Entry';

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }
        //--#region Invoices------------------------------------------------------------------------------------------------------
        
        $scope.today = $filter('date')(new Date(), 'yyyy-MM-dd');

        $scope.GetInvoices = function () {
            AccountingService.GetAllInvoices().then(function (result) {
                $scope.Invoices = result.data;
                $scope.numOfUnPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfUnPaid;
                $scope.numOfPatiallyPaid = $scope.Invoices[$scope.Invoices.length - 1].numOfPatiallyPaid;
            });            

            AccountingService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID = result["User_ID"];
                sessionStorage.SessionData_FirstName = result["FirstName"];
                sessionStorage.SessionData_LastName = result["LastName"];
                sessionStorage.SessionData_Email = result["Email"];
                sessionStorage.SessionData_Practice_ID = result["Practice_ID"];
                sessionStorage.SessionData_AccessLevel = result["AccessLevel"];                
            });
        };
        $scope.GetInvoices();

        $scope.ViewInvoice = function (ID) {
            AccountingService.GetInvoiceByID(ID).success(function (result) {
                $scope.ID                      = result["ID"];
                $scope.Date                    = result["Date"];
                $scope.InvoiceSummary          = result["InvoiceSummary"];
                $scope.Total                   = result["Total"];
                $scope.AmountPaid              = result["AmountPaid"];                
                $scope.BalanceOwing            = result["BalanceOwing"];
                
                if (result["PaidStatus"] == 0) { $scope.PaidStatus = "Unpaid"; }//0 == Unpaid, 1 == Fully-Paid, 2 == Partially-Paid
                else if (result["PaidStatus"] == 1) { $scope.PaidStatus = "Fully-Paid"; }
                else { $scope.PaidStatus = "Partially-Paid"; }

                $scope.Medical_Aid_ID          = result["Medical_Aid_ID"];
                $scope.Patient_ID              = result["Patient_ID"];
                $scope.Patient_FirstName       = result["Patient_FirstName"];
                $scope.Patient_LastName        = result["Patient_LastName"];
                $scope.Patient_Email           = result["Patient_Email"];
                $scope.Patient_Street_Address  = result["Patient_Street_Address"];
                $scope.Patient_Suburb          = result["Patient_Suburb"];
                $scope.Patient_City            = result["Patient_City"];
                $scope.Patient_Country         = result["Patient_Country"];
                $scope.Patient_Phone_Number    = result["Patient_Country"];
                $scope.Doctor_ID               = result["Doctor_ID"];
                $scope.Doctor_FirstName        = result["Doctor_FirstName"];
                $scope.Doctor_LastName         = result["Doctor_LastName"];
                $scope.Doctor_Email            = result["Doctor_Email"];
                $scope.Practice_Name           = result["Practice_Name"];
                $scope.Practice_Street_Address = result["Practice_Street_Address"];
                $scope.Practice_Suburb         = result["Practice_Suburb"];
                $scope.Practice_City           = result["Practice_City"];
                $scope.Practice_Country        = result["Practice_Country"];
                $scope.Practice_Phone_Number   = result["Practice_Phone_Number"];
                $scope.Medical_Aid_Name        = result["Medical_Aid_Name"];
                $scope.Medical_Aid_Address     = result["Medical_Aid_Address"];
                $scope.Medical_Aid_Cell_Number = result["Medical_Aid_Cell_Number"];
            });
        };

    }]);