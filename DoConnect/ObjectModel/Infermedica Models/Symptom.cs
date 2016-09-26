using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Infermedica_Models
{
    public class Symptom
    {
        public string id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        //Optional
        public Extras extras { get; set; }
        //Optional
        public List<object> children { get; set; }
        ////Optional 
        ////  --Options--
        ////  - both
        ////  - male
        ////  - female
        public string sex_filter { get; set; }
        //Optional
        public string image_url { get; set; }
        //Optional
        public string image_source { get; set; }
        //Optional
        public string parent_id { get; set; }
        //Optional
        public string parent_relation { get; set; }






        //public enum Parent_Relation
        //{
        //    Severity,
        //    Duration,
        //    Character,
        //    Exacerbating_Factor,
        //    Diminishing_Factor,
        //    Location,
        //    Radiation,
        //    Base
        //}

        //public string id { get; set; }
        //public string name { get; set; }
        //public string question { get; set; }
        ////Optional
        //public string category { get; set; }
        ////Optional
        //public object extras { get; set; }
        ////Optional
        //public object children { get; set; }
        ////Optional 
        ////  --Options--
        ////  - both
        ////  - male
        ////  - female
        //public string sex_filter { get; set; }
        ////Optional
        //public string[] image_url { get; set; }
        ////Optional
        //public string image_source { get; set; }
        ////Optional
        //public string parent_id { get; set; }
        //public Parent_Relation parent_relation { get; set; }//Optional
    }
    public class Extras
    {
    }
}
