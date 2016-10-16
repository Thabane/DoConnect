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
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Last_Login { get; set; }
        public int AccessLevel  { get; set; }

        public int User_ID     { get; set; }
        public string FirstName   { get; set; }
        public string LastName    { get; set; }  
        public Login Create(SqlDataReader reader)
        {
            return new Login
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }
    }
}

