app.controller("AccountingController", ["$scope", "AccountingService", "$interval",
    function ($scope, AccountingService, $interval) {

        AccountingService.GetAllAccounting().then
        (function (results) {
            $scope.Accounting = result.data;
        });
    }]);