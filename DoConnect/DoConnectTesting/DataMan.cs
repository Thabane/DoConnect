using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClient;
using ObjectModel;

namespace DoConnectTesting
{
    class DataMan : IDataLayer
    {
        public int CreateUser(int AccessLevel)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            string user = "Bongani";
            string pass = "12345";

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (username == user && password == pass)
                {
                    return true;
                }
                if (username == user && password != pass)
                {
                    return false;
                }
                if (username != user)
                {
                    return false;
                }
                return false;
            }

            return false;

        }

        public Login MyLogin(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public Staff GetUserDetailsByUser_ID(int User_ID)
        {
            throw new NotImplementedException();
        }

        public List<AccessLevel> GetAllAccessLevel()
        {
            throw new NotImplementedException();
        }

        public AccessLevel GetAccessLevelById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointments> GetAppointments()
        {
            throw new NotImplementedException();
        }

        public Appointments GetAppointmentById(int AppId)
        {
            throw new NotImplementedException();
        }

        public bool NewAppointment(string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAppointment(int ID, string Date_Time, int Patient_ID, string Details, int App_Status, int DoctorID)
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetAllConsultations()
        {
            throw new NotImplementedException();
        }

        public List<Consultation> GetConsultationByPatientId(int id)
        {
            throw new NotImplementedException();
        }

        public bool NewConsultationNote(int patient_ID, int doctor_ID, string reasonForConsulta, string symptoms,
            string clinicalFindings, string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID,
            int referral_ID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateConsultationNote(int consultationID, string reasonForConsulta, string symptoms, string clinicalFindings,
            string diagnosis, string testResultSummary, string treatmentPlan)
        {
            throw new NotImplementedException();
        }

        public bool DeleteConsultation(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAllInvoices()
        {
            throw new NotImplementedException();
        }

        public Invoice GetInvoiceById(int id)
        {
            throw new NotImplementedException();
        }

        public bool NewUpdateInvoice(DateTime date, string invoiceSummary, string total, int medical_Aid_ID, int patient_ID,
            int doctor_ID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public int NewUpdatePatient(string firstName, string lastName, string id_Number, string gender, string dob, string cell_number,
            string street_address, string suburb, string city, string country)
        {
            throw new NotImplementedException();
        }

        public bool CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number,
            string street_address, string suburb, string city, string country, string Allergies, string PreviousIllnesses,
            string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory, int Medical_Aid_ID,
            int Doctor_ID, int UserId)
        {
            throw new NotImplementedException();
        }

        public List<GetAllPatients> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetPatientByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePatient(int id, string firstName, string lastName, string id_Number, string gender, string dob,
            string cell_number, string street_address, string suburb, string city, string country, string Allergies,
            string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory,
            int Medical_Aid_ID, int Doctor_ID)
        {
            throw new NotImplementedException();
        }

        public bool DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public int Create_Patient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date,
            DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            throw new NotImplementedException();
        }

        public List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids()
        {
            throw new NotImplementedException();
        }

        public Patient_Medical_Aid Get_Patient_Medical_AidById(int id)
        {
            throw new NotImplementedException();
        }

        public int NewUpdatePatient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date,
            DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            throw new NotImplementedException();
        }

        public bool Delete_Patient_Medical_Aid(int id)
        {
            throw new NotImplementedException();
        }

        public int NewUpdatePractice(string name, string cell_number, string fax_number, string street_address, string suburb,
            string city, string country, string latitude, string longitude, string trading_Times)
        {
            throw new NotImplementedException();
        }

        public int CreatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city,
            string country, string latitude, string longitude, string trading_Times)
        {
            throw new NotImplementedException();
        }

        public List<Practice> GetAllPractices()
        {
            throw new NotImplementedException();
        }

        public Practice GetPracticeById(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertPractice(string Name, string Phone_Number, string Fax_Number, string Street_Address, string Suburb,
            string City, string Country, string Latitude, string Longitude, string Trading_Times)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb,
            string city, string country, string latitude, string longitude, string trading_Times)
        {
            throw new NotImplementedException();
        }

        public bool DeletePractice(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medical_Aid> GetMedical_Aid()
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetMedicalRecordByPatientID(int id)
        {
            throw new NotImplementedException();
        }

        public bool NewMedicalRecord(int Doctor_ID, string FirstName, string LastName, string Email, string ID_Number,
            string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country,
            int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date,
            string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication,
            string RiskFactors, string SocialHistory, string FamilyHistory)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMedicalRecord(int Patient_ID, string FirstName, string LastName, string Email, string ID_Number,
            string Cell_Number, string DOB, string Gender, string Street_Address, string Suburb, string City, string Country,
            int Patient_Medical_Aid_Medical_Aid_ID, string Scheme_Name, string Membership_Number, string Registration_Date,
            string Deregistration_Date, string Allergies, string PreviousIllnesses, string PreviousMedication,
            string RiskFactors, string SocialHistory, string FamilyHistory)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetPrescriptionByPatientID(int id)
        {
            throw new NotImplementedException();
        }

        public bool NewPrescription(int Patient_ID, int Doctor_ID, int Consultation_ID, string DrugName, string Strength,
            string IntakeRoute, string Frequency, int DispenseNumber, int RefillNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePrescription(int Prescription_ID, string Diagnosis, string DrugName, string Strength, string IntakeRoute,
            string Frequency, int DispenseNumber, int RefillNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeletePrescription(int id)
        {
            throw new NotImplementedException();
        }

        public List<Staff> GetAllStaff()
        {
            throw new NotImplementedException();
        }

        public Staff GetStaffById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNewUserID()
        {
            throw new NotImplementedException();
        }

        public bool InsertStaff(string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, int ACCESSLEVEL_ID, string employee_Type,
            int practice_ID, int User_ID, string Email)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStaff(int ID, string firstName, string lastName, string id_Number, string gender, string dob, string phone,
            string street_Address, string suburb, string city, string country, string employee_Type, int practice_ID,
            string Email)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStaff(int id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(int UserId)
        {
            throw new NotImplementedException();
        }

        public bool NewUpdateMedicine_Inventory(Medicine_Inventory inventory, int UserId)
        {
            throw new NotImplementedException();
        }

        public bool NewUpdateDoctor(Doctor doc, int UserId)
        {
            throw new NotImplementedException();
        }

        public bool NewUpdateExpense(Expenses expense, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
