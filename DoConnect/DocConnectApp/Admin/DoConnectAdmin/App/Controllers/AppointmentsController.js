app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval",
    function ($scope, AppointmentsService, $interval) {

        var init_ControlSettings = function () {
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("font-size", "13px");
            angular.element(".readonly").css("padding-right", "0px");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element("#myFunctionAppointments_Edit").show(); angular.element("#myFunctionAppointments_Save").hide();
        };
        init_ControlSettings();

        $scope.myFunctionAppointments_Edit = function () {
            angular.element("#myFunctionAppointments_Edit").hide(); angular.element("#myFunctionAppointments_Save").show();
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
        };

        $scope.myFunctionAppointments_Save = function () {
            angular.element("#myFunctionAppointments_Edit").show(); angular.element("#myFunctionAppointments_Save").hide();
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
        };

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
    }]);