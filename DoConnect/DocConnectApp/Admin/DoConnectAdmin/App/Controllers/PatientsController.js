app.controller("PatientsController", ["$scope", "PatientsService", "$interval", 
    function ($scope, PatientsService, $interval) {
        
        $scope.PageTitle_Patients = 'Patients';
        $scope.PageTitle_NewPatient = 'New Patient Details';

        var init_ControlSettings = function () {
            angular.element(".readonly").css("border", "none");	        
	        angular.element(".readonly").css("font-size", "13px");
	        angular.element(".readonly").css("padding-right", "0px");
            angular.element(".readonly").css("background-color", "transparent");   

	        angular.element(".View_readonly").attr("readonly", true);
	        angular.element(".View_readonly").css("border", "1px solid #ccc");
	        angular.element(".View_readonly").css("background-color", "transparent");	        
        };
        init_ControlSettings();//Excecute the function on page load.

        $scope.myFunctionPatients_Edit = function (btnEdit, btnSave) {
            angular.element(".readonly").attr("readonly", false);
            angular.element(".readonly").css("border", "1px solid #ccc");
            angular.element('#' + btnSave).removeClass("hide"); angular.element('#' + btnSave).addClass("show");
            angular.element('#' + btnEdit).removeClass("show"); angular.element('#' + btnEdit).addClass("hide");
        };

        $scope.myFunctionPatients_Save = function (btnEdit, btnSave) {
            angular.element(".readonly").attr("readonly", true);
            angular.element(".readonly").css("border", "none");
            angular.element(".readonly").css("background-color", "transparent");
            angular.element('#' + btnSave).addClass("hide"); angular.element('#' + btnSave).removeClass("show");
            angular.element('#' + btnEdit).addClass("show"); angular.element('#' + btnEdit).removeClass("hide");
        };

        $scope.btnUpdateMedicalRecord = function () {
            var btnText = angular.element("#btnUpdateMedicalRecord").html();
            if (btnText == "Update") {
                angular.element(".View_readonly").attr("readonly", false);
                angular.element("#btnUpdateMedicalRecord").html("Save");
            }
            else {
                angular.element(".View_readonly").attr("readonly", true);
                angular.element("#btnUpdateMedicalRecord").html("Update");
            }
        };

        $scope.btnUpdateConsultation = function () {
            var btnText = angular.element("#btnUpdateConsultation").html();
            if (btnText == "Update") {
                angular.element(".View_readonly").attr("readonly", false);
                angular.element("#btnUpdateConsultation").html("Save");
            }
            else {
                angular.element(".View_readonly").attr("readonly", true);
                angular.element("#btnUpdateConsultation").html("Update");
            }
        };

        $scope.GetPatients = function () {
            PatientsService.GetAllPatients().then
            (function (result) {
                $scope.Patients = result.data;
            });
        };
        $scope.GetPatients();

        
        $scope.myFunctionViewPatient = function (ID) {
            var ID = ID;
            $scope.GetPatient = function (ID) {
                PatientsService.GetPatient(ID).then
                (function (result) {
                    $scope.Patient = result.data;
                });
            };
            $scope.GetPatient();
        };




        
        
        $scope.patientID = function (patientID) {
            alert("patientID is " + patientID);
        };

    }]);