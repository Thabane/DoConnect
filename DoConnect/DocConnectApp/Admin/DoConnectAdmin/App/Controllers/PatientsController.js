app.controller("PatientsController", ["$scope", "PatientsService", "$interval",
    function ($scope, PatientsService, $interval) {
        
        PatientsService.GetAllPatients().then
        (function (results) {
            $scope.patient = result.data;
        });

        $scope.status;//"Active";
        //Function Calls
        //$interval($scope.GetStuff, 300000);
    }]);