app.controller("ReportsController", ["$scope", "ReportsService", "$interval",
    function ($scope, ReportsService, $interval) {

        ReportsService.GetAllReports().then
        (function (results) {
            $scope.Reports = result.data;
        });
    }]);