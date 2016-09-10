app.controller("PatientsController", ["$scope", "PatientsService", "$interval", "$routeParams", "$route", "$location",
    function ($scope, PatientsService, $interval, $routeParams, $route, $location) {
        
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
            });
        };

        $scope.InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
            PatientsService.InsertPatient(FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID).sucess(function (data, status, headers, config) {
                console.log("data inserted" + data);
            });

        };

        //---Medical Record------------------------------------------------------------------------------------------------------------/
        $scope.DOB = { value: new Date(2016, 08, 25) };
        $scope.Genders = [{ "Gender": "Male", "Char": "M" },
                          { "Gender": "Female", "Char": "F" }];
        $scope.Seleceted_Gender = 0;
        $scope.changedValueGetGender = function (item) {
            $scope.Seleceted_Gender = item.Char;
        };
        //Select Medical Record by PatientID Funtion
        var GetMedicalRecord = function () {
            PatientsService.GetMedicalRecord(1).then(function (result) {
                $scope.MedicalRecord = result.data;
            });
        };
        GetMedicalRecord();

        //Insert Medical Record Funtion
        $scope.InsertMedicalRecord = function () {
            PatientsService.InsertMedicalRecord().success(function () {
                GetMedicalRecord();
                angular.element(".insert").val('');
                btnSuccess("Medical Record successfully inserted.");
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
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

        //Delete MedicalRecord Funtion
        $scope.DeleteMedicalRecord = function () {
            PatientsService.DeleteMedicalRecord(1).then(function () {
                GetMedicalRecord();
                btnSuccess("Medical Record details successfully deleted.");
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        };
    //---.Medical Record------------------------------------------------------------------------------------------------------------/
        //---Prescription------------------------------------------------------------------------------------------------------------/

        angular.element(".readonly_ViewPrescription").attr("readonly", true); angular.element(".disable_ViewPrescription").prop("disabled", true);
        angular.element(".readonly_ViewPrescription").css("background-color", "transparent");
        $scope.IntakeRoutez = [{ "Route": "PO (by mouth)" }, { "Route": "PR (per rectum)" }, { "Route": "IM (intramuscular)" }, { "Route": "IV (intravenous)", }, { "Route": "ID (intradermal)" }, { "Route": "IN (intranasal)" }, { "Route": "TP (topical)" }, { "Route": "SL (sublingual)" }, { "Route": "BUCC (buccal)" }, { "Route": "IP (intraperitoneal)" }];
        $scope.Frequencyz = [{ "Freq": "Daily" }, { "Freq": "Every other day" }, { "Freq": "BID/b.i.d. (Twice a Day)" }, { "Freq": "TID/t.id. (Three Times a Day)" }, { "Freq": "QID/q.i.d. (Four Times a Day)" }, { "Freq": "QHS (Every Bedtime)" }, { "Freq": "Q4h (Every 4 hours)" }, { "Freq": "Q4-6h (Every 4 to 6 hours)" }]
        //Select Prescription Notes by PatientID Funtion
        var GetPrescription = function () {
            PatientsService.GetPrescription(1).then(function (result) {
                $scope.PrescriptionDetails = result.data;
            });
        };
        GetPrescription();

        //Insert Prescription Notes Funtion ##$routeParams.PatientID, Logged in DoctorID, Consultation_ID
        $scope.InsertPrescription = function (DrugName, Strength, DispenseNumber, RefillNumber) {
            PatientsService.InsertPrescription(1, 1, 4, DrugName, Strength, $scope.Seleceted_IntakeRoute, $scope.Seleceted_Frequency, DispenseNumber, RefillNumber).success(function () {
                GetPrescription();
                angular.element(".insert").val('');
                btnSuccess("Prescription Note successfully inserted.");
                btnRedirect("PrescriptionDetails");
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
        };
        
        $scope.Seleceted_IntakeRoute = 0;
        $scope.changedValueGetIntakeRoute = function (item) {
            $scope.Seleceted_IntakeRoute = item.Route;
            alert($scope.Seleceted_IntakeRoute);
        };

        $scope.Seleceted_Frequency = 0;
        $scope.changedValueGetFrequency = function (item) {
            $scope.Seleceted_Frequency = item.Freq;
            alert($scope.Seleceted_Frequency);
        };

        $scope.btnUpdatePrescription = function (Prescription_ID, Consultation_Diagnosis,Prescription_DrugDetails_DrugName,Prescription_DrugDetails_Strength,IntakeRoute,Frequency,Prescription_DrugDetails_DispenseNumber,Prescription_DrugDetails_RefillNumber) {
            var btnText = angular.element("#btnUpdatePrescription").html();
            if (btnText == "Update") {
                angular.element(".readonly_ViewPrescription").attr("readonly", false); angular.element(".disable_ViewPrescription").prop("disabled", false);
                angular.element("#btnUpdatePrescription").html("Save");
            }
            else {
                if ($scope.Seleceted_IntakeRoute == 0) { $scope.Seleceted_IntakeRoute = IntakeRoute; }
                if ($scope.Seleceted_Frequency == 0) { $scope.Seleceted_Frequency = Frequency; }
                console.log(Prescription_ID, Consultation_Diagnosis, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, $scope.Seleceted_IntakeRoute, $scope.Seleceted_Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber);
                PatientsService.UpdatePrescription(Prescription_ID, Consultation_Diagnosis, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, $scope.Seleceted_IntakeRoute, $scope.Seleceted_Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber).success(function () {
                    GetPrescription();
                    btnSuccess("Prescription Note details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewPrescription").attr("readonly", true); angular.element(".disable_ViewPrescription").prop("disabled", true);
                angular.element(".readonly_ViewPrescription").css("background-color", "transparent");
                angular.element("#btnUpdatePrescription").html("Update");
            }
        };

        //Delete Prescription Funtion
        $scope.DeleteConsultationNote = function () {
            PatientsService.DeletePrescription(1).then(function () {
                GetPrescription();
                btnSuccess("Prescription Note details successfully deleted.");
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        };
    //---.Prescription------------------------------------------------------------------------------------------------------------/
    //---Consultation Notes------------------------------------------------------------------------------------------------------------/
        
        //Select Consultation Notes by PatientID Funtion
        var GetConsultationNotes = function () {
            PatientsService.GetConsultationNotes(1).then(function (result) {
                $scope.ConsultationNotes = result.data;
            });
        };
        GetConsultationNotes();

        //Insert Consultation Notes Funtion ##Remember to add Patient_ID, Doctor_ID, 
        $scope.InsertConsultation = function (ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan) {
            PatientsService.InsertConsultation(ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan).success(function () {
                GetConsultationNotes();
                angular.element(".insert").val('');
                btnSuccess("Consultation Note successfully inserted.");
                btnRedirect("ConsultationNotes");
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
        };

        $scope.btnUpdateConsultation = function (Consultation_ID, ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan) {
            
            var btnText = angular.element("#btnUpdateConsultation").html();
            if (btnText == "Update") {
                angular.element(".View_readonly").attr("readonly", false);
                angular.element("#btnUpdateConsultation").html("Save");
            }
            else {
                PatientsService.UpdateConsultationNote(Consultation_ID, ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan).success(function () {
                        GetConsultationNotes();
                        btnSuccess("Consultation Note details successfully updated.");
                    }, function (error) {
                        btnAlert("System Error Message", "Update unsuccessful.");
                    });

                angular.element(".View_readonly").attr("readonly", true);
                angular.element("#btnUpdateConsultation").html("Update");
            }
        };

        //Delete Consultation Notes Funtion
        $scope.DeleteConsultationNote = function () {
            PatientsService.DeleteConsultationNote(1).then(function () {
                GetConsultationNotes();
                btnSuccess("Consultation Note details successfully deleted.");
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
            });
        };

    //---.Consultation Notes------------------------------------------------------------------------------------------------------------/

    }]);