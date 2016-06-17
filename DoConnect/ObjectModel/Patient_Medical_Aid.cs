using System;
using System.Collections.Generic;

namespace ObjectModel
{   
    public class Patient_Medical_Aid
    {
        public int ID { get; set; }
        public string Scheme_Name { get; set; }
        public string Membership_Number { get; set; }
        public bool Status { get; set; }
        public DateTime Registration_Date { get; set; }
        public DateTime Deregistration_Date { get; set; }
    }
}
