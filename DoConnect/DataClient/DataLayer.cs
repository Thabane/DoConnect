using ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClient
{
    public class DataLayer
    {
        private string _conn = @"Data Source=DESKTOP-6Gu3I3G\SQLEXPRESS;Initial Catalog=DoConnect;Integrated Security=True";
        private List<SqlParameter> _parameters;
        private DataAccess _dataAccess;
        #region user
        public int CreateUser()
        {
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[CreateUser]", new List<SqlParameter>()))
            {
                if (reader.Read())
                   userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            return userId;
        }
        #endregion

        #region patient
        public int CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country)
        {
            _dataAccess = new DataAccess();
            int userId = 0;
            _parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            cell_numberParameter.Value = cell_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            
            using (var reader = _dataAccess.ExecuteReader(_conn, "[CreatePatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
        }

        public Patient GetPatient(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            Patient patientInfo = new Patient();
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetPatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    return new Patient().Create(reader);
                    //patientInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    //patientInfo.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    //patientInfo.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    //patientInfo.ID_Number = reader.GetString(reader.GetOrdinal("ID_Number"));
                    //patientInfo.Gender = reader.GetString(reader.GetOrdinal("Gender"));
                    //patientInfo.DOB = reader.GetDateTime(reader.GetOrdinal("DOB"));
                    //patientInfo.Cell_Number = reader.GetString(reader.GetOrdinal("Cell_Number"));
                    //patientInfo.Street_Address = reader.GetString(reader.GetOrdinal("Street_Address"));
                    //patientInfo.Suburb = reader.GetString(reader.GetOrdinal("Suburb"));
                    //patientInfo.City = reader.GetString(reader.GetOrdinal("City"));
                    //patientInfo.Country = reader.GetString(reader.GetOrdinal("Country"));
                }
            }
            return patientInfo;
        }

        public List<Patient> GetAllPatients()
        {
            _dataAccess = new DataAccess();
            List<Patient> patientInfo = new List<Patient>();
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetAllPatients]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    patientInfo.Add(new Patient().Create(reader));
                }
            }
            return patientInfo;
        }

        public bool DeletePatient(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[DeletePatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdatePatient(int id, string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            idParameter.Value = id;
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            cell_numberParameter.Value = cell_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            _parameters.Add(idParameter);
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);

            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[UpdatePatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region patient medical aid
        public int Create_Patient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter scheme_nameParameter = new SqlParameter("@Scheme_Name", SqlDbType.NVarChar);
            SqlParameter member_numberParameter = new SqlParameter("@Membership_Number", SqlDbType.NVarChar);
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit);
            SqlParameter registration_dateParameter = new SqlParameter("@Registration_Date", SqlDbType.DateTime);
            SqlParameter deregistrationParameter = new SqlParameter("@Deregistration_Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            scheme_nameParameter.Value = scheme_name;
            member_numberParameter.Value = member_number;
            statusParameter.Value = status;
            registration_dateParameter.Value = registration_date;
            deregistrationParameter.Value = deregistration;
            patient_IDParameter.Value = patient_ID;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            _parameters.Add(scheme_nameParameter);
            _parameters.Add(member_numberParameter);
            _parameters.Add(statusParameter);
            _parameters.Add(registration_dateParameter);
            _parameters.Add(deregistrationParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(medical_Aid_IDParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[Create_Patient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
        }

        public Patient_Medical_Aid Get_Patient_Medical_Aid(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            Patient_Medical_Aid patientMedicalAidInfo = new Patient_Medical_Aid();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[Get_Patient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return patientMedicalAidInfo;
        }

        public List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids()
        {
            _dataAccess = new DataAccess();
            List<Patient_Medical_Aid> patientInfo = new List<Patient_Medical_Aid>();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetAll_Patient_Medical_Aids]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return patientInfo;
        }

        public bool Delete_Patient_Medical_Aid(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[Delete_Patient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool Update_Patient_Medical_Aid(int id, string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter scheme_nameParameter = new SqlParameter("@Scheme_Name", SqlDbType.NVarChar);
            SqlParameter member_numberParameter = new SqlParameter("@Membership_Number", SqlDbType.NVarChar);
            SqlParameter statusParameter = new SqlParameter("@Status", SqlDbType.Bit);
            SqlParameter registration_dateParameter = new SqlParameter("@Registration_Date", SqlDbType.DateTime);
            SqlParameter deregistrationParameter = new SqlParameter("@Deregistration_Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            idParameter.Value = id;
            scheme_nameParameter.Value = scheme_name;
            member_numberParameter.Value = member_number;
            statusParameter.Value = status;
            registration_dateParameter.Value = registration_date;
            deregistrationParameter.Value = deregistration;
            patient_IDParameter.Value = patient_ID;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            _parameters.Add(idParameter);
            _parameters.Add(scheme_nameParameter);
            _parameters.Add(member_numberParameter);
            _parameters.Add(statusParameter);
            _parameters.Add(registration_dateParameter);
            _parameters.Add(deregistrationParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[Update_Patient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region practice
        public int CreatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.Int);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter fax_numberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter latitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter longitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);
            nameParameter.Value = name;
            cell_numberParameter.Value = cell_number;
            fax_numberParameter.Value = fax_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            latitudeParameter.Value = latitude;
            longitudeParameter.Value = longitude;
            trading_TimesParameter.Value = trading_Times;
            _parameters.Add(nameParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);

            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[CreatePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
        }

        public Practice GetPractice(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            Practice patientMedicalAidInfo = new Practice();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetPractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return patientMedicalAidInfo;
        }

        public List<Practice> GetAllPractices()
        {
            _dataAccess = new DataAccess();
            List<Practice> patientInfo = new List<Practice>();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetAllPractices]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return patientInfo;
        }

        public bool DeletePractice(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[DeletePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.Int);
            SqlParameter cell_numberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter fax_numberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter street_addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter latitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter longitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);
            idParameter.Value = id;
            nameParameter.Value = name;
            cell_numberParameter.Value = cell_number;
            fax_numberParameter.Value = fax_number;
            street_addressParameter.Value = street_address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            latitudeParameter.Value = latitude;
            longitudeParameter.Value = longitude;
            trading_TimesParameter.Value = trading_Times;
            _parameters.Add(idParameter);
            _parameters.Add(nameParameter);
            _parameters.Add(cell_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[UpdatePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Prescription
        public int CreatePrescription(string description, DateTime date, int patient_ID, int doctor_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter descriptionParameter = new SqlParameter("@Description", SqlDbType.VarChar);
            SqlParameter dateParamerter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            descriptionParameter.Value = description;
            dateParamerter.Value = date;
            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;
            _parameters.Add(descriptionParameter);
            _parameters.Add(dateParamerter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[CreatePrescription]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
        }

        public Prescription GetPrescription(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            Prescription prescriptionInfo = new Prescription();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetPrescription]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return prescriptionInfo;
        }

        public List<Prescription> GetAllPrescriptions()
        {
            _dataAccess = new DataAccess();
            List<Prescription> prescriptionInfo = new List<Prescription>();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetAllPrescriptions]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return prescriptionInfo;
        }

        public bool DeletePrescription(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[DeletePrescription]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdatePrescription(int id, string description, DateTime date, int patient_ID, int doctor_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@", SqlDbType.Int);
            SqlParameter descriptionParameter = new SqlParameter("@Description", SqlDbType.VarChar);
            SqlParameter dateParamerter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            idParameter.Value = id;
            descriptionParameter.Value = description;
            dateParamerter.Value = date;
            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;
            _parameters.Add(idParameter);
            _parameters.Add(descriptionParameter);
            _parameters.Add(dateParamerter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[UpdatePrescription]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Staff
        public int CreateStaff(string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone, string employee_Type, int practice_ID, int user_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter employee_TypeParameter = new SqlParameter("@Employee_Type", SqlDbType.NVarChar);
            SqlParameter practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter user_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            phoneParameter.Value = phone;
            employee_TypeParameter.Value = employee_Type;
            practice_IDParameter.Value = practice_ID;
            user_IDParameter.Value = user_ID;
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(phoneParameter);
            _parameters.Add(employee_TypeParameter);
            _parameters.Add(practice_IDParameter);
            _parameters.Add(user_IDParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[CreateStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return userId;
        }

        public Staff GetStaff(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            Staff staffInfo = new Staff();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return staffInfo;
        }

        public List<Staff> GetAllStaffMembers()
        {
            _dataAccess = new DataAccess();
            List<Staff> staffInfo = new List<Staff>();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[GetAllStaffMembers]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return staffInfo;
        }

        public bool DeleteStaff(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[DeleteStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdateStaff(int id, string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone, string employee_Type, int practice_ID, int user_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter employee_TypeParameter = new SqlParameter("@Employee_Type", SqlDbType.NVarChar);
            SqlParameter practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter user_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            idParameter.Value = id;
            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            phoneParameter.Value = phone;
            employee_TypeParameter.Value = employee_Type;
            practice_IDParameter.Value = practice_ID;
            user_IDParameter.Value = user_ID;
            _parameters.Add(idParameter);
            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(phoneParameter);
            _parameters.Add(employee_TypeParameter);
            _parameters.Add(practice_IDParameter);
            _parameters.Add(user_IDParameter);
            _dataAccess = new DataAccess();
            int userId = 0;
            using (var reader = _dataAccess.ExecuteReader(_conn, "[UpdateStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion
    }
}
