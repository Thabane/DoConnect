using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel;

namespace DataClient
{
    public interface IDataLayer
    {
        #region User
        int CreateUser(int AccessLevel);
        string Login(string username, string password, int accessLevel);
        Login MyLogin(string Email, string Password);
        Staff GetUserDetailsByUser_ID(int User_ID);
        List<AccessLevel> GetAllAccessLevel();
        AccessLevel GetAccessLevelById(int id);
        #endregion

        #region Expense
        List<Expenses> GetAllExpenses();
        Expenses GetExpenseById(int ID);
        Expenses GetPracticeIDByUser_ID(int User_ID);
        bool NewExpense(string Description, string Date, string Amount, int Practice_ID, int User_ID);
        bool UpdateExpense(int ID, string Description, string Amount);
        bool DeleteExpense(int id);
        #endregion

        #region Appointments
        List<Appointments> GetAppointments();
        Appointments GetAppointmentById(int AppId);
        bool NewAppointment(string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID);
        bool UpdateAppointment(int ID, string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID);
        #endregion

        #region Consultation
        List<Consultation> GetAllConsultations();
        List<Consultation> GetConsultationByPatientId(int id);
        bool NewConsultationNote(int patient_ID, int doctor_ID, string reasonForConsulta, string symptoms, string clinicalFindings, string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID);
        bool UpdateConsultationNote(int consultationID, string reasonForConsulta, string symptoms, string clinicalFindings, string diagnosis, string testResultSummary, string treatmentPlan);
        bool DeleteConsultation(int id);
        #endregion

        #region Invoice
        List<Invoice> GetAllInvoices();
        Invoice GetInvoiceById(int ID);
        List<GetAllPatients> GetAllPatientsForInvoice();
        List<Invoice> GetAllDiagnosisByPatientID(int ID);
        bool NewInvoice(string InvoiceSummary, decimal Total, decimal AmountPaid, int Medical_Aid_ID, int Patient_ID, int Doctor_ID);
        bool DeleteInvoice(int id);
        #endregion

        #region patient
        int NewUpdatePatient(string firstName, string lastName, string id_Number, string gender, string dob, string cell_number, string street_address, string suburb, string city, string country);
        bool CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory, int Medical_Aid_ID, int Doctor_ID, int UserId);
        List<GetAllPatients> GetAllPatients();
        List<Patient> GetPatientByID(int id);
        bool DeletePatient(int id);
        #endregion

        #region patient medical aid
        int Create_Patient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID);
        List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids();
        Patient_Medical_Aid Get_Patient_Medical_AidById(int id);
        int NewUpdatePatient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID);
        bool Delete_Patient_Medical_Aid(int id);
        #endregion

        #region practice		
        int NewUpdatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        int CreatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        List<Practice> GetAllPractices();
        Practice GetPracticeById(int id);
        bool InsertPractice(string Name, string Phone_Number, string Fax_Number, string Street_Address, string Suburb, string City, string Country, string Latitude, string Longitude, string Trading_Times);
        bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        bool DeletePractice(int id);
        #endregion

        #region Medical Record
        List<Medical_Aid> GetMedical_Aid();
        MedicalRecord GetMedicalRecordByPatientID(int id);
        bool NewMedicalRecord(int Doctor_ID, string FirstName, string LastName, string Email, string ID_Number, string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country, int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date, string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory);
        bool UpdateMedicalRecord(int Patient_ID, string FirstName, string LastName, string Email, string ID_Number, string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country, int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date, string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory);
        #endregion

        #region Prescription 
        List<Prescription> GetPrescriptionByPatientID(int id);
        bool NewPrescription(int Patient_ID, int Doctor_ID, int Consultation_ID, string DrugName, string Strength, string IntakeRoute, string Frequency, int DispenseNumber, int RefillNumber);
        bool UpdatePrescription(int Prescription_ID, string Diagnosis, string DrugName, string Strength, string IntakeRoute, string Frequency, int DispenseNumber, int RefillNumber);
        bool DeletePrescription(int id);
        #endregion

        #region Staff

        List<Staff> GetAllStaff();
        Staff GetStaffById(int id);
        int GetNewUserID();
        bool InsertStaff(string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, int ACCESSLEVEL_ID, string employee_Type, int practice_ID, int User_ID, string Email);
        bool UpdateStaff(int ID, string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, string employee_Type, int practice_ID, string Email);
        bool DeleteStaff(int id);
        #endregion

        #region Doctor
        bool NewUpdateDoctor(Doctor doc, int UserId);
        List<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int UserId);
        #endregion

        #region Medicine_Inventory
        List<Medicine_Inventory> GetAllMedicine_Inventory();
        Medicine_Inventory GetMedicine_InventoryById(int ID);
        bool NewMedicine_Inventory(string DrugName, string Description, int QuantityPurchased, string PurchaseDate, string ExpiryDate, string DrugConcentration, int Practice_ID);
        bool UpdateMedicine_Inventory(int ID, string DrugName, string Description, int QuantityInStock, string DrugConcentration);
        bool DeleteMedicine_Inventory(int ID);
        #endregion

        #region Medical Aid
        List<Medical_Aid> GetAllMedicalAids();
        Medical_Aid GetMedicalAidById(int ID);
        bool NewMedicalAid(string Name, string Cell_Number, string Fax_Number, string Email_Address, string Address);
        bool UpdateMedicalAid(int ID, string Name, string Cell_Number, string Fax_Number, string Email_Address, string Address);
        bool DeleteMedicalAid(int ID);
        #endregion

        #region Messages
        List<Messages> GetAllMessages(int Receiver);
        Messages GetMessageById(int ID);
        bool NewMessages(int Sender, int Receiver, string Subject, string Description, string Date);
        bool DeleteMessages(int ID);
        #endregion

        #region Dashboard        
        Invoice GetRevenueSummary_Today(int Practice_ID);
        Invoice GetRevenueSummary_Week(int Practice_ID);
        Invoice GetNumPatientsByPractice(int Practice_ID);
        #endregion
    }
}
