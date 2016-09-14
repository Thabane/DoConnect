using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public class Condition
    {
        public string id { get; set; }
        public string name { get; set; }
        public string[] categories { get; set; }
        public Prevalence prevalence { get; set; }
        public Acuteness acuteness { get; set; }
        public Severity severity { get; set; }
        public object extras { get; set; }
        public Sex sex_filter { get; set; }

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
