using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime Last_Login { get; set; }
        public int AccessLevel { get; set; }

        public User Create(SqlDataReader reader)
        {
            return new User
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                Last_Login = reader.GetDateTime(reader.GetOrdinal("Last_Login")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }
    }
}
