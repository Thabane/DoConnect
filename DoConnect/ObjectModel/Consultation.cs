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
    }
}
