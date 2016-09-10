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
        [Route("api/Patients/UpdatePatient")]
        public bool UpdatePatient(Patient patient)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdatePatient(patient.User_ID, patient.FirstName, patient.LastName, patient.ID_Number, patient.Gender, patient.DOB, patient.Cell_Number, patient.Street_Address, patient.Suburb, patient.City, patient.Country,patient.Allergies, patient.PreviousIllnesses, patient.PreviousMedication, patient.RiskFactors, patient.SocialHistory, patient.FamilyHistory,patient.Medical_Aid_ID, patient.Doctor_ID);
        }

        /*[HttpPost]
        [Route("api/Patients/InsertPatient")]
        public bool InsertPatient(Patient practice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertPatient(practice.Name, practice.Phone_Number, practice.Fax_Number, practice.Street_Address, practice.Suburb, practice.City, practice.Country, "yu", "uy", practice.Trading_Times);
        }*/

        [HttpPost]
        [Route("api/Patients/DeletePatient/{ID}")]
        public bool DeletePatient(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeletePatient(ID);
        }

        //--Medical Record----------------------------------------------------------------------------------------------------------------/

        [HttpGet]
        [Route("api/Patients/GetMedicalRecord/{ID}")]
        public List<MedicalRecord> GetMedicalRecord(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedicalRecordByPatientID(ID);
        }

        [HttpPost]
        [Route("api/Patients/InsertMedicalRecord")]
        public bool InsertMedicalRecord(MedicalRecord medicalRecord)
        {
            DataLayer dtLayer = new DataLayer();
            //return dtLayer.NewMedicalRecord();
            return true;
        }

        [HttpPost]
        [Route("api/Patients/UpdateMedicalRecord")]
        public bool UpdateMedicalRecord(MedicalRecord medicalRecord)
        {
            DataLayer dtLayer = new DataLayer();
            //return dtLayer.UpdateMedicalRecord();
            return true;
        }

        [HttpPost]
        [Route("api/Patients/DeleteMedicalRecord/{ID}")]
        public bool DeleteMedicalRecord(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            //return dtLayer.DeleteMedicalRecord(ID);
            return true;
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
            return dtLayer.DeleteConsultation(ID);
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
            
            //return dtLayer.NewConsultationNote(consultation.Consultation_Patient_ID, consultation.Consultation_Doctor_ID, consultation.Consultation_ReasonForConsultation, consultation.Consultation_Symptoms, consultation.Consultation_ClinicalFindings, consultation.Consultation_Diagnosis, consultation.Consultation_TestResultSummary, consultation.Consultation_TreatmentPlan, consultation.Consultation_Presciption_ID, consultation.Consultation_Referral_ID);
            return dtLayer.NewConsultationNote(1, 4, consultation.Consultation_ReasonForConsultation, consultation.Consultation_Symptoms, consultation.Consultation_ClinicalFindings, consultation.Consultation_Diagnosis, consultation.Consultation_TestResultSummary, consultation.Consultation_TreatmentPlan, consultation.Consultation_Presciption_ID, consultation.Consultation_Referral_ID);
        }

        [HttpPost]//Update Employee
        [Route("api/Patients/UpdateConsultationNote")]
        public bool UpdateConsultationNote(Consultation consultation)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateConsultationNote(consultation.Consultation_ID, consultation.Consultation_ReasonForConsultation, consultation.Consultation_Symptoms, consultation.Consultation_ClinicalFindings, consultation.Consultation_Diagnosis, consultation.Consultation_TestResultSummary, consultation.Consultation_TreatmentPlan);
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
