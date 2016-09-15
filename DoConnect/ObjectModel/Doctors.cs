using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Job_Title { get; set; }
        public int User_Id { get; set; }
        public int Practice_ID { get; set; }
        public string DoctorFullName { get; set; }

    public Doctor Create(SqlDataReader reader)
        {
            return new Doctor
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                Job_Title = reader.GetString(reader.GetOrdinal("Job_Title")),
                User_Id = reader.GetInt32(reader.GetOrdinal("User_Id")),
                Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID")),
                DoctorFullName = reader.GetString(reader.GetOrdinal("DoctorFullName")),
            };
        }
    }
}
