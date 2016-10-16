using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ObjectModel
{
    public class UserProfile
    {
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName                { get; set; }
        public string ID_Number               { get; set; }
        public string Gender                  { get; set; }
        public string DOB                     { get; set; }
        public string Phone                   { get; set; }
        public string Street_Address          { get; set; }
        public string Suburb                  { get; set; }
        public string City                    { get; set; }
        public string Country                 { get; set; }
        public string Employee_Type           { get; set; }
        public string Email                   { get; set; }
        public string Practice_Name           { get; set; }
        public string Practice_Phone_Number   { get; set; }
        public string Practice_Fax_Number     { get; set; }
        public string Practice_Street_Address { get; set; }
        public string Practice_Suburb         { get; set; }
        public string Practice_City           { get; set; }
        public string Practice_Country        { get; set; }
        public int AccessLevel { get; set; }
        public string Password { get; set; }

        public UserProfile CreateStaff(SqlDataReader reader)
        {
            return new UserProfile
            {
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number = reader.GetString(reader.GetOrdinal("ID_Number")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                DOB = reader.GetString(reader.GetOrdinal("DOB")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                Street_Address = reader.GetString(reader.GetOrdinal("Street_Address")),
                Suburb = reader.GetString(reader.GetOrdinal("Suburb")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Employee_Type = reader.GetString(reader.GetOrdinal("Employee_Type")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name")),
                Practice_Phone_Number = reader.GetString(reader.GetOrdinal("Practice_Phone_Number")),
                Practice_Fax_Number = reader.GetString(reader.GetOrdinal("Practice_Fax_Number")),
                Practice_Street_Address = reader.GetString(reader.GetOrdinal("Practice_Street_Address")),
                Practice_Suburb = reader.GetString(reader.GetOrdinal("Practice_Suburb")),
                Practice_City = reader.GetString(reader.GetOrdinal("Practice_City")),
                Practice_Country = reader.GetString(reader.GetOrdinal("Practice_Country")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }

        public UserProfile CreateDoctor(SqlDataReader reader)
        {
            return new UserProfile
            {
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                Street_Address = reader.GetString(reader.GetOrdinal("Address")),
                Employee_Type = reader.GetString(reader.GetOrdinal("Job_Title")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Practice_Name = reader.GetString(reader.GetOrdinal("Practice_Name")),
                Practice_Phone_Number = reader.GetString(reader.GetOrdinal("Practice_Phone_Number")),
                Practice_Fax_Number = reader.GetString(reader.GetOrdinal("Practice_Fax_Number")),
                Practice_Street_Address = reader.GetString(reader.GetOrdinal("Practice_Street_Address")),
                Practice_Suburb = reader.GetString(reader.GetOrdinal("Practice_Suburb")),
                Practice_City = reader.GetString(reader.GetOrdinal("Practice_City")),
                Practice_Country = reader.GetString(reader.GetOrdinal("Practice_Country")),
                AccessLevel = reader.GetInt32(reader.GetOrdinal("AccessLevel")),
            };
        }

        public UserProfile GetPassword(SqlDataReader reader)
        {
            return new UserProfile
            {
                Password = reader.GetString(reader.GetOrdinal("Password"))
            };
        }
    }
}
