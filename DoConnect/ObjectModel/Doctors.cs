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
        public char Gender { get; set; }
        public string Address { get; set; }
        public string Job_Title { get; set; }
        public int UserId { get; set; }
        public int PracticeId { get; set; }

        public Doctor Create(SqlDataReader reader)
        {
            return new Doctor
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                //Gender = reader.GetChars(reader.GetOrdinal("Gender")),
                Address = reader.GetString(reader.GetOrdinal("Address")),
                Job_Title = reader.GetString(reader.GetOrdinal("Job_Title")),
                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                PracticeId = reader.GetInt32(reader.GetOrdinal("PracticeId")),
            };
        }
    }
}
