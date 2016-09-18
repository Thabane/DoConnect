using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public enum Sex
    {
        male,
        female,
        both
    }

    public enum ChoiceId
    {
        present,
        absent,
        unknown
    }
    public class DiagnosisRequest
    {
        public string sex { get; set; }
        public int age { get; set; }
        public List<Evidence> evidence { get; set; }
        public object extras { get; set; }
        public string evaluated_at { get; set; } //time when evidence was observed in ISO 8601 

    }

    public class Evidence
    {
        public string id { get; set; } //id of observation, risk factor or condition 
        public string choice_id { get; set; }
    }
}
