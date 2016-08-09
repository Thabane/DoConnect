app.controller("AccountingController", ["$scope", "AccountingService", "$interval",
    function ($scope, AccountingService, $interval) {

        $scope.PageTitleAccounting = 'Accounting';
        $scope.PageTitleExpenses = 'Expenses';
        $scope.PageTitleNewExpenseEntry = 'New Expense Entry';
        $scope.PageTitleNewPatientInvoiceEntry = 'New Patient Invoice Entry';
        
        var init_ControlSettings = function (){
            angular.element(".readonly").css("border", "none");            
            angular.element(".readonly").css("font-size", "13px");
            angular.element(".readonly").css("padding-right", "0px");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element("#myFunctionAccounting_Edit").show(); angular.element("#myFunctionAccounting_Save").hide();
        };
        init_ControlSettings();
        
        $scope.myFunctionAccounting_Edit = function () {            
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
            angular.element("#myFunctionAccounting_Edit").hide(); angular.element("#myFunctionAccounting_Save").show();
        };

        $scope.myFunctionAccounting_Save = function () {            
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element("#myFunctionAccounting_Edit").show(); angular.element("#myFunctionAccounting_Save").hide();
        };

        //Accounting - Expenses Page
        angular.element("#myFunctionExpenses_Edit").show(); angular.element("#myFunctionExpenses_Save").hide();
        $scope.myFunctionExpenses_Edit = function () {
            angular.element("#myFunctionExpenses_Edit").hide(); angular.element("#myFunctionExpenses_Save").show();
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
        };

        $scope.myFunctionExpenses_Save = function () {
            angular.element("#myFunctionExpenses_Edit").show(); angular.element("#myFunctionExpenses_Save").hide();
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
        };
        //$(function () {
        //    $(".datetimepicker").datetimepicker({ format: "L" });
        //});
    }]);