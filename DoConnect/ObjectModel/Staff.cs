using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{  
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Employee_Type { get; set; }
        public int Practice_ID { get; set; }
        public int User_ID { get; set; }
        public string Email { get; set; }
        public int PRACTICE_ID { get; set; }
        public string PRACTICE_Name { get; set; }
        public Staff Create(SqlDataReader reader)
        {
            return new Staff
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number = reader.GetString(reader.GetOrdinal("ID_Number")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Street_Address = reader.GetString(reader.GetOrdinal("Street_Address")),
                Suburb = reader.GetString(reader.GetOrdinal("Suburb")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Employee_Type = reader.GetString(reader.GetOrdinal("Employee_Type")),
                Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                PRACTICE_ID = reader.GetInt32(reader.GetOrdinal("PRACTICE_ID")),
                PRACTICE_Name = reader.GetString(reader.GetOrdinal("PRACTICE_Name")),
            };
        }

    }
}
