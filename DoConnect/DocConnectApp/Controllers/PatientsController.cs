using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataClient;

namespace DocConnectApp.Controllers
{
    public class PatientsController : ApiController
    {
        [HttpGet]
        [Route("api/Patients/GetAllPatients")]
        public List<GetAllPatients> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();
        }

        [HttpGet]
        [Route("api/Patients/GetPatient/{ID}")]
        public List<Patient> GetPatientByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPatientByID(ID);
        }

        [HttpPost]
        [Route("api/Patients/DeletePatient/{ID}")]
        public bool DeletePatient(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeletePatient(ID);
        }

        //--Medical Record----------------------------------------------------------------------------------------------------------------/

        [HttpGet]
        [Route("api/Patients/GetMedical_Aid")]
        public List<Medical_Aid> GetMedical_Aid()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedical_Aid();
        }

        [HttpGet]
        [Route("api/Patients/GetMedicalRecord/{ID}")]
        public MedicalRecord GetMedicalRecord(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedicalRecordByPatientID(ID);
        }

        [HttpGet]
        [Route("api/Patients/GetProfileByPatientID/{ID}")]
        public MedicalRecord GetProfileByPatientID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetProfileByPatientID(ID);
        }

        [HttpPost]
        [Route("api/Patients/InsertMedicalRecord")]
        public bool InsertMedicalRecord(MedicalRecord medicalRecord)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewMedicalRecord(medicalRecord.Doctor_ID, medicalRecord.FirstName, medicalRecord.LastName, medicalRecord.Email, medicalRecord.ID_Number, medicalRecord.Cell_Number, medicalRecord.DOB, medicalRecord.Gender, medicalRecord.Street_Address, medicalRecord.Suburb, medicalRecord.City, medicalRecord.Country, medicalRecord.Patient_Medical_Aid_Medical_Aid_ID, medicalRecord.Scheme_Name, medicalRecord.Membership_Number, medicalRecord.Registration_Date, medicalRecord.Deregistration_Date, medicalRecord.Allergies, medicalRecord.PreviousMedication, medicalRecord.PreviousIllnesses, medicalRecord.RiskFactors, medicalRecord.SocialHistory, medicalRecord.FamilyHistory);
        }

        [HttpPost]
        [Route("api/Patients/UpdateMedicalRecord")]
        public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateMedicalRecord(medicalRecord.Patient_ID, medicalRecord.FirstName, medicalRecord.LastName, medicalRecord.Email, medicalRecord.ID_Number, medicalRecord.Cell_Number, medicalRecord.DOB, medicalRecord.Gender, medicalRecord.Street_Address, medicalRecord.Suburb, medicalRecord.City, medicalRecord.Country, medicalRecord.Patient_Medical_Aid_Medical_Aid_ID, medicalRecord.Scheme_Name, medicalRecord.Membership_Number, medicalRecord.Registration_Date, medicalRecord.Deregistration_Date, medicalRecord.Allergies, medicalRecord.PreviousIllnesses, medicalRecord.PreviousMedication, medicalRecord.RiskFactors, medicalRecord.SocialHistory, medicalRecord.FamilyHistory);
        }
        //--Prescription Details----------------------------------------------------------------------------------------------------------------/

        [HttpGet]
        [Route("api/Patients/GetPrescription/{ID}")]
        public List<Prescription> GetPrescription(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPrescriptionByPatientID(ID);
        }

        [HttpPost]
        [Route("api/Patients/InsertPrescription")]
        public bool InsertPrescription(Prescription prescription)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewPrescription(prescription.Patient_ID, prescription.Doctors_ID, prescription.Consultation_ID, prescription.Prescription_DrugDetails_DrugName, prescription.Prescription_DrugDetails_Strength, prescription.Prescription_DrugDetails_IntakeRoute, prescription.Prescription_DrugDetails_Frequency, prescription.Prescription_DrugDetails_DispenseNumber, prescription.Prescription_DrugDetails_RefillNumber);
        }

        [HttpPost]
        [Route("api/Patients/UpdatePrescription")]
        public bool UpdatePrescription(Prescription prescription)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdatePrescription(prescription.Prescription_ID, prescription.Consultation_Diagnosis, prescription.Prescription_DrugDetails_DrugName, prescription.Prescription_DrugDetails_Strength, prescription.Prescription_DrugDetails_IntakeRoute, prescription.Prescription_DrugDetails_Frequency, prescription.Prescription_DrugDetails_DispenseNumber, prescription.Prescription_DrugDetails_RefillNumber);
        }

        [HttpPost]
        [Route("api/Patients/DeletePrescription/{ID}")]
        public bool DeletePrescription(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeletePrescription(ID);
        }

        //--Consultation Notes----------------------------------------------------------------------------------------------------------------/

        [HttpGet]
        [Route("api/Patients/GetConsultationNotes/{ID}")]
        public List<Consultation> GetConsultationNotes(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetConsultationByPatientId(ID);
        }

        [HttpPost]
        [Route("api/Patients/InsertConsultation")]
        public bool InsertConsultation(Consultation consultation)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewConsultationNote(consultation.Consultation_Patient_ID, 4, consultation.Consultation_ReasonForConsultation, consultation.Consultation_Symptoms, consultation.Consultation_ClinicalFindings, consultation.Consultation_Diagnosis, consultation.Consultation_TestResultSummary, consultation.Consultation_TreatmentPlan, consultation.Consultation_Presciption_ID, consultation.Consultation_Referral_ID);
        }

        [HttpPost]
        [Route("api/Patients/UpdateConsultationNote")]
        public bool UpdateConsultationNote(Consultation consultation)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateConsultationNote(consultation.Consultation_ID, consultation.Consultation_ReasonForConsultation, consultation.Consultation_Symptoms, consultation.Consultation_ClinicalFindings, consultation.Consultation_Diagnosis, consultation.Consultation_TestResultSummary, consultation.Consultation_TreatmentPlan);
        }

        [HttpPost]
        [Route("api/Patients/UpdateConsultation_AddAdditionalFee")]
        public bool UpdateConsultation_AddAdditionalFee(Consultation consultation)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateConsultation_AddAdditionalFee(consultation.Additionalfee, consultation.InvoiceDocMessage);
        }

        [HttpPost]
        [Route("api/Patients/DeleteConsultationNote/{ID}")]
        public bool DeleteConsultationNote(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteConsultation(ID);
        }
    }
}
