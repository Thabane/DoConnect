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
        int CreateUser(int AccessLevel);
        void CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country, int UserId);
        bool NewUpdateDoctor(Doctor doc, int UserId);
        Patient GetPatient(int id);
        Doctor GetDoctor(int DocID);
        List<Patient> GetAllPatients();
        bool DeletePatient(int id);
        bool UpdatePatient(int id, string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country);
        int Create_Patient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID);
        Patient_Medical_Aid Get_Patient_Medical_Aid(int id);
        List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids();
        bool Delete_Patient_Medical_Aid(int id);
        bool Update_Patient_Medical_Aid(int id, string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID);
        int CreatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        Practice GetPractice(int id);
        List<Practice> GetAllPractices();
        bool DeletePractice(int id);
        bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times);
        int CreatePrescription(string description, DateTime date, int patient_ID, int doctor_ID);
        Prescription GetPrescription(int id);
        List<Prescription> GetAllPrescriptions();
        bool DeletePrescription(int id);
        bool UpdatePrescription(int id, string description, DateTime date, int patient_ID, int doctor_ID);
        int CreateStaff(string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone, string employee_Type, int practice_ID, int user_ID);
        Staff GetStaff(int id);
        List<Staff> GetAllStaffMembers();
        bool DeleteStaff(int id);
        bool UpdateStaff(int id, string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone, string employee_Type, int practice_ID, int user_ID);
        SystemUser Login(string email, string password, int AccessLevel);
    }
}
