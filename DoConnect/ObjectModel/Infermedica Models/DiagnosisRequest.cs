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
        public string age { get; set; }
        public List<Evidence> evidence { get; set; }
    }

    public class Evidence
    {
        public string id { get; set; } //id of observation, risk factor or condition 
        public string choice_id { get; set; }
    }
}
