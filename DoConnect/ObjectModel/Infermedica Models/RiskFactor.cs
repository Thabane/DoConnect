using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public class RiskFactor
    {
        public string id { get; set; }
        public string name { get; set; }
        public string question { get; set; } // only available in object details, not in listing 
        public string category { get; set; }
        public object extras { get; set; }
        public Sex sex_filter { get; set; }
        public string image_url { get; set; }
        public string image_source { get; set; }
    }
}
