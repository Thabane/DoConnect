using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClient
{
    interface IDataLayer
    {
        #region User
        int CreateUser(int AccessLevel);
        string Login(string username, string password, int accessLevel);
        #endregion

        #region Consultation
        bool NewUpdateConsultation(int patient_ID, int doctor_ID, DateTime date, string reasonForConsulta, string symptoms, string clinicalFindings
            , string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID);
        Consultation GetConsultation(int id);
        List<Consultation> GetAllConsultations();
        bool DeleteConsultation(int id);
        #endregion

        #region Invoice
        bool NewUpdateInvoice(DateTime date, string invoiceSummary, string total, int medical_Aid_ID, int patient_ID, int doctor_ID);
        Invoice GetInvoice(int id);
        List<Invoice> GetAllInvoices();
        bool DeleteInvoice(int id);
        #endregion

        #region patient
        int NewUpdatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country);
        Patient GetPatient(int id);
        List<Patient> GetAllPatients();
        bool DeletePatient(int id);
        #endregion

        #region patient medical aid
        int NewUpdatePatient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID);
        Patient_Medical_Aid Get_Patient_Medical_Aid(int id);
        List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids();
        bool Delete_Patient_Medical_Aid(int id);
        #endregion

        #region practice
        int NewUpdatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        Practice GetPractice(int id);
        List<Practice> GetAllPractices();
        bool DeletePractice(int id);
        #endregion

        #region Prescription
        int NewUpdatePrescription(string description, DateTime date, int patient_ID, int doctor_ID);
        Prescription GetPrescription(int id);
        List<Prescription> GetAllPrescriptions();
        bool DeletePrescription(int id);
        #endregion

        #region Staff
        int NewUpdateStaff(string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone,
            string street_Address, string suburb, string city, string country, string employee_Type, int practice_ID, int user_ID);
        Staff GetStaff(int id);
        List<Staff> GetAllStaffMembers();
        bool DeleteStaff(int id);
        #endregion

        #region Doctor
        bool NewUpdateDoctor(Doctor doc, int UserId);
        #endregion
    }
}
