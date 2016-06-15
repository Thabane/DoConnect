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
    public class BusinessLogic
    {
        private string Conn = "DB";
        public BusinessLogic()
        {
        }
        public int CreateUser()
        {
            DataAccess da = new DataAccess();
            int userId = 0;
            using (var reader = da.ExecuteReader(Conn, "[CreateUser]", new List<SqlParameter>()))
            {
                if (reader.Read())
                {
                   userId = reader.GetInt32(reader.GetOrdinal("ID"));
                }    
            }
            return userId;
        }
    }
}
