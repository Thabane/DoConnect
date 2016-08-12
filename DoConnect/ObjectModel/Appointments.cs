using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class Appointments
    {
        public int ID { get; set; }
        public bool App_Status { get; set; }
        public DateTime Date_Time { get; set; }
        public string Details { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }

        public Appointments Create(SqlDataReader reader)
        {
            return new Appointments
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                App_Status = reader.GetBoolean(reader.GetOrdinal("App_Status")),
                Date_Time = reader.GetDateTime(reader.GetOrdinal("Date_Time")),
                Details = reader.GetString(reader.GetOrdinal("Details")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
            };
        }
    }
}
