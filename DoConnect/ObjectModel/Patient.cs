using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Cell_Number { get; set; }
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public Patient()
        {
        }

        public Patient(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal(""));
            FirstName = reader.GetString(reader.GetOrdinal(""));
            LastName = reader.GetString(reader.GetOrdinal(""));
            ID_Number = reader.GetString(reader.GetOrdinal(""));
            Gender = reader.GetString(reader.GetOrdinal(""));
            DOB = reader.GetDateTime(reader.GetOrdinal(""));
            Cell_Number = reader.GetString(reader.GetOrdinal(""));
            Street_Address = reader.GetString(reader.GetOrdinal(""));
            Suburb = reader.GetString(reader.GetOrdinal(""));
            City = reader.GetString(reader.GetOrdinal(""));
            Country = reader.GetString(reader.GetOrdinal(""));
        }
    }
}
