using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class Appointments
    {
        public int Appointments_ID          { get; set; }
        public int Appointments_App_Status  { get; set; }
        public string Appointments_Date_Time{ get; set; }
        public string Appointments_Details  { get; set; }
        public int Patient_ID               { get; set; }
        public string Patient_FirstName     { get; set; }
        public string Patient_LastName      { get; set; }
        public string Patient_Cell_Number   { get; set; }
        public string Patient_Email         { get; set; }
        public string Doctors_Email         { get; set; }
        public string Doctors_FirstName     { get; set; }
        public string Doctors_LastName      { get; set; }
        public int Doctors_ID               { get; set; }
        public string Doctors_Job_Title     { get; set; }
        public int Practice_ID              { get; set; }
        public string Practice_Name         { get; set; }
        public string Practice_Phone_Number { get; set; }
        public string Practice_Fax_Number   { get; set; }
        public string Practice_Address { get; set; }

        public Appointments Create(SqlDataReader reader)
        {
            return new Appointments
            {
                Appointments_ID = reader.GetInt32(reader.GetOrdinal("Appointments_ID")),
                Appointments_App_Status = reader.GetInt32(reader.GetOrdinal("Appointments_App_Status")),
                Appointments_Date_Time = reader.GetString(reader.GetOrdinal("Appointments_Date_Time")),
                Appointments_Details = reader.GetString(reader.GetOrdinal("Appointments_Details")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_FirstName    = reader.GetString(reader.GetOrdinal("Patient_FirstName")),  
                Patient_LastName     = reader.GetString(reader.GetOrdinal("Patient_LastName")),  
                Patient_Cell_Number  = reader.GetString(reader.GetOrdinal("Patient_Cell_Number")),  
                Patient_Email        = reader.GetString(reader.GetOrdinal("Patient_Email")),  
                Doctors_Email        = reader.GetString(reader.GetOrdinal("Doctors_Email")),  
                Doctors_FirstName    = reader.GetString(reader.GetOrdinal("Doctors_FirstName")),  
                Doctors_LastName     = reader.GetString(reader.GetOrdinal("Doctors_LastName")),  
                Doctors_ID           = reader.GetInt32(reader.GetOrdinal("Doctors_ID")),  
                Doctors_Job_Title    = reader.GetString(reader.GetOrdinal("Doctors_Job_Title")),  
                Practice_ID          = reader.GetInt32(reader.GetOrdinal("Practice_ID")),  
                Practice_Name        = reader.GetString(reader.GetOrdinal("Practice_Name")),  
                Practice_Phone_Number= reader.GetString(reader.GetOrdinal("Practice_Phone_Number")),  
                Practice_Fax_Number  = reader.GetString(reader.GetOrdinal("Practice_Fax_Number")),  
                Practice_Address     = reader.GetString(reader.GetOrdinal("Practice_Address")),
            };
        }
    }
}
