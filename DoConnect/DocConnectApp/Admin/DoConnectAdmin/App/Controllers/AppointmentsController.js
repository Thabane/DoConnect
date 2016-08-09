app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval",
    function ($scope, AppointmentsService, $interval) {

        AppointmentsService.GetAllAppointments().then
        (function (results) {
            $scope.appointments = result.data;
        });

        //Function Calls
        //$interval($scope.GetStuff, 300000);
    }]);