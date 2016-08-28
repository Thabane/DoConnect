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
        #region defaults
        DataAccess _access;
        List<SqlParameter> _parameters;
        string _con = string.Empty;

        public DataLayer()
        {
            _con = ConfigurationManager.AppSettings["DB"];
            _access = new DataAccess();
        }
        #endregion

        #region User
        public int CreateUser(int accessLevel)
        {
            DataAccess da = new DataAccess();
            int userId = 0;

            SqlParameter levelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            levelParameter.Value = accessLevel;

            using (var reader = _access.ExecuteReader(_con, "[CreateUser]", new List<SqlParameter>() { levelParameter }))
            {
                if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            return userId;
        }

        public string Login(string username, string password, int accessLevel)
        {
            int userId = 0;
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter accessLevelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            accessLevelParameter.Value = accessLevel;
            _parameters.Add(accessLevelParameter);

            using (var reader = _access.ExecuteReader(_con, "[CreateUser]", _parameters))
            {
                if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            _access.LogEntry(userId, "New User Created");
            return "";
        }
        #endregion

        #region Consultation
        public bool NewUpdateConsultation(int patient_ID, int doctor_ID, DateTime date, string reasonForConsulta, string symptoms, string clinicalFindings
            , string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter reasonForConsultaParameter = new SqlParameter("@ReasonForConsultation", SqlDbType.NVarChar);
            SqlParameter symptomsParameter = new SqlParameter("@Symptoms", SqlDbType.NVarChar);
            SqlParameter clinicalFindingsParameter = new SqlParameter("@ClinicalFindings", SqlDbType.NVarChar);
            SqlParameter diagnosisParameter = new SqlParameter("@Diagnosis", SqlDbType.NVarChar);
            SqlParameter testResultSummaryParameter = new SqlParameter("@TestResultSummary", SqlDbType.NVarChar);
            SqlParameter treatmentPlanParameter = new SqlParameter("@TreatmentPlan", SqlDbType.NVarChar);
            SqlParameter presciption_IDParameter = new SqlParameter("@Presciption_ID", SqlDbType.Int);
            SqlParameter referral_IDParameter = new SqlParameter("@Referral_ID", SqlDbType.Int);

            //assign values
            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;
            dateParameter.Value = date;
            reasonForConsultaParameter.Value = reasonForConsulta;
            symptomsParameter.Value = symptoms;
            clinicalFindingsParameter.Value = clinicalFindings;
            diagnosisParameter.Value = diagnosis;
            testResultSummaryParameter.Value = testResultSummary;
            treatmentPlanParameter.Value = treatmentPlan;
            presciption_IDParameter.Value = presciption_ID;
            referral_IDParameter.Value = referral_ID;

            //add to list
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);
            _parameters.Add(dateParameter);
            _parameters.Add(reasonForConsultaParameter);
            _parameters.Add(symptomsParameter);
            _parameters.Add(clinicalFindingsParameter);
            _parameters.Add(diagnosisParameter);
            _parameters.Add(testResultSummaryParameter);
            _parameters.Add(treatmentPlanParameter);
            _parameters.Add(presciption_IDParameter);
            _parameters.Add(referral_IDParameter);

            try
            {
                _access.ExecuteNonQuery(_con, _parameters, "[NewUpdateConsultation]");
                _access.LogEntry(1, "Created Consultation");
                return true;
            }
            catch (Exception ex)
            {
                _access.LogEntry(1, ex.ToString());
                return false;
            }
        }

        public Consultation GetConsultation(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Consultation consultationInfo = new Consultation();
            using (var reader = _access.ExecuteReader(_con, "[GetConsultation]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    return new Consultation().Create(reader);
                }
            }
            return consultationInfo;
        }

        public List<Consultation> GetAllConsultations()
        {
            List<Consultation> consultationInfo = new List<Consultation>();
            using (var reader = _access.ExecuteReader(_con, "[GetAllConsultations]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    consultationInfo.Add(new Consultation().Create(reader));
                }
            }
            return consultationInfo;
        }

        public bool DeleteConsultation(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeleteConsultation]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        #endregion

        #region Invoice
        public bool NewUpdateInvoice(DateTime date, string invoiceSummary, string total, int medical_Aid_ID, int patient_ID, int doctor_ID)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter invoiceSummaryParameter = new SqlParameter("@InvoiceSummary", SqlDbType.NVarChar);
            SqlParameter totalParameter = new SqlParameter("@Total", SqlDbType.NVarChar);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);

            //assign values
            dateParameter.Value = date;
            invoiceSummaryParameter.Value = invoiceSummary;
            totalParameter.Value = total;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;

            //add to list
            _parameters.Add(dateParameter);
            _parameters.Add(invoiceSummaryParameter);
            _parameters.Add(totalParameter);
            _parameters.Add(medical_Aid_IDParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);

            try
            {
                _access.ExecuteNonQuery(_con, _parameters, "[NewUpdateInvoice]");
                _access.LogEntry(1, "Created Invoice");
                return true;
            }
            catch (Exception ex)
            {
                _access.LogEntry(1, ex.ToString());
                return false;
            }
        }

        public Invoice GetInvoice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@InvoiceID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Invoice invoiceInfo = new Invoice();
            using (var reader = _access.ExecuteReader(_con, "[GetInvoice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    return new Invoice().Create(reader);
                }
            }
            return invoiceInfo;
        }

        public List<Invoice> GetAllInvoices()
        {
            List<Invoice> invoiceInfo = new List<Invoice>();
            using (var reader = _access.ExecuteReader(_con, "[GetAllInvoices]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    invoiceInfo.Add(new Invoice().Create(reader));
                }
            }
            return invoiceInfo;
        }

        public bool DeleteInvoice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeleteInvoice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region patient
        public int NewUpdatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country)
        {
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

            using (var reader = _access.ExecuteReader(_con, "[NewUpdatePatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            _access.LogEntry(userId, "New Patient Created");
            return userId;
        }

        public Patient GetPatient(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@PatientID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Patient patientInfo = new Patient();
            using (var reader = _access.ExecuteReader(_con, "[GetPatient]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    patientInfo = new Patient(reader);
                }
            }
            return null;
        }

        public List<Patient> GetAllPatients()
        {

            List<Patient> patientInfo = new List<Patient>();
            using (var reader = _access.ExecuteReader(_con, "[GetAllPatients]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    patientInfo.Add(new Patient(reader));
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeletePatient]", new List<SqlParameter>()))
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
        public int NewUpdatePatient_Medical_Aid(string scheme_name, string member_number, bool status, DateTime registration_date, DateTime deregistration, int patient_ID, int medical_Aid_ID)
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[NewUpdatePatient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_ID"));
                }
            }
            return userId;
        }

        public Patient_Medical_Aid Get_Patient_Medical_Aid(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@Patient_Medical_Aid_ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Patient_Medical_Aid patientMedicalAidInfo = new Patient_Medical_Aid();

            using (var reader = _access.ExecuteReader(_con, "[Get_Patient_Medical_Aid]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    patientMedicalAidInfo = new Patient_Medical_Aid(reader);
                }
            }
            return patientMedicalAidInfo;
        }

        public List<Patient_Medical_Aid> GetAll_Patient_Medical_Aids()
        {

            List<Patient_Medical_Aid> patientInfo = new List<Patient_Medical_Aid>();

            using (var reader = _access.ExecuteReader(_con, "[GetAll_Patient_Medical_Aids]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        patientInfo.Add(new Patient_Medical_Aid(reader));
                    }
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[Delete_Patient_Medical_Aid]", new List<SqlParameter>()))
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
        public int NewUpdatePractice(string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.Int);
            SqlParameter cell_numberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
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
            using (var reader = _access.ExecuteReader(_con, "[NewUpdatePractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("PracticeID"));
                }
            }
            return userId;
        }

        public Practice GetPractice(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Practice practiceInfo = new Practice();

            using (var reader = _access.ExecuteReader(_con, "[GetPractice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    practiceInfo = new Practice(reader);
                }
            }
            return practiceInfo;
        }

        public List<Practice> GetAllPractices()
        {
            List<Practice> practiceInfo = new List<Practice>();

            using (var reader = _access.ExecuteReader(_con, "[GetAllPractices]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        practiceInfo.Add(new Practice(reader));
                    }
                }
            }
            return practiceInfo;
        }

        public bool DeletePractice(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeletePractice]", new List<SqlParameter>()))
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
        public int NewUpdatePrescription(string description, DateTime date, int patient_ID, int doctor_ID)
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[NewUpdatePrescription]", new List<SqlParameter>()))
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

            Prescription prescriptionInfo = new Prescription();

            using (var reader = _access.ExecuteReader(_con, "[GetPrescription]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    prescriptionInfo = new Prescription(reader);
                }
            }
            return prescriptionInfo;
        }

        public List<Prescription> GetAllPrescriptions()
        {

            List<Prescription> prescriptionInfo = new List<Prescription>();

            using (var reader = _access.ExecuteReader(_con, "[GetAllPrescriptions]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    prescriptionInfo.Add(new Prescription(reader));
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeletePrescription]", new List<SqlParameter>()))
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
        public int NewUpdateStaff(string firstName, string lastName, string id_Number, string gender, DateTime dob, string phone, 
            string street_Address, string suburb, string city, string country, string employee_Type, int practice_ID, int user_ID)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter id_NumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.DateTime);
            SqlParameter phoneParameter = new SqlParameter("@Phone", SqlDbType.NVarChar);
            SqlParameter street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter employee_TypeParameter = new SqlParameter("@Employee_Type", SqlDbType.NVarChar);
            SqlParameter practice_IDParameter = new SqlParameter("@Practice_ID", SqlDbType.Int);
            SqlParameter user_IDParameter = new SqlParameter("@User_ID", SqlDbType.Int);
            SqlParameter emailParameter = new SqlParameter("@Email", SqlDbType.NVarChar);

            firstNameParameter.Value = firstName;
            lastNameParameter.Value = lastName;
            id_NumberParameter.Value = id_Number;
            genderParameter.Value = gender;
            dobParameter.Value = dob;
            phoneParameter.Value = phone;
            street_AddressParameter.Value = street_Address;
            suburbParameter.Value = suburb;
            cityParameter.Value = city;
            countryParameter.Value = country;
            employee_TypeParameter.Value = employee_Type;
            practice_IDParameter.Value = practice_ID;
            user_IDParameter.Value = user_ID;

            _parameters.Add(firstNameParameter);
            _parameters.Add(lastNameParameter);
            _parameters.Add(id_NumberParameter);
            _parameters.Add(genderParameter);
            _parameters.Add(dobParameter);
            _parameters.Add(phoneParameter);
            _parameters.Add(street_AddressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(employee_TypeParameter);
            _parameters.Add(practice_IDParameter);
            _parameters.Add(user_IDParameter);

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[NewUpdateStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("StaffID"));
                }
            }
            return userId;
        }

        public Staff GetStaff(int id)
        {
            _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@StaffID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            Staff staffInfo = new Staff();
            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[GetStaff]", new List<SqlParameter>()))
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
            using (var reader = _access.ExecuteReader(_con, "[GetAllStaffMembers]", new List<SqlParameter>()))
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

            int userId = 0;
            using (var reader = _access.ExecuteReader(_con, "[DeleteStaff]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }
        #endregion

        #region Doctor
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

            if (doc.UserId != 0)
            {
                userIdParameter.Value = doc.UserId;
                parameters.Add(userIdParameter);
            }

            jobTitleParameter.Value = doc.Job_Title;
            parameters.Add(jobTitleParameter);

            try
            {
                _access.ExecuteNonQuery(_con, parameters, "[NewUpdateDoctor]");
                _access.LogEntry(UserId, "User Added new Doctor");
                return true;
            }
            catch (Exception ex)
            {
                _access.LogEntry(UserId, ex.ToString());
                return false;
            }
        }
        #endregion
    }
}