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
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctors_ID")),
                Date = reader.GetString(reader.GetOrdinal("Consultation_Date")),
                ReasonForConsultation = reader.GetString(reader.GetOrdinal("Consultation_ReasonForConsultation")),
                Symptoms = reader.GetString(reader.GetOrdinal("Consultation_Symptoms")),
                ClinicalFindings = reader.GetString(reader.GetOrdinal("Consultation_ClinicalFindings")),
                Diagnosis = reader.GetString(reader.GetOrdinal("Consultation_Diagnosis")),
                TestResultSummary = reader.GetString(reader.GetOrdinal("Consultation_TestResultSummary")),
                TreatmentPlan = reader.GetString(reader.GetOrdinal("Consultation_TreatmentPlan")),
                Presciption_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Presciption_ID")),
                Referral_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Referral_ID"))
                //DeletedStatus = reader.GetInt32(reader.GetOrdinal("DeletedStatus"))
            };
        }

        public void SetMedRecord(SqlDataReader reader)
        {
            Diagnosis = reader.GetString(reader.GetOrdinal("Consultation_Diagnosis"));
            TestResultSummary = reader.GetString(reader.GetOrdinal("Consultation_TestResultSummary"));
            TreatmentPlan = reader.GetString(reader.GetOrdinal("Consultation_TreatmentPlan"));
            Presciption_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Presciption_ID"));
        }
    }
}
