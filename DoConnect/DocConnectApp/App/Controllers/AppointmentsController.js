app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval",
    function ($scope, AppointmentsService, $interval) {

        $scope.function_btnUpdateAppointment = function () {
            var btnText = angular.element("#function_btnUpdateAppointment").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewAppointment").attr("readonly", false);
                angular.element("#function_btnUpdateAppointment").html("Save");
            }
            else {
                angular.element(".readonly_ViewAppointment").attr("readonly", true);
                angular.element(".readonly_ViewAppointment").css("background-color", "transparent");
                angular.element("#function_btnUpdateAppointment").html("Update");
            }
        };

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }
    }]);