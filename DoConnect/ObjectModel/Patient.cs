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

        public string Scheme_Name { get; set; }
        public string Membership_Number { get; set; }
        public bool Status { get; set; }
        public DateTime Registration_Date { get; set; }
        public DateTime Deregistration_Date { get; set; }
        public int Patient_ID { get; set; }

        //Prescription
        public int Prescription_ID { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int Prescribing_Doctor_ID { get; set; }

        //Prescription_DrugDetails
        public int Prescription_DrugDetails_ID { get; set; }
        public string DrugName { get; set; }
        public string Strength { get; set; }
        public string IntakeRoute { get; set; }
        public string Frequency { get; set; }
        public int DispenseNumber { get; set; }
        public int RefillNumber { get; set; }

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

                Scheme_Name = reader.GetString(reader.GetOrdinal("Scheme_Name")),
                Membership_Number = reader.GetString(reader.GetOrdinal("Membership_Number")),
                Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                Registration_Date = reader.GetDateTime(reader.GetOrdinal("Registration_Date")),
                Deregistration_Date = reader.GetDateTime(reader.GetOrdinal("Deregistration_Date")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),

                Prescription_ID = reader.GetInt32(reader.GetOrdinal("Prescription_ID")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date")).ToShortDateString(),
                Prescribing_Doctor_ID = reader.GetInt32(reader.GetOrdinal("Prescribing_Doctor_ID")),
                
                Prescription_DrugDetails_ID = reader.GetInt32(reader.GetOrdinal("Prescription_ID")),
                DrugName = reader.GetString(reader.GetOrdinal("DrugName")),
                Strength = reader.GetString(reader.GetOrdinal("Strength")),
                IntakeRoute = reader.GetString(reader.GetOrdinal("IntakeRoute")),
                Frequency = reader.GetString(reader.GetOrdinal("Frequency")),
                DispenseNumber = reader.GetInt32(reader.GetOrdinal("DispenseNumber")),
                RefillNumber = reader.GetInt32(reader.GetOrdinal("RefillNumber")),
            };
        }
    }
}
