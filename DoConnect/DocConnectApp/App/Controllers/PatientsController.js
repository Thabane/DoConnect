app.controller("PatientsController", ["$scope", "PatientsService", "$interval",
    function ($scope, PatientsService, $interval) {

        $scope.PageTitle_Patients = 'Patients';
        $scope.PageTitle_NewPatient = 'New Patient Details';

        var init_ControlSettings = function () {
            angular.element(".View_readonly").attr("readonly", true);
            angular.element(".View_readonly").css("border", "1px solid #ccc");
            angular.element(".View_readonly").css("background-color", "transparent");
        };
        init_ControlSettings();//Excecute the function on page load.

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

        $scope.users = []; //declare an empty array
        $scope.GetPatients = function () {
            PatientsService.GetAllPatients().then
            (function (result) {
                $scope.Patients = result.data;
            });
        };
        $scope.GetPatients();

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

        $scope.InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
            PatientsService.InsertPatient(FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID).sucess(function (data, status, headers, config) {
                console.log("data inserted" + data);
            });

        };

        //$scope.myFunctionViewPatient = function (ID) {
        //    var ID = ID;
        //    $scope.GetPatient = function (ID) {
        //        PatientsService.GetPatient(ID).then
        //        (function (result) {
        //            $scope.Patient = result.data;
        //        });
        //    };
        //    $scope.GetPatient();
        //};
    }]);