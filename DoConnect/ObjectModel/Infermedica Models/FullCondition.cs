using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public class FullCondition
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] categories { get; set; }
        public string prevalence { get; set; }
        public string acuteness { get; set; }
        public string severity { get; set; }
        public object extras { get; set; }
        public string sex_filter { get; set; }

    }

    public enum Prevalence
    {
        very_rare,
        rare,
        moderate,
        common
    }

    public enum Acuteness
    {
        chronic,
        chronic_with_exacerbations,
        acute_potentially_chronic,
        acute
    }

    public enum Severity
    {
        mild,
        moderate,
        severe
    }
}
