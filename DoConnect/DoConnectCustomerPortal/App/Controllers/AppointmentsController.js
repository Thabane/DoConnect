app.controller("AppointmentsController", ["$scope", "AppointmentsService", "$interval", "PatientsService",
    function ($scope, AppointmentsService, $interval, PatientsService) {
        $scope.Date_Time = new Date('2016-11-07 10:27');
        $scope.loggedUserID = document.cookie;
        $scope.loggedUserDoctor;

        //View Filter's
        $scope.strSort;
        $scope.limitTo = 5;

        $scope.setlimitTo = function (limit) {
            $scope.limitTo = limit;
        }
        $scope.getlimitTo = function () {
            return $scope.limitTo;
        }
        $scope.setSortKey = function (key) {
            $scope.strSort = key;
        }
        $scope.getSortKey = function () {
            return $scope.strSort;
        }
        $scope.setAdminID = function (val) {
            $scope.empID = val;
        }
        $scope.getAdminID = function () {
            return $scope.empID;
        }
        //END View Filter's

        //Select PatientByID Function
        $scope.ViewPatient = function () {
            PatientsService.GetPatientByID($scope.loggedUserID).then(function (result) {
                $scope.loggedUserDoctor = result.data["Doctor_ID"]; console.log(result.data["Doctor_ID"]);
            });
        };
        $scope.ViewPatient();

        //Select All Appointments
        $scope.GetAllAppointments = function () {
            $scope.Date_Time = new Date('2016-11-07 10:27');
            AppointmentsService.GetAllAppointments($scope.loggedUserID).then
            (function (result) {
                $scope.Appointments = result.data;
            });
        };
        $scope.GetAllAppointments();
        $interval($scope.GetAllAppointments, 5000);

        $scope.App_Statusz = [{ "Status": "Approved", "bool": "1" }, { "Status": "Declined", "bool": "0" }, { "Status": "Pending", "bool": "2" }];

        $scope.Appointments_Date_Time;
        //Select AppointmentByID Function
        $scope.ViewAppointment = function (ID) {
            AppointmentsService.GetAppointmentByID(ID).success(function (result) {
                $scope.Appointments_ID = result["Appointments_ID"];

                if (result["Appointments_App_Status"] == '1') { $scope.Appointments_App_Status = 'Approved'; }
                else if (result["Appointments_App_Status"] == '0') { $scope.Appointments_App_Status = 'Declined'; }
                else { $scope.Appointments_App_Status = 'Pending'; }
                console.log(result);
                $scope.Appointments_Date_Time = result["Appointments_Date_Time"];
                $scope.Appointments_Date_Time = { value: new Date($scope.Appointments_Date_Time) };
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
                $("#View_Appointments_Modal").modal('show');
            });
        };

        $scope.ViewDoctor = function (Doctors_ID) {
            AppointmentsService.GetDoctorByID(Doctors_ID).success(function (result) {
                $('#View_Appointments_Modal').modal('show');
                $scope.FirstName = result["FirstName"];
                $scope.LastName = result["LastName"];
                $scope.Email = result["Email"];
                $scope.Gender = result["Gender"];
		        $scope.ID = result["ID"];
		        $scope.Address = result["Address"];
		        $scope.Practice_ID = result["Practice_ID"];
		        $scope.User_ID = result["User_ID"];
		        $scope.Job_Title = result["Job_Title"];
            });
        };

        $scope.PatientID = 0;
        $scope.changedValueGetPatientID = function (item) {
            alert(item.ID);
            $scope.PatientID = item.ID;
        };

        $scope.GetDoctors = function () {
            AppointmentsService.GetAllDoctors().then
            (function (result) {
                $scope.Doctors = result.data;
            });
        };
        $scope.GetDoctors();

        $scope.DoctorID = 0;
        $scope.changedValueGetDoctors_ID = function (item) {
            alert(item.ID);
            $scope.DoctorID = item.ID;
        };

        $scope.Seleceted_App_Status = 0;
        $scope.changedValueGetApp_Status = function (item) {
            $scope.Seleceted_App_Status = item.bool;
            alert($scope.Seleceted_App_Status);
        };

        //Insert Appointment Funtion
        $scope.NewAppointment = function (Date_Time, Details) {
            //AppointmentsService.InsertAppointment(Date_Time, $scope.PatientID, Details, App_Status, $scope.DoctorID).success(function () {
            AppointmentsService.InsertAppointment(Date_Time, $scope.loggedUserID, Details, $scope.loggedUserDoctor).success(function () {
                $scope.GetAllAppointments();
                angular.element(".insert").val('');
                btnSuccess("Appointment successfully inserted.");
                btnRedirect("Appointments");
            },
                function (error) {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                });
        };


        //Update Appointment Funtion
        $scope.function_btnUpdateAppointment = function (ID) {
            var btnText = angular.element("#function_btnUpdateAppointment").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewAppointment").attr("readonly", false); angular.element(".disable_ViewAppointment").prop("disabled", false);
                angular.element("#function_btnUpdateAppointment").html("Save");
            }
            else {
                if ($scope.DoctorID == 0) { $scope.DoctorID = $scope.Doctors_ID }
                if ($scope.PatientID == 0) { $scope.PatientID = $scope.Patient_ID }
                if ($scope.Seleceted_App_Status == 0) { $scope.Seleceted_App_Status = $scope.Appointments_App_Status }

                AppointmentsService.UpdateAppointment($scope.Appointments_ID, $scope.Appointments_Date_Time.value, $scope.PatientID, $scope.Appointments_Details, $scope.Seleceted_App_Status, $scope.DoctorID).success(function () {
                    $scope.GetAllAppointments();
                    btnSuccess("Appointment details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewAppointment").attr("readonly", true); angular.element(".disable_ViewAppointment").prop("disabled", true);
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

        $scope.ViewPractice = function (ID) {
            AppointmentsService.GetPracticeByID(ID).success(function (result) {
                $("#View_Practice_Modal").modal('show');
                $scope.ID = result["ID"];
                $scope.Name = result["Name"];
                $scope.Phone_Number = result["Phone_Number"];
                $scope.Fax_Number = result["Fax_Number"];
                $scope.Street_Address = result["Street_Address"];
                $scope.Suburb = result["Suburb"];
                $scope.City = result["City"];
                $scope.Country = result["Country"];
                $scope.Trading_Times = result["Trading_Times"];
            });
        };
    }]);