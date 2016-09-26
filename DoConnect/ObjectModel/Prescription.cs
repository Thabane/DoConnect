using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Prescription
    {
        public int Patient_ID { get; set; }
        public string Patient_FirstName { get; set; }
        public string Patient_LastName { get; set; }
        public string Patient_DOB { get; set; }
        public int Doctors_ID { get; set; }
        public string Doctors_FirstName { get; set; }
        public string Doctors_LastName { get; set; }
        public int Prescription_DrugDetails_ID { get; set; }
        public int Prescription_DrugDetails_Prescription_ID { get; set; }
        public string Prescription_DrugDetails_DrugName { get; set; }
        public string Prescription_DrugDetails_Strength { get; set; }
        public string Prescription_DrugDetails_IntakeRoute { get; set; }
        public string Prescription_DrugDetails_Frequency { get; set; }
        public int Prescription_DrugDetails_DispenseNumber { get; set; }
        public int Prescription_DrugDetails_RefillNumber { get; set; }
        public int Prescription_ID { get; set; }
        public string Prescription_Date { get; set; }
        public int Consultation_ID { get; set; }
        public string Consultation_ClinicalFindings { get; set; }
        public string Consultation_Diagnosis { get; set; }

        public Prescription Create(SqlDataReader reader)
        {
            return new Prescription
            {
                Patient_ID                                   = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_FirstName                            = reader.GetString(reader.GetOrdinal("Patient_FirstName")),
                Patient_LastName                             = reader.GetString(reader.GetOrdinal("Patient_LastName")),
                Patient_DOB                                  = reader.GetString(reader.GetOrdinal("Patient_DOB")),
                Doctors_ID                                   = reader.GetInt32(reader.GetOrdinal("Doctors_ID")),
                Doctors_FirstName                            = reader.GetString(reader.GetOrdinal("Doctors_FirstName")),
                Doctors_LastName                             = reader.GetString(reader.GetOrdinal("Doctors_LastName")),
                Prescription_DrugDetails_ID                  = reader.GetInt32(reader.GetOrdinal("Prescription_DrugDetails_ID")),
                Prescription_DrugDetails_Prescription_ID     = reader.GetInt32(reader.GetOrdinal("Prescription_DrugDetails_Prescription_ID")),
                Prescription_DrugDetails_DrugName            = reader.GetString(reader.GetOrdinal("Prescription_DrugDetails_DrugName")),
                Prescription_DrugDetails_Strength            = reader.GetString(reader.GetOrdinal("Prescription_DrugDetails_Strength")),
                Prescription_DrugDetails_IntakeRoute         = reader.GetString(reader.GetOrdinal("Prescription_DrugDetails_IntakeRoute")),
                Prescription_DrugDetails_Frequency           = reader.GetString(reader.GetOrdinal("Prescription_DrugDetails_Frequency")),
                Prescription_DrugDetails_DispenseNumber      = reader.GetInt32(reader.GetOrdinal("Prescription_DrugDetails_DispenseNumber")),
                Prescription_DrugDetails_RefillNumber        = reader.GetInt32(reader.GetOrdinal("Prescription_DrugDetails_RefillNumber")),
                Prescription_ID                              = reader.GetInt32(reader.GetOrdinal("Prescription_ID")),
                Prescription_Date	                         = reader.GetString(reader.GetOrdinal("Prescription_Date")),
                Consultation_ClinicalFindings                = reader.GetString(reader.GetOrdinal("Consultation_ClinicalFindings")),
                Consultation_Diagnosis                       = reader.GetString(reader.GetOrdinal("Consultation_Diagnosis"))
            };
        }
    }
}
