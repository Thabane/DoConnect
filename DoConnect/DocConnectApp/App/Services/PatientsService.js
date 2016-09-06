app.factory('PatientsService',
    function ($http) {

        //Select all Patient data
        var GetAllPatients = function () {
            return  $http.get("api/Patients/GetAllPatients");
        }            

        //Select Patient by PatientID
        var GetPatientByID = function (ID) {
            return $http.get("api/Patients/GetPatient/" + ID);
        }

        //Insert New Patient
        /*var InsertPatient = function (FirstName, LastName, ID_Number, Gender, DOB, Cell_Number, Street_Address, Suburb, City, Country, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory, Medical_Aid_ID, Doctor_ID, User_ID) {
            $http.post("api/Patients/InsertPatient",
            {
                'FirstName': FirstName, 
                'LastName': LastName, 
                'ID_Number': ID_Number, 
                'Gender': Gender, 
                'DOB': DOB, 
                'Cell_Number': Cell_Number, 
                'Street_Address': Street_Address, 
                'Suburb': Suburb, 
                'City': City,
                'Country': Country,
                'Allergies': Allergies, 
                'PreviousIllnesses': PreviousIllnesses,
                'PreviousMedication': PreviousMedication,
                'RiskFactors': RiskFactors,
                'SocialHistory': SocialHistory,
                'FamilyHistory': FamilyHistory,
                'Medical_Aid_ID': Medical_Aid_ID,
                'Doctor_ID': Doctor_ID,
                'User_ID': User_ID
            });
        }*/
        //--Medical Record-----------------------------------------------------------------------------------------------------
        //Select Medical Record by PatientID
        var GetMedicalRecord = function (ID) {
            return $http.get("api/Patients/GetMedicalRecord/" + ID);
        }

        //Insert new record 
        var InsertMedicalRecord = function () {
            console.log();
            return $http.post("api/Patients/InsertMedicalRecord",
            {
                'Patient_ID': Patient_ID,
                'Doctors_ID': Doctor_ID,
                'Consultation_ID': Consultation_ID,
                'Prescription_DrugDetails_DrugName': Prescription_DrugDetails_DrugName,
                'Prescription_DrugDetails_Strength': Prescription_DrugDetails_Strength,
                'Prescription_DrugDetails_IntakeRoute': Prescription_DrugDetails_IntakeRoute,
                'Prescription_DrugDetails_Frequency': Prescription_DrugDetails_Frequency,
                'Prescription_DrugDetails_DispenseNumber': Prescription_DrugDetails_DispenseNumber,
                'Prescription_DrugDetails_RefillNumber': Prescription_DrugDetails_RefillNumber
            });
        };

        //Update MedicalRecord
        var UpdateMedicalRecord = function () {
            console.log();
            return $http.post("api/Patients/UpdateMedicalRecord",
            {
                'Prescription_ID': Prescription_ID,
                'Consultation_Diagnosis': Consultation_Diagnosis,
                'Prescription_DrugDetails_DrugName': Prescription_DrugDetails_DrugName,
                'Prescription_DrugDetails_Strength': Prescription_DrugDetails_Strength,
                'Prescription_DrugDetails_IntakeRoute': IntakeRoute,
                'Prescription_DrugDetails_Frequency': Frequency,
                'Prescription_DrugDetails_DispenseNumber': Prescription_DrugDetails_DispenseNumber,
                'Prescription_DrugDetails_RefillNumber': Prescription_DrugDetails_RefillNumber
            });
        };

        //Delete the Record
        var DeleteMedicalRecord = function (ID) {
            return $http.post("api/Patients/DeleteMedicalRecord/" + ID);
        };

        //---------------------------------------------------------------------------------------------------------/

        //--Prescription-------------------------------------------------------------------------------------------------------/
        //Select Prescription Notes by PatientID
        var GetPrescription = function (ID) {
            return $http.get("api/Patients/GetPrescription/" + ID);
        }

        //Insert new record 
        var InsertPrescription = function (Patient_ID, Doctor_ID, Consultation_ID, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, Prescription_DrugDetails_IntakeRoute, Prescription_DrugDetails_Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber) {
            console.log(Patient_ID, Doctor_ID, Consultation_ID, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, Prescription_DrugDetails_IntakeRoute, Prescription_DrugDetails_Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber);
            return $http.post("api/Patients/InsertPrescription",
            {
                'Patient_ID': Patient_ID,
                'Doctors_ID': Doctor_ID,
                'Consultation_ID': Consultation_ID,
                'Prescription_DrugDetails_DrugName': Prescription_DrugDetails_DrugName,
                'Prescription_DrugDetails_Strength': Prescription_DrugDetails_Strength,
                'Prescription_DrugDetails_IntakeRoute': Prescription_DrugDetails_IntakeRoute,
                'Prescription_DrugDetails_Frequency': Prescription_DrugDetails_Frequency,
                'Prescription_DrugDetails_DispenseNumber': Prescription_DrugDetails_DispenseNumber,
                'Prescription_DrugDetails_RefillNumber': Prescription_DrugDetails_RefillNumber
            });
        };

        //Update Prescription Details
        var UpdatePrescription = function (Prescription_ID, Consultation_Diagnosis, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, IntakeRoute, Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber) {
            console.log(Prescription_ID, Consultation_Diagnosis, Prescription_DrugDetails_DrugName, Prescription_DrugDetails_Strength, IntakeRoute, Frequency, Prescription_DrugDetails_DispenseNumber, Prescription_DrugDetails_RefillNumber)
            return $http.post("api/Patients/UpdatePrescription",
            {
                'Prescription_ID': Prescription_ID,
                'Consultation_Diagnosis': Consultation_Diagnosis,
                'Prescription_DrugDetails_DrugName': Prescription_DrugDetails_DrugName,
                'Prescription_DrugDetails_Strength': Prescription_DrugDetails_Strength,
                'Prescription_DrugDetails_IntakeRoute': IntakeRoute,
                'Prescription_DrugDetails_Frequency': Frequency,
                'Prescription_DrugDetails_DispenseNumber': Prescription_DrugDetails_DispenseNumber,
                'Prescription_DrugDetails_RefillNumber': Prescription_DrugDetails_RefillNumber
            });
        };

        //Delete the Record
        var DeletePrescription = function (ID) {
            return $http.post("api/Patients/DeletePrescription/" + ID);
        };

        //---------------------------------------------------------------------------------------------------------/
        //Select Consultation Notes by PatientID
        var GetConsultationNotes = function (ID) {
            return $http.get("api/Patients/GetConsultationNotes/" + ID);
        }

        //Insert new record ##Patient_ID, Doctor_ID,
        var InsertConsultation = function (ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan, Presciption_ID, Referral_ID) {
            console.log(ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan, Presciption_ID, Referral_ID);
            return $http.post("api/Patients/InsertConsultation",
            {
                //'Consultation_Patient_ID': Patient_ID,
                //'Consultation_Doctor_ID': Doctor_ID,
                'Consultation_ReasonForConsultation': ReasonForConsultation,
                'Consultation_Symptoms': Symptoms,
                'Consultation_ClinicalFindings': ClinicalFindings,
                'Consultation_Diagnosis': Diagnosis,
                'Consultation_TestResultSummary': TestResultSummary,
                'Consultation_TreatmentPlan': TreatmentPlan,
                'Consultation_Presciption_ID': Presciption_ID,
                'Consultation_Referral_ID': Referral_ID
            });
        };

        //Update Employee
        var UpdateConsultationNote = function (Consultation_ID, ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan) {
            return $http.post("api/Patients/UpdateConsultationNote",
            {
                'Consultation_ID': Consultation_ID,
                'Consultation_ReasonForConsultation': ReasonForConsultation,
                'Consultation_Symptoms': Symptoms,
                'Consultation_ClinicalFindings': ClinicalFindings,
                'Consultation_Diagnosis': Diagnosis,
                'Consultation_TestResultSummary': TestResultSummary,
                'Consultation_TreatmentPlan': TreatmentPlan
            });
        };

        //Delete the Record
        var DeleteConsultationNote = function (ID) {
            return $http.post("api/Patients/DeleteConsultationNote/" + ID);
        };

        return {
            GetAllPatients: GetAllPatients,
            GetPatientByID: GetPatientByID,
            //InsertPractice: InsertPractice,
            //UpdatePractice: UpdatePractice,
            //DeletePractice: DeletePractice

            //Prescription Details
            GetMedicalRecord: GetMedicalRecord,
            InsertMedicalRecord: InsertMedicalRecord,
            UpdateMedicalRecord: UpdateMedicalRecord,
            DeleteMedicalRecord: DeleteMedicalRecord,

            //Prescription Details
            GetPrescription: GetPrescription,
            InsertPrescription: InsertPrescription,
            UpdatePrescription: UpdatePrescription,
            DeletePrescription: DeletePrescription,

            //Consultation Notes
            GetConsultationNotes: GetConsultationNotes,
            InsertConsultation: InsertConsultation,
            UpdateConsultationNote: UpdateConsultationNote,
            DeleteConsultationNote: DeleteConsultationNote            
        };
    }
);