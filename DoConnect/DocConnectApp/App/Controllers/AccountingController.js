app.controller("AccountingController", ["$scope", "AccountingService", "$interval",
    function ($scope, AccountingService, $interval) {

        $scope.PageTitleAccounting = 'Accounting';
        $scope.PageTitleExpenses = 'Expenses';
        $scope.PageTitleNewExpenseEntry = 'New Expense Entry';
        $scope.PageTitleNewPatientInvoiceEntry = 'New Patient Invoice Entry';

        $scope.strSort;
        $scope.limitTo = 5;
        $scope.setlimitTo = function (limit) {
            $scope.limitTo = limit;
        }
        $scope.getlimitTo = function () {
            return $scope.limitTo;
        }
        $scope.setSortKey = function (key) {
            $scope.strSort = key;
        }
        $scope.getSortKey = function () {
            return $scope.strSort;
        }

        //Invoice Regin
        $scope.GetInvoices = function () {
            InvoicesService.GetAllInvoices().then
            (function (result) {
                $scope.Invoices = result.data;
            });
        };
        $scope.GetInvoices();

        

        $scope.InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
            PatientsService.InsertPatient(FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID).sucess(function (data, status, headers, config) {
                console.log("data inserted" + data);
            });

        };
        
    }]);