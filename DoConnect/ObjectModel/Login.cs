using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Login
    {
        public int      ID 			   { get; set; }
        public string   Email 		  { get; set; }
        public string   Password 	  { get; set; }
        public DateTime Last_Login   { get; set; }
        public int AccessLevel  { get; set; }
        public Login Create(SqlDataReader reader)
        {
            return new Login
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                Last_Login = reader.GetDateTime(reader.GetOrdinal("Last_Login")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }
    }
}

