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
    }
}
