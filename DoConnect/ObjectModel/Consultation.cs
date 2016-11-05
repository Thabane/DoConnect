using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Consultation
    {
        public int Patient_ID { get; set; }
        public string Patient_FirstName { get; set; }
        public string Patient_LastName { get; set; }
        public string Doctors_FirstName { get; set; }
        public string Doctors_LastName { get; set; }
        public string Doctors_Email { get; set; }
        public int Doctors_ID { get; set; }
        public int Consultation_ID { get; set; }
        public int Consultation_Patient_ID { get; set; }
        public int Consultation_Doctor_ID { get; set; }
        public string Consultation_Date { get; set; }
        public string Consultation_ReasonForConsultation { get; set; }
        public string Consultation_Symptoms { get; set; }
        public string Consultation_ClinicalFindings { get; set; }
        public string Consultation_Diagnosis { get; set; }
        public string Consultation_TestResultSummary { get; set; }
        public string Consultation_TreatmentPlan { get; set; }
        public int Consultation_Presciption_ID { get; set; }
        public int Consultation_Referral_ID { get; set; }
        public int Patient_Consultation_ID { get; set; }
        public int Patient_Consultation_Patient_ID { get; set; }
        public int TotalNumOfVisits { get; set; }
        public int TotalPatientsCount { get; set; }
        public string Month { get; set; }

        public string PatientFullName   { get; set; }
        public string Email             { get; set; }
        public string Gender            { get; set; }
        public string DOB               { get; set; }
        public string Date              { get; set; }
        public string Diagnosis         { get; set; }
        public decimal Total             { get; set; }
        public decimal AmountPaid        { get; set; }
        public decimal BalanceOwing { get; set; }

        public Consultation Create(SqlDataReader reader)
        {
            return new Consultation
            {
                
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Patient_FirstName = reader.GetString(reader.GetOrdinal("Patient_FirstName")),
                Patient_LastName = reader.GetString(reader.GetOrdinal("Patient_LastName")),
                Doctors_FirstName = reader.GetString(reader.GetOrdinal("Doctors_FirstName")),
                Doctors_LastName = reader.GetString(reader.GetOrdinal("Doctors_LastName")),
                Doctors_Email = reader.GetString(reader.GetOrdinal("Doctors_Email")),
                Doctors_ID = reader.GetInt32(reader.GetOrdinal("Doctors_ID")),
                Consultation_ID = reader.GetInt32(reader.GetOrdinal("Consultation_ID")),
                Consultation_Patient_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Patient_ID")),
                Consultation_Doctor_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Doctor_ID")),            
                Consultation_Date = reader.GetString(reader.GetOrdinal("Consultation_Date")),
                Consultation_ReasonForConsultation = reader.GetString(reader.GetOrdinal("Consultation_ReasonForConsultation")),
                Consultation_Symptoms = reader.GetString(reader.GetOrdinal("Consultation_Symptoms")),
                Consultation_ClinicalFindings = reader.GetString(reader.GetOrdinal("Consultation_ClinicalFindings")),
                Consultation_Diagnosis = reader.GetString(reader.GetOrdinal("Consultation_Diagnosis")),
                Consultation_TestResultSummary = reader.GetString(reader.GetOrdinal("Consultation_TestResultSummary")),
                Consultation_TreatmentPlan = reader.GetString(reader.GetOrdinal("Consultation_TreatmentPlan")),
                Consultation_Presciption_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Presciption_ID")),
                Consultation_Referral_ID = reader.GetInt32(reader.GetOrdinal("Consultation_Referral_ID")),
                Patient_Consultation_ID = reader.GetInt32(reader.GetOrdinal("Patient_Consultation_ID")),
                Patient_Consultation_Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_Consultation_Patient_ID"))
            };
        }

        public Consultation Consulations_Visits(SqlDataReader reader)
        {
            return new Consultation
            {
                TotalNumOfVisits = reader.GetInt32(reader.GetOrdinal("TotalNumOfVisits")),
                Month = reader.GetString(reader.GetOrdinal("Month"))
            };
        }

        public Consultation FinancialReportByPracticeID(SqlDataReader reader)
        {
            return new Consultation
            {
                PatientFullName  = reader.GetString(reader.GetOrdinal("PatientFullName")),
                Email            = reader.GetString(reader.GetOrdinal("Email")),
                Gender           = reader.GetString(reader.GetOrdinal("Gender")),
                DOB              = reader.GetString(reader.GetOrdinal("DOB")),
                Date             = reader.GetString(reader.GetOrdinal("Date")),
                Diagnosis        = reader.GetString(reader.GetOrdinal("Diagnosis")),
                Total            = reader.GetDecimal(reader.GetOrdinal("Total")),
                AmountPaid       = reader.GetDecimal(reader.GetOrdinal("AmountPaid")),
                BalanceOwing     = reader.GetDecimal(reader.GetOrdinal("BalanceOwing")),
            };
        }
    }
}
