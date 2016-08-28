using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Prescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }

        public Prescription()
        { }

        public Prescription(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            Description = reader.GetString(reader.GetOrdinal("Description"));
            Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID"));
            Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID"));

        }
    }
}
