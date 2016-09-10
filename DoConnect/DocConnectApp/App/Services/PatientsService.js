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

        //--Medical Record-----------------------------------------------------------------------------------------------------
        var GetMedical_Aid = function () {
            return $http.get("api/Patients/GetMedical_Aid");
        }

        //Select Medical Record by PatientID
        var GetMedicalRecord = function (ID) {
            return $http.get("api/Patients/GetMedicalRecord/" + ID);
        }

        //Insert new record
        var InsertMedicalRecord = function (Doctor_ID, FirstName, LastName, Email, ID_Number, Cell_Number, DOB, Gender, Street_Address, Suburb, City, Country, Patient_Medical_Aid_Medical_Aid_ID, Scheme_Name, Membership_Number, Registration_Date, Deregistration_Date, Allergies, PreviousMedication, PreviousIllnesses, RiskFactors, SocialHistory, FamilyHistory) {
            return $http.post("api/Patients/InsertMedicalRecord",
            {
                'Doctor_ID': Doctor_ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'Email': Email,
                'ID_Number': ID_Number,
                'Cell_Number': Cell_Number,
                'DOB': DOB,
                'Gender': Gender,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'Patient_Medical_Aid_Medical_Aid_ID': Patient_Medical_Aid_Medical_Aid_ID,
                'Scheme_Name': Scheme_Name,
                'Membership_Number': Membership_Number,
                'Registration_Date': Registration_Date,
                'Deregistration_Date': Deregistration_Date,
                'Allergies': Allergies,
                'PreviousIllnesses': PreviousIllnesses,
                'PreviousMedication': PreviousMedication,
                'RiskFactors': RiskFactors,
                'SocialHistory': SocialHistory,
                'FamilyHistory': FamilyHistory
            });
        };

        //Update MedicalRecord
        var UpdateMedicalRecord = function (Patient_ID, FirstName, LastName, Email, ID_Number, Cell_Number, DOB, Gender, Street_Address, Suburb, City, Country, Patient_Medical_Aid_Medical_Aid_ID, Scheme_Name, Membership_Number, Registration_Date, Deregistration_Date, Allergies, PreviousIllnesses, PreviousMedication, RiskFactors, SocialHistory, FamilyHistory) {
            return $http.post("api/Patients/UpdateMedicalRecord",
            {
                'Patient_ID': Patient_ID,
                'FirstName': FirstName,
                'LastName': LastName,
                'Email': Email,
                'ID_Number': ID_Number,
                'Cell_Number': Cell_Number,
                'DOB': DOB,
                'Gender': Gender,
                'Street_Address': Street_Address,
                'Suburb': Suburb,
                'City': City,
                'Country': Country,
                'Patient_Medical_Aid_Medical_Aid_ID': Patient_Medical_Aid_Medical_Aid_ID,
                'Scheme_Name': Scheme_Name,
                'Membership_Number': Membership_Number,
                'Registration_Date': Registration_Date,
                'Deregistration_Date': Deregistration_Date,
                'Allergies': Allergies,
                'PreviousIllnesses': PreviousIllnesses,
                'PreviousMedication': PreviousMedication,
                'RiskFactors': RiskFactors,
                'SocialHistory': SocialHistory,
                'FamilyHistory': FamilyHistory
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
        var InsertConsultation = function (Patient_ID, ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan, Presciption_ID, Referral_ID) {
            console.log(ReasonForConsultation, Symptoms, ClinicalFindings, Diagnosis, TestResultSummary, TreatmentPlan, Presciption_ID, Referral_ID);
            return $http.post("api/Patients/InsertConsultation",
            {
                'Consultation_Patient_ID': Patient_ID,
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

            //MedicalRecord Details
            GetMedical_Aid: GetMedical_Aid,
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