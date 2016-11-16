app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval", "$ngBootbox", "$location", "PatientsService",
    function ($scope, AppointmentsService, $interval, $ngBootbox, $location, PatientsService) {

        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetAllAppointments = function () {            
            AppointmentsService.GetAllAppointments().then(function (result) {
                $scope.Appointments = result.data;                
                $scope.numTodayApps = $scope.Appointments[$scope.Appointments.length - 1].numTodayApps;
                $scope.numTomorrowApps = $scope.Appointments[$scope.Appointments.length - 1].numTomorrowApps;
                $scope.numYesterdayApps = $scope.Appointments[$scope.Appointments.length - 1].numYesterdayApps;
            });

            PatientsService.SessionData().success(function (result) {
                sessionStorage.Selected_PatientID = result["ID"];
                sessionStorage.Selected_ConsultationID = result["ID"];
                sessionStorage.SessionData_User_ID = result["User_ID"];
            });
        };
        $scope.GetAllAppointments();

        $interval($scope.GetAllAppointments, 5000);

        $scope.App_Statusz = [{ "Status": "Approved", "bool": "1" }, { "Status": "Declined", "bool": "0" }, { "Status": "Pending", "bool": "2"}];
        $scope.listApp_Statusz = [{ "Status": "Approved", "bool": "1" }, { "Status": "Pending", "bool": "2" }];
        $scope.TimeError = 0;

        $scope.ViewAppointment = function (ID) {
            AppointmentsService.GetAppointmentByID(ID).success(function (result) {
                $scope.Appointments_ID = result["Appointments_ID"];

                if (result["Appointments_App_Status"] == '1') { $scope.Appointments_App_Status = 'Approved'; }
                else if (result["Appointments_App_Status"] == '0') { $scope.Appointments_App_Status = 'Declined'; }
                else { $scope.Appointments_App_Status = 'Pending'; }

                var Array = result["Appointments_Date_Time"].split(' ');
                $scope.Appointments_Date = Array[0];
                $scope.Appointments_Time = Array[1];
                $scope.Appointments_Details = result["Appointments_Details"];
                $scope.Patient_ID = result["Patient_ID"];
                $scope.Patient_FirstName = result["Patient_FirstName"];
                $scope.Patient_LastName = result["Patient_LastName"];
                $scope.Patient_Cell_Number = result["Patient_Cell_Number"];
                $scope.Patient_Email = result["Patient_Email"];
                $scope.Doctors_Email = result["Doctors_Email"];
                $scope.Doctors_FirstName = result["Doctors_FirstName"];
                $scope.Doctors_LastName = result["Doctors_LastName"];
                $scope.Doctors_ID = result["Doctors_ID"];
                $scope.Doctors_Job_Title = result["Doctors_Job_Title"];
                $scope.Practice_ID = result["Practice_ID"];
                $scope.Practice_Name = result["Practice_Name"];
                $scope.Practice_Phone_Number = result["Practice_Phone_Number"];
                $scope.Practice_Fax_Number = result["Practice_Fax_Number"];
                $scope.Practice_Address = result["Practice_Address"];
            });
        };

        $scope.GetPatients = function () {
            AppointmentsService.GetAllPatients().then(function (result) {
                $scope.Patients = result.data;
            });
        };
        $scope.GetPatients();

        $scope.PatientID = 0;
        $scope.changedValueGetPatientID = function (item) {
            $scope.PatientID = item.ID;
        };

        $scope.GetDoctors = function () {
            AppointmentsService.GetAllDoctors().then(function (result) {
                $scope.Doctors = result.data;
            });
        };
        $scope.GetDoctors();

        $scope.DoctorID = 0;
        $scope.changedValueGetDoctors_ID = function (item) {
            $scope.DoctorID = item.ID;
        };

        $scope.Seleceted_App_Status = 0;
        $scope.changedValueGetApp_Status = function (item) {
            $scope.Seleceted_App_Status = item.bool;
        };

        $scope.NewAppointment = function (Details) {
            var TheTime  = angular.element("#Appointments_Time").val();
            if(TheTime != '') 
            {
                if(regs = TheTime) 
                {
                    var hours = regs[0]+""+regs[1];
                    var minutes = regs[3]+""+regs[4]
                    var errorCount = 0;                        
                    if ((hours < 9) || (hours > 17)) {
                        errorCount++;
                    }      
                        
                    if (minutes > 59) {
                        errorCount++;
                    }
                    
                    if (errorCount != 0) {
                        $scope.TimeError = "Please make an appointment during our office hours.\nOffice hours: 9:00 hours to 17:00 hours.";

                    }
                    else {
                        AppointmentsService.InsertAppointment(angular.element("#Appointments_Date").val() + " " + angular.element("#Appointments_Time").val(), sessionStorage.Selected_PatientID, Details, 2, $scope.DoctorID).success(function () {
                            $scope.GetAllAppointments();
                            angular.element(".insert").val('');
                            btnSuccess("Appointment successfully inserted.");
                            $location.path('/Appointments');
                        },
                            function (error) {
                                btnAlert("System Error Message", "Insert unsuccessful.");
                            });
                        $scope.TimeError = 0;
                    }
                }
            }
        };

        $scope.function_btnUpdateAppointment = function (ID) {
            var btnText = angular.element("#function_btnUpdateAppointment").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewAppointment").attr("readonly", false); angular.element(".disable_ViewAppointment").prop("disabled", false);
                angular.element("#function_btnUpdateAppointment").html("Save");
            }
            else {
                if ($scope.DoctorID == 0) { $scope.DoctorID = $scope.Doctors_ID }
                if ($scope.PatientID == 0) { $scope.PatientID = $scope.Patient_ID }
                if ($scope.Appointments_App_Status == 'Pending') {
                    $scope.AppSta = '2';
                }
                else if ($scope.Appointments_App_Status == 'Approved') {
                    $scope.AppSta = '1';
                }
                else {
                    $scope.AppSta = '0';
                }

                if ($scope.Seleceted_App_Status == 0) { $scope.Seleceted_App_Status = $scope.AppSta }

                var TheTime  = angular.element("#Appointments_Time").val();
                if(TheTime != '') 
                {
                    if(regs = TheTime) 
                    {
                        var hours = regs[0]+""+regs[1];
                        var minutes = regs[3]+""+regs[4]
                        var errorCount = 0;                        
                        if ((hours < 9) || (hours > 17)) {
                            errorCount++;
                        }      
                        
                        if (minutes > 59) {
                            errorCount++;
                        }

                        if (errorCount != 0) {
                            $scope.TimeError = "Please make an appointment during our office hours.\nOffice hours: 9:00 hours to 17:00 hours.";

                        }
                        else {
                            AppointmentsService.UpdateAppointment($scope.Appointments_ID, angular.element("#Appointments_Date").val() + " " + angular.element("#Appointments_Time").val(), $scope.PatientID, $scope.Appointments_Details, $scope.Seleceted_App_Status, $scope.DoctorID).success(function () {
                                angular.element(".close").trigger("click");
                                $scope.GetAllAppointments();
                                btnSuccess("Appointment details successfully updated.");
                            }, function (error) {
                                btnAlert("System Error Message", "Update unsuccessful.");
                            });
                            $scope.TimeError = 0;
                        }
                    }
                }
                
                angular.element(".readonly_ViewAppointment").attr("readonly", true); angular.element(".disable_ViewAppointment").prop("disabled", true);
                angular.element(".readonly_ViewAppointment").css("background-color", "transparent");
                angular.element("#function_btnUpdateAppointment").html("Update");
            }
        };

        $scope.DeleteAppointment1 = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this Appointment?").then(function () {
                AppointmentsService.DeleteAppointment(ID).then(function () {
                    $scope.GetAllAppointments();
                    btnSuccess("Appointment record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
        $scope.DeleteAppointment2 = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Appointment?").then(function () {
                AppointmentsService.DeleteAppointment($scope.Appointments_ID).then(function () {
                    $scope.GetAllAppointments();
                    angular.element("#CloseModel").trigger("click");
                    btnSuccess("Appointment record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () {});
        };
    }]);