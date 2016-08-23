﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Consultation
    {
        public int ID { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }
        public DateTime Date { get; set; }
        public string ReasonForConsultation { get; set; }
        public string Symptoms { get; set; }
        public string ClinicalFindings { get; set; }
        public string Diagnosis { get; set; }
        public string TestResultSummary { get; set; }
        public string TreatmentPlan { get; set; }
        public int Presciption_ID { get; set; }
        public int Referral_ID { get; set; }

        public Consultation Create(SqlDataReader reader)
        {
            return new Consultation
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                ReasonForConsultation = reader.GetString(reader.GetOrdinal("ReasonForConsultation")),
                Symptoms = reader.GetString(reader.GetOrdinal("Symptoms")),
                ClinicalFindings = reader.GetString(reader.GetOrdinal("ClinicalFindings")),
                Diagnosis = reader.GetString(reader.GetOrdinal("Diagnosis")),
                TestResultSummary = reader.GetString(reader.GetOrdinal("TestResultSummary")),
                TreatmentPlan = reader.GetString(reader.GetOrdinal("TreatmentPlan")),
                Presciption_ID = reader.GetInt32(reader.GetOrdinal("Presciption_ID")),
                Referral_ID = reader.GetInt32(reader.GetOrdinal("Referral_ID")),
            };
        }
    }
}
