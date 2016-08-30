app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval",
    function ($scope, AppointmentsService, $interval) {
           
        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        //Select All Appointments
        $scope.GetAllAppointments = function () {
            AppointmentsService.GetAllAppointments().then
            (function (result) {
                $scope.Appointments = result.data;
            });
        };
        $scope.GetAllAppointments();

        //Select AppointmentByID Function
        $scope.ViewAppointment = function (ID) {
            AppointmentsService.GetAppointmentByID(ID).success(function (result) {
                $scope.ID = result["ID"];
                $scope.App_Status = result["App_Status"];
                $scope.Date_Time = result["Date_Time"];
                $scope.Details = result["Details"];
                $scope.Patient_ID = result["Patient_ID"];
                $scope.Doctor_ID = result["Doctor_ID"];
            });
        };

        //Insert Appointment Funtion
        $scope.NewAppointment = function (Date_Time, Patient_ID, Details, App_Status) {
            AppointmentsService.InsertAppointment(Date_Time, Patient_ID, Details, App_Status).success(function () {
                $scope.GetAllAppointments();
                angular.element(".insert").val('');
                btnSuccess("Appointment successfully inserted.");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };

        //Update Appointment Funtion
        $scope.function_btnUpdateAppointment = function (ID) {
            var btnText = angular.element("#function_btnUpdateAppointment").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewAppointment").attr("readonly", false);
                angular.element("#function_btnUpdateAppointment").html("Save");
            }
            else {
                AppointmentsService.UpdateAppointment($scope.ID, $scope.Date_Time, $scope.Patient_ID, $scope.Details, $scope.App_Status).success(function () {
                    $scope.GetAllAppointments();
                    btnSuccess("Appointment details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });

                angular.element(".readonly_ViewAppointment").attr("readonly", true);
                angular.element(".readonly_ViewAppointment").css("background-color", "transparent");
                angular.element("#function_btnUpdateAppointment").html("Update");
            }
        };

        //Delete Practice Funtion
        $scope.DeleteAppointment = function () {
            AppointmentsService.DeleteAppointment($scope.ID).then(function () {
                $scope.GetAllAppointments();
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });         
        };
    }]);