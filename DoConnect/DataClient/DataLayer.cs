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
        private string Conn = "DB";

        public DataLayer()
        {
            access = new DataAccess();
        }

        /// <summary>
        /// Creates a user.
        /// Returns the UserId of the new user
        /// </summary>
        /// <param name="AccessLevel">The access level.</param>
        /// <returns></returns>
        public int CreateUser(int AccessLevel)
        {
            int userId = 0;

            SqlParameter levelParameter = new SqlParameter("@AccessLevel", SqlDbType.Int);
            levelParameter.Value = AccessLevel;

            using (var reader = access.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>() { levelParameter }))
            {
                if (reader.Read())
                {
                    userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }
            }
            access.LogEntry(userId, "New User Created");
            return userId;
        }

        /// <summary>
        /// Creates a new Doctor or updates an existing doctor.
        /// Using the UserId and not the doctor ID
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
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
                access.ExecuteNonQuery(Conn, parameters, "[NewUpdateDoctor]");
                access.LogEntry(UserId, "User Added new Doctor");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(UserId, ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Gets all patients.
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAllPatients()
        {
            List<Patient> pats = new List<Patient>();

            using (var reader = access.ExecuteReader(Conn, "[GetAllPatients]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        pats.Add(new Patient(reader));
                    }                    
                }               
            }
            return pats;
        }

        public bool NewUpdatePatient(Patient pat, int UserId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter addressParameter = new SqlParameter("@Street_Address", SqlDbType.NVarChar);
            SqlParameter cityParameter = new SqlParameter("@City", SqlDbType.NVarChar);
            SqlParameter countryParameter = new SqlParameter("@Country", SqlDbType.NVarChar);
            SqlParameter suburbParameter = new SqlParameter("@Suburb", SqlDbType.NVarChar);
            SqlParameter medicalAidIdParameter = new SqlParameter("@Medical_Aid_ID", SqlDbType.Int);
            SqlParameter userIdParameter = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter doctorIdParameter = new SqlParameter("@Doctor_ID", SqlDbType.Int);
            SqlParameter idNumberParameter = new SqlParameter("@ID_Number", SqlDbType.NVarChar);
            SqlParameter cellNumberParameter = new SqlParameter("@Cell_Number", SqlDbType.NVarChar);
            SqlParameter dobParameter = new SqlParameter("@DOB", SqlDbType.Date);


            firstNameParameter.Value = pat.FirstName;
            parameters.Add(firstNameParameter);
            lastNameParameter.Value = pat.LastName;
            parameters.Add(lastNameParameter);
            genderParameter.Value = pat.Gender;
            parameters.Add(genderParameter);
            addressParameter.Value = pat.Street_Address;
            parameters.Add(addressParameter);
            medicalAidIdParameter.Value = pat.Medical_Aid_ID;
            parameters.Add(medicalAidIdParameter);
            doctorIdParameter.Value = pat.Doctor_ID;
            parameters.Add(doctorIdParameter);
            idNumberParameter.Value = pat.ID_Number;
            parameters.Add(idNumberParameter);
            cityParameter.Value = pat.City;
            parameters.Add(cityParameter);
            countryParameter.Value = pat.Country;
            parameters.Add(countryParameter);
            suburbParameter.Value = pat.Suburb;
            parameters.Add(suburbParameter);
            cellNumberParameter.Value = pat.Cell_Number;
            parameters.Add(cellNumberParameter);
            dobParameter.Value = pat.DOB;
            parameters.Add(dobParameter);


            if (pat.User_ID != 0)
            {
                userIdParameter.Value = pat.User_ID;
                parameters.Add(userIdParameter);
            }


            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[NewUpdatePatient]");
                access.LogEntry(UserId, "User Added new Patient");
                return true;
            }
            catch (Exception ex)
            {
                access.LogEntry(UserId, ex.ToString());
                return false;
            }
        }
    }
}
