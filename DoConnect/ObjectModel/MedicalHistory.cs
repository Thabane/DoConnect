using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class MedicalHistory
    {
        public int ID { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }
        public string Date { get; set; }
        public string ReasonForConsultation { get; set; }
        public string Symptoms { get; set; }
        public string ClinicalFindings { get; set; }
        public string Diagnosis { get; set; }
        public string TestResultSummary { get; set; }
        public string TreatmentPlan { get; set; }
        public int Presciption_ID { get; set; }
        public int Referral_ID { get; set; }
        public int DeletedStatus { get; set; }

        public MedicalHistory Create(SqlDataReader reader)
        {
            return new MedicalHistory
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
                ReasonForConsultation = reader.GetString(reader.GetOrdinal("ReasonForConsultation")),
                Symptoms = reader.GetString(reader.GetOrdinal("Symptoms")),
                ClinicalFindings = reader.GetString(reader.GetOrdinal("ClinicalFindings")),
                Diagnosis = reader.GetString(reader.GetOrdinal("Diagnosis")),
                TestResultSummary = reader.GetString(reader.GetOrdinal("TestResultSummary")),
                TreatmentPlan = reader.GetString(reader.GetOrdinal("TreatmentPlan")),
                Presciption_ID = reader.GetInt32(reader.GetOrdinal("Presciption_ID")),
                Referral_ID = reader.GetInt32(reader.GetOrdinal("Referral_ID")),
                DeletedStatus = reader.GetInt32(reader.GetOrdinal("DeletedStatus"))
            };
        }
    }
}
