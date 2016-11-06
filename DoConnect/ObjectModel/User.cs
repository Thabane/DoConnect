using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class User
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime? Last_Login { get; set; }
        public int AccessLevel { get; set; }

        public User Create(SqlDataReader reader)
        {
            return new User(reader)
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Password = reader.GetString(reader.GetOrdinal("Password")),
                Last_Login = reader.GetDateTime(reader.GetOrdinal("Last_Login")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }

        public User(SqlDataReader reader)
        {
            ID = reader["ID"] != null ? Convert.ToInt32(reader["ID"].ToString()) : 0;
            Password = reader["Password"] != null ? reader["Password"].ToString() : string.Empty;
            Last_Login = reader["Last_Login"] != null && !string.IsNullOrEmpty(reader["Last_Login"].ToString()) ? Convert.ToDateTime(reader["Last_login"]) : (DateTime?)null;
            AccessLevel = reader["AccessLevel"] != null ? Convert.ToInt32(reader["AccessLevel"].ToString()) : 0;
        }
    }
}
