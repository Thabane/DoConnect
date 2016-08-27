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
        private string Conn = @"Data Source=DESKTOP-6Gu3I3G\SQLEXPRESS;Initial Catalog=DoConnect;Integrated Security=True";

        public DataLayer()
        {
            access = new DataAccess();
        }

        #region User
        public int CreateUser(int accessLevel)
        {
            int userId = 0;
            SqlParameter levelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            levelParameter.Value = accessLevel;

            using (var reader = access.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>() { levelParameter }))
            {
                if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            access.LogEntry(userId, "New User Created");
            return userId;
        }

        public string Login(string username, string password, int accessLevel)
        {
            int userId = 0;
            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter accessLevelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            accessLevelParameter.Value = accessLevel;
            _parameters.Add(accessLevelParameter);

            using (var reader = access.ExecuteReader(Conn, "[CreateUser]",_parameters))
            {
                if (reader.Read())
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            access.LogEntry(userId, "New User Created");
            return "";
        }
        #endregion

        #region Consultation
        
        public bool CreateConsultation(int patient_ID, int doctor_ID, DateTime date, string reasonForConsulta, string symptoms, string clinicalFindings
            , string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter reasonForConsultaParameter = new SqlParameter("@ReasonForConsulta", SqlDbType.NVarChar);
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
                access.ExecuteNonQuery(Conn, _parameters, "[CreateConsultation]");
                access.LogEntry(1, "Created Consultation");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(1, ex.ToString());
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
            using (var reader = access.ExecuteReader(Conn, "[GetConsultation]", new List<SqlParameter>()))
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
            using (var reader = access.ExecuteReader(Conn, "[GetAllConsultations]", new List<SqlParameter>()))
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
            using (var reader = access.ExecuteReader(Conn, "[DeleteConsultation]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdateConsultation(int id, int patient_ID, int doctor_ID, DateTime date, string reasonForConsulta, string symptoms, string clinicalFindings
            , string diagnosis, string testResultSummary, string treatmentPlan, int presciption_ID, int referral_ID)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter iDParameter = new SqlParameter("@ID", SqlDbType.NVarChar);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter reasonForConsultaParameter = new SqlParameter("@ReasonForConsulta", SqlDbType.NVarChar);
            SqlParameter symptomsParameter = new SqlParameter("@Symptoms", SqlDbType.NVarChar);
            SqlParameter clinicalFindingsParameter = new SqlParameter("@ClinicalFindings", SqlDbType.NVarChar);
            SqlParameter diagnosisParameter = new SqlParameter("@Diagnosis", SqlDbType.NVarChar);
            SqlParameter testResultSummaryParameter = new SqlParameter("@TestResultSummary", SqlDbType.NVarChar);
            SqlParameter treatmentPlanParameter = new SqlParameter("@TreatmentPlan", SqlDbType.NVarChar);
            SqlParameter presciption_IDParameter = new SqlParameter("@Presciption_ID", SqlDbType.Int);
            SqlParameter referral_IDParameter = new SqlParameter("@Referral_ID", SqlDbType.Int);

            //assign values
            iDParameter.Value = id;
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
            _parameters.Add(iDParameter);
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

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdateConsultation]", new List<SqlParameter>()))
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
        
        public bool CreateInvoice(DateTime date, string invoiceSummary, string total, int medical_Aid_ID, int patient_ID, int doctor_ID)
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
                access.ExecuteNonQuery(Conn, _parameters, "[CreateInvoice]");
                access.LogEntry(1, "Created Invoice");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(1, ex.ToString());
                return false;
            }
        }

        public Invoice GetInvoice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);
            Invoice invoiceInfo = new Invoice();
            using (var reader = access.ExecuteReader(Conn, "[GetInvoice]", new List<SqlParameter>()))
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
            using (var reader = access.ExecuteReader(Conn, "[GetAllInvoices]", new List<SqlParameter>()))
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
            using (var reader = access.ExecuteReader(Conn, "[DeleteInvoice]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            return true;
        }

        public bool UpdateInvoice(int id, DateTime date, string invoiceSummary, string total, int medical_Aid_ID, int patient_ID, int doctor_ID)
        {
            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter dateParameter = new SqlParameter("@Date", SqlDbType.DateTime);
            SqlParameter invoiceSummaryParameter = new SqlParameter("@InvoiceSummary", SqlDbType.NVarChar);
            SqlParameter totalParameter = new SqlParameter("@Total", SqlDbType.NVarChar);
            SqlParameter medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter patient_IDParameter = new SqlParameter("@Patient_ID", SqlDbType.Int);
            SqlParameter doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);

            //assign values
            idParameter.Value = id;
            dateParameter.Value = date;
            invoiceSummaryParameter.Value = invoiceSummary;
            totalParameter.Value = total;
            medical_Aid_IDParameter.Value = medical_Aid_ID;
            patient_IDParameter.Value = patient_ID;
            doctor_IDParameter.Value = doctor_ID;

            //add to list
            _parameters.Add(idParameter);
            _parameters.Add(dateParameter);
            _parameters.Add(invoiceSummaryParameter);
            _parameters.Add(totalParameter);
            _parameters.Add(medical_Aid_IDParameter);
            _parameters.Add(patient_IDParameter);
            _parameters.Add(doctor_IDParameter);

            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[UpdateInvoice]", new List<SqlParameter>()))
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
        public bool CreatePatient(string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country,
            string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory, int Medical_Aid_ID, int Doctor_ID, int UserId)
        {

            //state params
            List<SqlParameter> _parameters = new List<SqlParameter>();
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

            SqlParameter AllergiesParameter = new SqlParameter("@Allergies", SqlDbType.NVarChar);
            SqlParameter PreviousIllnessesParameter = new SqlParameter("@PreviousIllnesses", SqlDbType.NVarChar);
            SqlParameter PreviousMedicationParameter = new SqlParameter("@PreviousMedication", SqlDbType.NVarChar);
            SqlParameter RiskFactorsParameter = new SqlParameter("@RiskFactors", SqlDbType.NVarChar);
            SqlParameter SocialHistoryParameter = new SqlParameter("@SocialHistory", SqlDbType.NVarChar);
            SqlParameter FamilyHistoryParameter = new SqlParameter("@FamilyHistory", SqlDbType.NVarChar);
            SqlParameter Medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter UserIdParameter = new SqlParameter("@UserId", SqlDbType.Int);
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
            AllergiesParameter.Value = Allergies;
            PreviousIllnessesParameter.Value = PreviousIllnesses;
            PreviousMedicationParameter.Value = PreviousMedication;
            RiskFactorsParameter.Value = RiskFactors;
            SocialHistoryParameter.Value = SocialHistory;
            FamilyHistoryParameter.Value = FamilyHistory;
            Medical_Aid_IDParameter.Value = Medical_Aid_ID;
            Doctor_IDParameter.Value = Doctor_ID;
            UserIdParameter.Value = UserId;
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
            _parameters.Add(AllergiesParameter);
            _parameters.Add(PreviousIllnessesParameter);
            _parameters.Add(PreviousMedicationParameter);
            _parameters.Add(RiskFactorsParameter);
            _parameters.Add(SocialHistoryParameter);
            _parameters.Add(FamilyHistoryParameter);
            _parameters.Add(Medical_Aid_IDParameter);
            _parameters.Add(Doctor_IDParameter);
            _parameters.Add(UserIdParameter);

            try
            {
                access.ExecuteNonQuery(Conn, _parameters, "[CreatePatient]");
                access.LogEntry(UserId, "Created Patient");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(UserId, ex.ToString());
                return false;
            }
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

        public bool UpdatePatient(int id, string firstName, string lastName, string id_Number, string gender, DateTime dob, string cell_number, string street_address, string suburb, string city, string country, string Allergies, string PreviousIllnesses, string PreviousMedication, string RiskFactors, string SocialHistory, string FamilyHistory, int Medical_Aid_ID, int Doctor_ID)
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
            SqlParameter AllergiesParameter = new SqlParameter("@Allergies", SqlDbType.NVarChar);
            SqlParameter PreviousIllnessesParameter = new SqlParameter("@PreviousIllnesses", SqlDbType.NVarChar);
            SqlParameter PreviousMedicationParameter = new SqlParameter("@PreviousMedication", SqlDbType.NVarChar);
            SqlParameter RiskFactorsParameter = new SqlParameter("@RiskFactors", SqlDbType.NVarChar);
            SqlParameter SocialHistoryParameter = new SqlParameter("@SocialHistory", SqlDbType.NVarChar);
            SqlParameter FamilyHistoryParameter = new SqlParameter("@FamilyHistory", SqlDbType.NVarChar);
            SqlParameter Medical_Aid_IDParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter Doctor_IDParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
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
            AllergiesParameter.Value = Allergies;
            PreviousIllnessesParameter.Value = PreviousIllnesses;
            PreviousMedicationParameter.Value = PreviousMedication;
            RiskFactorsParameter.Value = RiskFactors;
            SocialHistoryParameter.Value = SocialHistory;
            FamilyHistoryParameter.Value = FamilyHistory;
            Medical_Aid_IDParameter.Value = Medical_Aid_ID;
            Doctor_IDParameter.Value = Doctor_ID;
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
            _parameters.Add(AllergiesParameter);
            _parameters.Add(PreviousIllnessesParameter);
            _parameters.Add(PreviousMedicationParameter);
            _parameters.Add(RiskFactorsParameter);
            _parameters.Add(SocialHistoryParameter);
            _parameters.Add(FamilyHistoryParameter);
            _parameters.Add(Medical_Aid_IDParameter);
            _parameters.Add(Doctor_IDParameter);

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
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
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

            Practice PracticeInfo = new Practice();
            using (var reader = access.ExecuteReader(Conn, "[GetPracticeById]", _parameters))
            {
                if (reader.Read())
                {
                    PracticeInfo.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                    PracticeInfo.Name = reader.GetString(reader.GetOrdinal("Name"));
                    PracticeInfo.Phone_Number = reader.GetString(reader.GetOrdinal("Phone_Number"));
                    PracticeInfo.Fax_Number = reader.GetString(reader.GetOrdinal("Fax_Number"));
                    PracticeInfo.Street_Address = reader.GetString(reader.GetOrdinal("Street_Address"));
                    PracticeInfo.Suburb = reader.GetString(reader.GetOrdinal("Suburb"));
                    PracticeInfo.City = reader.GetString(reader.GetOrdinal("City"));
                    PracticeInfo.Country = reader.GetString(reader.GetOrdinal("Country"));
                    PracticeInfo.Latitude = reader.GetString(reader.GetOrdinal("Latitude"));
                    PracticeInfo.Longitude = reader.GetString(reader.GetOrdinal("Longitude"));
                    PracticeInfo.Trading_Times = reader.GetString(reader.GetOrdinal("Trading_Times"));
                }
            }
            return PracticeInfo;
        }

        public List<Practice> GetAllPractices()
        {
            List<Practice> PracticeInfo = new List<Practice>();
            using (var reader = access.ExecuteReader(Conn, "[GetAllPractices]", new List<SqlParameter>()))
            {
                while (reader.Read())
                {
                    PracticeInfo.Add(new Practice().Create(reader));
                }
            }
            return PracticeInfo;
        }

        public bool DeletePractice(int id)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            idParameter.Value = id;
            _parameters.Add(idParameter);

            using (var reader = access.ExecuteReader(Conn, "[DeletePractice]", _parameters))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool UpdatePractice(int id, string name, string cell_number, string fax_number, string street_address, string suburb, string city, string country, string latitude, string longitude, string trading_Times)
        {
            List<SqlParameter> _parameters = new List<SqlParameter>();
            SqlParameter idParameter = new SqlParameter("@ID", SqlDbType.Int);
            SqlParameter nameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter phone_numberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
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
            phone_numberParameter.Value = cell_number;
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
            _parameters.Add(phone_numberParameter);
            _parameters.Add(fax_numberParameter);
            _parameters.Add(street_addressParameter);
            _parameters.Add(suburbParameter);
            _parameters.Add(cityParameter);
            _parameters.Add(countryParameter);
            _parameters.Add(latitudeParameter);
            _parameters.Add(longitudeParameter);
            _parameters.Add(trading_TimesParameter);
            //int userId = 0;
            //using (var reader = access.ExecuteReader(Conn, "[NewUpdatePractice]", _parameters))
            //{
            //    if (reader.Read())
            //    {
            //        userId = reader.GetInt32(reader.GetOrdinal("ID"));
            //    }
            //}
            //return true;

            access.ExecuteNonQuery(Conn, _parameters, "[NewUpdatePractice]");
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
        #endregion

        public Doctor GetDoctor(int DocID)
        {
            return null;
        }

        public bool InsertPractice(string Name, string Phone_Number, string Fax_Number, string Street_Address, string Suburb, string City, string Country, string Latitude, string Longitude, string Trading_Times)
        {

            int ID = 0;
            SqlParameter NameParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            SqlParameter Phone_NumberParameter = new SqlParameter("@Phone_Number", SqlDbType.NVarChar);
            SqlParameter Fax_NumberParameter = new SqlParameter("@Fax_Number", SqlDbType.NVarChar);
            SqlParameter Street_AddressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter SuburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter CityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter CountryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter LatitudeParameter = new SqlParameter("@Latitude", SqlDbType.NVarChar);
            SqlParameter LongitudeParameter = new SqlParameter("@Longitude", SqlDbType.NVarChar);
            SqlParameter Trading_TimesParameter = new SqlParameter("@Trading_Times", SqlDbType.NVarChar);

            NameParameter.Value = Name;
            Phone_NumberParameter.Value = Phone_Number;
            Fax_NumberParameter.Value = Fax_Number;
            Street_AddressParameter.Value = Street_Address;
            SuburbParameter.Value = Suburb;
            CityParameter.Value = City;
            CountryParameter.Value = Country;
            LatitudeParameter.Value = Latitude;
            LongitudeParameter.Value = Longitude;
            Trading_TimesParameter.Value = Trading_Times;

            _parameters.Add(NameParameter);
            _parameters.Add(Phone_NumberParameter);
            _parameters.Add(Fax_NumberParameter);
            _parameters.Add(Street_AddressParameter);
            _parameters.Add(SuburbParameter);
            _parameters.Add(CityParameter);
            _parameters.Add(CountryParameter);
            _parameters.Add(LatitudeParameter);
            _parameters.Add(LongitudeParameter);
            _parameters.Add(Trading_TimesParameter);

            using (var reader = access.ExecuteReader(Conn, "[InsertPractice]", new List<SqlParameter>() { NameParameter, Phone_NumberParameter, Fax_NumberParameter, Street_AddressParameter, SuburbParameter, CityParameter, CountryParameter, LatitudeParameter, LongitudeParameter, Trading_TimesParameter }))
            {
                if (reader.Read())
                    ID = reader.GetInt32(reader.GetOrdinal("ID"));
            }
            //access.LogEntry(ID, "New User Created");
            return true;
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
    }
}