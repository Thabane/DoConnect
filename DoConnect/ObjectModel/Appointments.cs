using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class Appointments
    {
        public int ID { get; set; }
        public bool App_Status { get; set; }
        public DateTime Date_Time { get; set; }
        public string Details { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }
    }
}
