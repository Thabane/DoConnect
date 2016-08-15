using ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataClient
{
    public class DataLayer : IDataLayer
    {
        private DataAccess access;
        private List<SqlParameter> _parameters = new List<SqlParameter>();
        private string Conn = "DB";

        public DataLayer()
        {
            access = new DataAccess();
        }

        public int CreateUser(int AccessLevel)
        {
            int userId = 0;
            SqlParameter levelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            levelParameter.Value = AccessLevel;

            using (var reader = access.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>() { levelParameter }))
            {
                if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            access.LogEntry(userId, "New User Created");
            return userId;
        }

        #region patient
        public void CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country, int UserId)
        {

            //state params
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
            SqlParameter userIdParameter = new SqlParameter("@@User_ID", SqlDbType.NVarChar);
            //assign values
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
            userIdParameter.Value = UserId;
            //add to list
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
            _parameters.Add(userIdParameter);

            try
            {
                access.ExecuteNonQuery(Conn, _parameters, "[NewUpdatePatient]");
                access.LogEntry(UserId, "Created Patient");
            }
            catch (Exception ex)
            {
                access.LogEntry(UserId, ex.ToString());
            }                  
            
        }

        public bool NewUpdateDoctor(Doctor doc, int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter addressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);
            SqlParameter practiceIdParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            SqlParameter userIdParameter = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter jobTitleParameter = new SqlParameter("@JobTitle", SqlDbType.NVarChar);

            firstNameParameter.Value = doc.FirstName;
            parameters.Add(firstNameParameter);
            lastNameParameter.Value = doc.LastName;
            parameters.Add(lastNameParameter);
            genderParameter.Value = doc.Gender;
            parameters.Add(genderParameter);
            addressParameter.Value = doc.Address;
            parameters.Add(addressParameter);
            practiceIdParameter.Value = doc.PracticeId;
            parameters.Add(practiceIdParameter);
            userIdParameter.Value = doc.UserId;
            parameters.Add(userIdParameter);
            jobTitleParameter.Value = doc.Job_Title;
            parameters.Add(jobTitleParameter);

            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[NewUpdateDoctor]");
                access.LogEntry(UserId, "User Added new Doctor");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(UserId, ex.ToString());
                return false;
            }
            //return false;
        }

        public Patient GetPatient(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Patient patientInfo = new Patient();
            using (var reader = access.ExecuteReader(Conn, "[GetPatient]", new List<SqlParameter>()))
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
            List<Patient> patientInfo = new List<Patient>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllPatients]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeletePatient]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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

            
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdatePatient]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[Create_Patient_Medical_Aid]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Patient_Medical_Aid patientMedicalAidInfo = new Patient_Medical_Aid();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[Get_Patient_Medical_Aid]", new List<SqlParameter>()))
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
            List<Patient_Medical_Aid> patientInfo = new List<Patient_Medical_Aid>();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetAll_Patient_Medical_Aids]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[Delete_Patient_Medical_Aid]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[Update_Patient_Medical_Aid]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[CreatePractice]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Practice patientMedicalAidInfo = new Practice();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetPractice]", new List<SqlParameter>()))
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
            List<Practice> patientInfo = new List<Practice>();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetAllPractices]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeletePractice]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdatePractice]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[CreatePrescription]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Prescription prescriptionInfo = new Prescription();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetPrescription]", new List<SqlParameter>()))
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
            List<Prescription> prescriptionInfo = new List<Prescription>();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetAllPrescriptions]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeletePrescription]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdatePrescription]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[CreateStaff]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Staff staffInfo = new Staff();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetStaff]", new List<SqlParameter>()))
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
            List<Staff> staffInfo = new List<Staff>();
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[GetAllStaffMembers]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[DeleteStaff]", new List<SqlParameter>()))
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
            List<SqlParameter> _parameters = new List<SqlParameter>();
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
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdateStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public Doctor GetDoctor(int DocID)
        {
            return null;
        }
        #endregion

        public bool Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return true;
            }
            return false;
        }
    }
}
