app.controller("PatientsController", ["$scope", "PatientsService", "$interval",
    function ($scope, PatientsService, $interval) {

        $scope.PageTitle_Patients = 'Patients';
        $scope.PageTitle_NewPatient = 'New Patient Details';
        $scope.PageTitle_MedicalHistory = 'Medical Record';
        $scope.PageTitle_PrescriptionDetails = 'Prescription Details';
        $scope.PageTitle_ConsultationNotes = 'Consultation Notes';

        $scope.EMAIL_REGEXP = "/^(?=.{1,254}$)(?=.{1,64}@)[-!#$%&'*+\/0-9=?A-Z^_`a-z{|}~]+(\.[-!#$%&'*+\/0-9=?A-Z^_`a-z{|}~]+)*@[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?(\.[A-Za-z0-9]([A-Za-z0-9-]{0,61}[A-Za-z0-9])?)*$/";
        $scope.NUMBER_REGEXP = "/^\s*(\-|\+)?(\d+|(\d*(\.\d*)))([eE][+-]?\d+)?\s*$/";
        $scope.NAME = "/^[A-Za-z]{3,}$/";
        $scope.PASSWORD = "/(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}/";
        $scope.EMAIL = "/^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/";
        $scope.PHONE = "/^[2-9]\d{2}-\d{3}-\d{4}$/";


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

        //Sort Function
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }

        $scope.GetPatients = function () {
            PatientsService.GetAllPatients().then
            (function (result) {
                $scope.Patients = result.data;
            });
        };
        $scope.GetPatients();
                
        //Select PatientByID Function
        $scope.ViewPatient = function (PatientID) {
            PatientsService.GetPatientByID(1).then(function (result) {
                $scope.PatientDetails = result.data;
            //alert($routeParams.PatientID);
                /*$scope.ID               = result["ID"];
                $scope.FirstName        = result["FirstName"];
                $scope.LastName         = result["LastName"];
                $scope.ID_Number        = result["ID_Number"];
                $scope.Gender           = result["Gender"];
                $scope.DOB              = result["DOB"];
                $scope.Cell_Number      = result["Cell_Number"];
                $scope.Street_Address   = result["Street_Address"];
                $scope.Suburb           = result["Suburb"];
                $scope.City             = result["City"];
                $scope.Country          = result["Country"];
                $scope.Medical_Aid_ID   = result["Medical_Aid_ID"];
                $scope.Doctor_ID        = result["Doctor_ID"];
                $scope.User_ID          = result["User_ID"];
                $scope.Allergies        = PatientDetails.Allergies;
                $scope.PreviousIllnesses= result["PreviousIllnesses"];
                $scope.PreviousMedication= result["PreviousMedication"];
                $scope.RiskFactors      = result["RiskFactors"];
                $scope.SocialHistory    = result["SocialHistory"];
                $scope.FamilyHistory    = result["FamilyHistory"];
                $scope.Email                 = result["Email"];
                $scope.Scheme_Name = result["Scheme_Name"];
                $scope.Membership_Number = result["Membership_Number"];
                $scope.Status = result["Status"];
                $scope.Registration_Date = result["Registration_Date"];
                $scope.Deregistration_Date = result["Deregistration_Date"];
                $scope.Patient_ID = result["Patient_ID "];
                $scope.Medical_Aid_ID = result["Medical_Aid_ID "];

                //Prescription
                $scope.Prescription_ID = result["Prescription_ID "];
                $scope.Description = result["Description "];
                $scope.Date = result["Date "];
                $scope.Patient_ID = result["Patient_ID "];
                $scope.Prescribing_Doctor_ID = result["Prescribing_Doctor_ID "];

                //Prescription_DrugDetails
                $scope.Prescription_DrugDetails_ID = result["Prescription_DrugDetails_ID "];
                $scope.DrugName = result["DrugName "];
                $scope.Strength = result["Strength "];
                $scope.IntakeRoute = result["IntakeRoute "];
                $scope.Frequency = result["Frequency "];
                $scope.DispenseNumber = result["DispenseNumber "];
                $scope.RefillNumber = result["RefillNumber "];*/

            });
        };

        $scope.InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
            PatientsService.InsertPatient(FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID).sucess(function (data, status, headers, config) {
                console.log("data inserted" + data);
            });

        };
    }]);