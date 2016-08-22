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
        public string Allergies { get; set; }
        public string PreviousIllnesses { get; set; }
        public string PreviousMedication { get; set; }
        public string RiskFactors { get; set; }
        public string SocialHistory { get; set; }
        public string FamilyHistory { get; set; }
        public int Medical_Aid_ID { get; set; }
        public int Doctor_ID { get; set; }
        public int User_ID { get; set; }
        public string Email { get; set; }

        public Patient Create(SqlDataReader reader)
        {
            return new Patient
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number = reader.GetString(reader.GetOrdinal("ID_Number")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                Cell_Number = reader.GetString(reader.GetOrdinal("Cell_Number")),
                Street_Address = reader.GetString(reader.GetOrdinal("Street_Address")),
                Suburb = reader.GetString(reader.GetOrdinal("Suburb")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Allergies = reader.GetString(reader.GetOrdinal("Allergies")),
                PreviousIllnesses = reader.GetString(reader.GetOrdinal("PreviousIllnesses")),
                PreviousMedication = reader.GetString(reader.GetOrdinal("PreviousMedication")),
                RiskFactors = reader.GetString(reader.GetOrdinal("RiskFactors")),
                SocialHistory = reader.GetString(reader.GetOrdinal("SocialHistory")),
                FamilyHistory = reader.GetString(reader.GetOrdinal("FamilyHistory")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
            };
        }
    }
}
