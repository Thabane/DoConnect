using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class MedicalRecord
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Cell_Number { get; set; }
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Medical_Aid_ID { get; set; }
        public int Doctor_ID { get; set; }
        public int User_ID { get; set; }
        public string Allergies { get; set; }
        public string PreviousIllnesses { get; set; }
        public string PreviousMedication { get; set; }
        public string RiskFactors { get; set; }
        public string SocialHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string Email { get; set; }
        public int Patient_Medical_Aid_ID { get; set; }
        public string Scheme_Name { get; set; }
        public string Membership_Number { get; set; }
        public bool Status { get; set; }
        public string Registration_Date { get; set; }
        public string Deregistration_Date { get; set; }
        public int Patient_ID { get; set; }
        public int Patient_Medical_Aid_Medical_Aid_ID { get; set; }
        public string Name { get; set; }

        public string Medical_Aid_Name      { get; set; }
        public string Doctors_FirstName     { get; set; }
        public string Doctors_LastName      { get; set; }
        public string Practice_Aid_Name     { get; set; }

        public MedicalRecord Create(SqlDataReader reader)
        {
            return new MedicalRecord
            {
                ID                                    = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName                             = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName                              = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number                             = reader.GetString(reader.GetOrdinal("ID_Number")),
                Gender                                = reader.GetString(reader.GetOrdinal("Gender")),
                DOB                                   = reader.GetString(reader.GetOrdinal("DOB")),
                Cell_Number                           = reader.GetString(reader.GetOrdinal("Cell_Number")),
                Street_Address                        = reader.GetString(reader.GetOrdinal("Street_Address")),
                Suburb                                = reader.GetString(reader.GetOrdinal("Suburb")),
                City                                  = reader.GetString(reader.GetOrdinal("City")),
                Country                               = reader.GetString(reader.GetOrdinal("Country")),
                Medical_Aid_ID                        = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Doctor_ID                             = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                User_ID                               = reader.GetInt32(reader.GetOrdinal("User_ID")),
                Allergies                             = reader.GetString(reader.GetOrdinal("Allergies")),
                PreviousIllnesses                     = reader.GetString(reader.GetOrdinal("PreviousIllnesses")),
                PreviousMedication                    = reader.GetString(reader.GetOrdinal("PreviousMedication")),
                RiskFactors                           = reader.GetString(reader.GetOrdinal("RiskFactors")),
                SocialHistory                         = reader.GetString(reader.GetOrdinal("SocialHistory")),
                FamilyHistory                         = reader.GetString(reader.GetOrdinal("FamilyHistory")),
                Email                                 = reader.GetString(reader.GetOrdinal("Email")),
                Patient_Medical_Aid_ID                = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_ID")),
                Scheme_Name                           = reader.GetString(reader.GetOrdinal("Scheme_Name")),
                Membership_Number                     = reader.GetString(reader.GetOrdinal("Membership_Number")),
                Status                                = reader.GetBoolean(reader.GetOrdinal("Status")),
                Registration_Date                     = reader.GetString(reader.GetOrdinal("Registration_Date")),
                Deregistration_Date                   = reader.GetString(reader.GetOrdinal("Deregistration_Date")),
                Patient_ID                            = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_Medical_Aid_Medical_Aid_ID    = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_Medical_Aid_ID")),
                Name                                  = reader.GetString(reader.GetOrdinal("Name"))
            };
        }
        
        public MedicalRecord GetProfileByPatientID(SqlDataReader reader)
        {
            return new MedicalRecord
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number = reader.GetString(reader.GetOrdinal("ID_Number")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                DOB = reader.GetString(reader.GetOrdinal("DOB")),
                Cell_Number = reader.GetString(reader.GetOrdinal("Cell_Number")),
                Street_Address = reader.GetString(reader.GetOrdinal("Street_Address")),
                Suburb = reader.GetString(reader.GetOrdinal("Suburb")),
                City = reader.GetString(reader.GetOrdinal("City")),
                Country = reader.GetString(reader.GetOrdinal("Country")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                Allergies = reader.GetString(reader.GetOrdinal("Allergies")),
                PreviousIllnesses = reader.GetString(reader.GetOrdinal("PreviousIllnesses")),
                PreviousMedication = reader.GetString(reader.GetOrdinal("PreviousMedication")),
                RiskFactors = reader.GetString(reader.GetOrdinal("RiskFactors")),
                SocialHistory = reader.GetString(reader.GetOrdinal("SocialHistory")),
                FamilyHistory = reader.GetString(reader.GetOrdinal("FamilyHistory")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Patient_Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_ID")),
                Scheme_Name = reader.GetString(reader.GetOrdinal("Scheme_Name")),
                Membership_Number = reader.GetString(reader.GetOrdinal("Membership_Number")),
                Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                Registration_Date = reader.GetString(reader.GetOrdinal("Registration_Date")),
                Deregistration_Date = reader.GetString(reader.GetOrdinal("Deregistration_Date")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_Medical_Aid_Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Patient_Medical_Aid_Medical_Aid_ID")),
                Medical_Aid_Name   = reader.GetString(reader.GetOrdinal("Medical_Aid_Name")),
                Doctors_FirstName  = reader.GetString(reader.GetOrdinal("Doctors_FirstName")),
                Doctors_LastName   = reader.GetString(reader.GetOrdinal("Doctors_LastName")),
                Practice_Aid_Name  = reader.GetString(reader.GetOrdinal("Practice_Aid_Name")),
            };
        }
    }
}
