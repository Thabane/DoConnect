app.controller("AccountingController", ["$scope", "AccountingService", "$interval",
    function ($scope, AccountingService, $interval) {

        $scope.PageTitleAccounting = 'Accounting';
        $scope.PageTitleExpenses = 'Expenses';
        $scope.PageTitleNewExpenseEntry = 'New Expense Entry';
        $scope.PageTitleNewPatientInvoiceEntry = 'New Patient Invoice Entry';
        
    }]);