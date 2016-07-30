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
        
        public int CreateUser()
        {            
            int userId = 0;
            using (var reader = access.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                   userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }    
            }
            access.LogEntry(userId, "New User Created");
            return userId;
        }

        public bool NewUpdateDoctor(Doctor doc)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlParameter firstNameParameter = new SqlParameter("@FirstName",SqlDbType.NVarChar);
            SqlParameter lastNameParameter = new SqlParameter("@LastName", SqlDbType.NVarChar);
            SqlParameter genderParameter = new SqlParameter("@Gender", SqlDbType.Char);
            SqlParameter addressParameter = new SqlParameter("@Address", SqlDbType.NVarChar);
            SqlParameter practiceIdParameter = new SqlParameter("@PracticeID", SqlDbType.Int);
            SqlParameter userIdParameter = new SqlParameter("@UserID", SqlDbType.Int);
            SqlParameter jobTitleParameter = new SqlParameter("@JobTitle", SqlDbType.NVarChar);

            firstNameParameter.Value = doc.FirstName;
            lastNameParameter.Value = doc.LastName;
            genderParameter.Value = doc.Gender;
            addressParameter.Value = doc.Address;
            practiceIdParameter.Value = doc.PracticeId;
            userIdParameter.Value = doc.UserId;
            jobTitleParameter.Value = doc.Job_Title;


            try
            {
                access.ExecuteNonQuery(Conn, parameters, "[NewUpdateDoctor]");
            }
            catch (Exception)
            {
                return false;
            }

            return false;

        }

        public List<Patient> GetAllPatients()
        {
            DataAccess da = new DataAccess();
            //int userId = 0;
            //using (var reader = da.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>()))
            //{
            //    if (reader.Read())
            //    {
            //        userId = reader.GetInt32(reader.GetOrdinal("ID"));
            //    }
            //}
            //return userId;
            return new List<Patient>();
        }
    }
}
