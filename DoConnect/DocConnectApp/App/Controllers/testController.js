app.controller("testController", ["$scope", "PatientsService", "$interval", "$routeParams", "$route", "$location",
    function ($scope, PatientsService, $interval, $routeParams, $route, $location) {
        
        $scope.ID = $routeParams.PatientID;
    }]);