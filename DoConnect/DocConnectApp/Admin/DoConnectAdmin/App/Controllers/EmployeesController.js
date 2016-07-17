app.controller("EmployeesController", ["$scope", "EmployeesService", "$interval",
    function ($scope, EmployeesService, $interval) {

        EmployeesService.GetAllEmployees().then
        (function (results) {
            $scope.employees = result.data;
        });

        //Function Calls
        //$interval($scope.GetStuff, 300000);
    }]);