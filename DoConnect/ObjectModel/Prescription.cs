using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Prescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }
    }
}
