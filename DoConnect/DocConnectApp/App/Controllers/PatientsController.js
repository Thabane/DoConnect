app.controller("PatientsController", ["$scope", "PatientsService", "$interval", "$ngBootbox", "$location",
    function ($scope, PatientsService, $interval, $ngBootbox, $location) {

        $scope.PageTitle_Patients = 'Patients';
        $scope.PageTitle_NewPatient = 'New Patient Details';
        $scope.PageTitle_MedicalHistory = 'Medical Record';
        $scope.PageTitle_PrescriptionDetails = 'Prescription Details';
        $scope.PageTitle_ConsultationNotes = 'Consultation Notes';
        
        var init_ControlSettings = function () {
            angular.element(".View_readonly").attr("readonly", true);
            angular.element(".View_readonly").css("border", "1px solid #ccc");
            angular.element(".View_readonly").css("background-color", "transparent");

            PatientsService.SessionData().success(function (result) {
                sessionStorage.SessionData_User_ID = result["User_ID"];
                sessionStorage.SessionData_FirstName = result["FirstName"];
                sessionStorage.SessionData_LastName = result["LastName"];
                sessionStorage.SessionData_Email = result["Email"];
                sessionStorage.SessionData_Practice_ID = result["Practice_ID"];
                sessionStorage.SessionData_AccessLevel = result["AccessLevel"];

                if (result["AccessLevel"] == '1' || result["AccessLevel"] == '2') {
                    angular.element(".doctorControls").show();
                }
                else {
                    angular.element(".doctorControls").hide();
                }
            });
        };
        init_ControlSettings();
        
        $scope.sort = function (keyname) {
            $scope.sortKey = keyname;
            $scope.reverse = !$scope.reverse;
        }       

        $scope.GetPatients = function () {
            PatientsService.GetAllPatients().then(function (result) {
                $scope.Patients = result.data;                
            });
        };
        $scope.GetPatients();
        
        $scope.ViewPatient = function (PatientID) {
            sessionStorage.Selected_PatientID = PatientID;
        };

        $scope.SetConsultationID = function (ConsultationID) {
            sessionStorage.Selected_ConsultationID = ConsultationID;
        };

        $scope.DeletePatient1 = function (ID, Name) {
            $ngBootbox.confirm("Are you sure you want to delete this Patient: "+ Name +" ?").then(function () {
                PatientsService.DeletePatient(ID).then(function () {
                    $scope.GetPatients();
                    btnSuccess("Patient record successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
        //---#region Medical Record------------------------------------------------------------------------------------------------------------/
        
        $scope.Genders = [{ "Gender": "Male", "Char": "M" }, { "Gender": "Female", "Char": "F" }];
        $scope.Seleceted_Gender = 0;
        $scope.changedValueGetGender = function (item) {
            $scope.Seleceted_Gender = item.Char;
        };
        
        var GetMedicalRecord = function () {
            PatientsService.GetMedicalRecord(sessionStorage.Selected_PatientID).then(function (result) {
                $scope.ID = result.data["ID"];
                $scope.FirstName = result.data["FirstName"];
                $scope.LastName = result.data["LastName"];
                $scope.ID_Number = result.data["ID_Number"];
                if (result.data["Gender"] == 'M') {$scope.Gender = 'Male'; } else { $scope.Gender = 'Female'; }
                $scope.DOB = result.data["DOB"];
                $scope.Cell_Number = result.data["Cell_Number"];
                $scope.Street_Address = result.data["Street_Address"];
                $scope.Suburb = result.data["Suburb"];
                $scope.City = result.data["City"];
                $scope.Country = result.data["Country"];
                $scope.Medical_Aid_ID = result.data["Medical_Aid_ID"];
                $scope.Medical_Aid_Name = result.data["Name"];
                $scope.Doctor_ID = result.data["Doctor_ID"];
                $scope.User_ID = result.data["User_ID"];
                $scope.Allergies = result.data["Allergies"];
                $scope.PreviousIllnesses = result.data["PreviousIllnesses"];
                $scope.PreviousMedication = result.data["PreviousMedication"];
                $scope.RiskFactors = result.data["RiskFactors"];
                $scope.SocialHistory = result.data["SocialHistory"];
                $scope.FamilyHistory = result.data["FamilyHistory"];
                $scope.Email = result.data["Email"];
                $scope.Patient_Medical_Aid_Medical_Aid_ID = result.data["Patient_Medical_Aid_Medical_Aid_ID"];
                $scope.Scheme_Name = result.data["Scheme_Name"];
                $scope.Membership_Number = result.data["Membership_Number"];
                if (result.data["Status"])
                { $scope.Status = "Valid"; } 
                else { $scope.Status = "Invalid"; }
                $scope.Registration_Date = result.data["Registration_Date"];
                $scope.Deregistration_Date = result.data["Deregistration_Date"];
                $scope.Patient_ID = result.data["Patient_ID"];

                angular.element(".disable_View_readonly").prop("disabled", true);
            });
        };
        GetMedicalRecord();        

        $scope.GetMedical_Aid = function () {
            PatientsService.GetMedical_Aid().then(function (result) {
                $scope.Medical_Aid = result.data;
            });
        };
        $scope.GetMedical_Aid();

        $scope.Medical_AidID = 0;
        $scope.changedValueMedical_AidID = function (item) {
            $scope.Medical_AidID = item.ID;
        }; 

        //Insert Medical Record Funtion ##Doctor_ID     
        $scope.InsertPatient = function (FirstName, LastName, Email, ID_Number, Cell_Number, Street_Address, Suburb, City, Country, SchemeName, MembershipNumber, Allergies, PreviousMedication, PreviousIllnesses, RiskFactors, SocialHistory, FamilyHistory) {
            PatientsService.InsertMedicalRecord(2, FirstName, LastName, Email, ID_Number, Cell_Number, angular.element("#DOB").val(), $scope.Seleceted_Gender, Street_Address, Suburb, City, Country, $scope.Medical_AidID, SchemeName, MembershipNumber, angular.element("#Registration_Date").val(), angular.element("#Deregistration_Date").val(), Allergies, PreviousMedication, PreviousIllnesses, RiskFactors, SocialHistory, FamilyHistory).then(function (result) {
                GetMedicalRecord();
                $location.path('/Patients');
                if (result) {
                    angular.element(".insert").val('');
                    btnSuccess("Medical Record successfully inserted.");
                }
                else {
                    btnAlert("System Error Message", "Insert unsuccessful.");
                }
                
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
        };
        
        $scope.btnUpdateMedicalRecord = function () {
            var btnText = angular.element("#btnUpdateMedicalRecord").html();
            if (btnText == "Update") {
                angular.element(".View_readonly").attr("readonly", false); angular.element(".disable_View_readonly").prop("disabled", false);
                angular.element("#btnUpdateMedicalRecord").html("Save");
            }
            else {
                if ($scope.Medical_AidID == 0) { $scope.Medical_AidID = $scope.Patient_Medical_Aid_Medical_Aid_ID; }
                if ($scope.Gender == 'Male') {
                    $scope.G= 'M';
                }
                else {
                    $scope.G = 'F';
                }
                PatientsService.UpdateMedicalRecord($scope.ID, $scope.FirstName, $scope.LastName, $scope.Email, $scope.ID_Number, $scope.Cell_Number, angular.element("#DOB").val(), $scope.G, $scope.Street_Address, $scope.Suburb, $scope.City, $scope.Country, $scope.Medical_AidID, $scope.Scheme_Name, $scope.Membership_Number, angular.element("#Registration_Date").val(), angular.element("#Deregistration_Date").val(), $scope.Allergies, $scope.PreviousIllnesses, $scope.PreviousMedication, $scope.RiskFactors, $scope.SocialHistory, $scope.FamilyHistory).success(function () {
                    GetMedicalRecord();
                    btnSuccess("Medical Record details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".View_readonly").attr("readonly", true); angular.element(".disable_View_readonly").prop("disabled", true);
                angular.element("#btnUpdateMedicalRecord").html("Update");
            }
        };

        $scope.DeleteMedicalRecord = function () {
            $ngBootbox.confirm("Are you sure you want to delete this Patient: "+ $scope.FirstName+" "+$scope.LastName +" ?").then(function () {
                PatientsService.DeletePatient(sessionStorage.Selected_PatientID).then(function () {
                    btnSuccess("Medical Record details successfully deleted.");
                    $location.path('/Patients');
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
        
        //---#region Prescription------------------------------------------------------------------------------------------------------------/

        angular.element(".readonly_ViewPrescription").attr("readonly", true); angular.element(".disable_ViewPrescription").prop("disabled", true);
        angular.element(".readonly_ViewPrescription").css("background-color", "transparent");
        $scope.IntakeRoutez = [{ "Route": "PO (by mouth)" }, { "Route": "PR (per rectum)" }, { "Route": "IM (intramuscular)" }, { "Route": "IV (intravenous)", }, { "Route": "ID (intradermal)" }, { "Route": "IN (intranasal)" }, { "Route": "TP (topical)" }, { "Route": "SL (sublingual)" }, { "Route": "BUCC (buccal)" }, { "Route": "IP (intraperitoneal)" }];
        $scope.Frequencyz = [{ "Freq": "Daily" }, { "Freq": "Every other day" }, { "Freq": "BID/b.i.d. (Twice a Day)" }, { "Freq": "TID/t.id. (Three Times a Day)" }, { "Freq": "QID/q.i.d. (Four Times a Day)" }, { "Freq": "QHS (Every Bedtime)" }, { "Freq": "Q4h (Every 4 hours)" }, { "Freq": "Q4-6h (Every 4 to 6 hours)" }]
        
        var GetPrescription = function () {
            PatientsService.GetPrescription(sessionStorage.Selected_PatientID).then(function (result) {
                $scope.PrescriptionDetails = result.data;                
            });
        };
        GetPrescription();

        //Insert Prescription Notes Funtion ##Patient_ID, Doctor_ID, Consultation_ID
        $scope.InsertPrescription = function (DrugName, Strength, DispenseNumber, RefillNumber) {
            PatientsService.InsertPrescription(sessionStorage.Selected_PatientID, sessionStorage.SessionData_User_ID, sessionStorage.Selected_ConsultationID, DrugName, Strength, $scope.Seleceted_IntakeRoute, $scope.Seleceted_Frequency, DispenseNumber, RefillNumber).success(function () {
                GetPrescription();
                angular.element(".insert").val('');
                btnSuccess("Prescription successfully inserted.");
                $location.path('/PrescriptionDetails');
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });
        };
        
        $scope.Seleceted_IntakeRoute = 0;
        $scope.changedValueGetIntakeRoute = function (item) {
            $scope.Seleceted_IntakeRoute = item.Route;
        };

        $scope.Seleceted_Frequency = 0;
        $scope.changedValueGetFrequency = function (item) {
            $scope.Seleceted_Frequency = item.Freq;
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
                    btnSuccess("Prescription details successfully updated.");
                }, function (error) {
                    btnAlert("System Error Message", "Update unsuccessful.");
                });
                angular.element(".readonly_ViewPrescription").attr("readonly", true); angular.element(".disable_ViewPrescription").prop("disabled", true);
                angular.element(".readonly_ViewPrescription").css("background-color", "transparent");
                angular.element("#btnUpdatePrescription").html("Update");
            }
        };

        $scope.DeletePrescription = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this Prescription ?").then(function () {
                PatientsService.DeletePrescription(ID).then(function () {
                    GetPrescription();
                    btnSuccess("Prescription details successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };

        //---#region Consultation Notes------------------------------------------------------------------------------------------------------------/
        
        var GetConsultationNotes = function () {
            PatientsService.GetConsultationNotes(sessionStorage.Selected_PatientID).then(function (result) {
                $scope.ConsultationNotes = result.data;
            });
        };
        GetConsultationNotes();

        //Insert Consultation Notes Funtion ##Remember to add Patient_ID, Doctor_ID, 
        $scope.InsertConsultation = function (ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan) {
            PatientsService.InsertConsultation(sessionStorage.Selected_PatientID, ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan, 1, 1).success(function () {
                //GetConsultationNotes();
                angular.element(".insert").val('');
                btnSuccess("Consultation Note successfully inserted.");
                $ngBootbox.confirm("The regular consultation fee is R250. Would you like to add an additional consultation fees?").then(function () {
                    //Executed when user clicks yes
                    angular.element("#UpdateConsultation_AddAdditionalFee").css("display", "block");
                    angular.element("#UpdateConsultation_AddAdditionalFee").addClass("show");
                        
                }, function () {
                    $location.path('/ConsultationNotes');
                });
            }, function (error) {
                btnAlert("System Error Message", "Insert unsuccessful.");
            });          
        };        

        $scope.close_AddAdditionalFee = function () {
            angular.element("#UpdateConsultation_AddAdditionalFee").css("display", "none");
            angular.element("#UpdateConsultation_AddAdditionalFee").add(".hide, .fade");
            angular.element("#UpdateConsultation_AddAdditionalFee").removeClass("show");
        };

        $scope.UpdateConsultation_AddAdditionalFee = function (AddAdditionalFee, InvoiceDocMessage) {
            PatientsService.UpdateConsultation_AddAdditionalFee(AddAdditionalFee, InvoiceDocMessage).then(function () {
                angular.element("#close_AddAdditionalFee").trigger("click");
                $location.path('/ConsultationNotes');
                btnSuccess("Additional consultation fee has been recorded.");
                
            }, function (error) {
                btnAlert("System Error Message", "Delete unsuccessful.");
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

        $scope.DeleteConsultationNote = function (ID) {
            $ngBootbox.confirm("Are you sure you want to delete this Consultation Note ?").then(function () {
                PatientsService.DeleteConsultationNote(ID).then(function () {
                    GetConsultationNotes();
                    btnSuccess("Consultation Note details successfully deleted.");
                }, function (error) {
                    btnAlert("System Error Message", "Delete unsuccessful.");
                });
            }, function () { });
        };
    }]);