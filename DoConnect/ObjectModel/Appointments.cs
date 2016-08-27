using System;
using System.Collections.Generic;

namespace ObjectModel
{    
    public class Appointments
    {
        public int ID { get; set; }
        public bool App_Status { get; set; }
        public DateTime Date_Time { get; set; }
        public string Details { get; set; }  
        public int PatientId { get; set; }  
        public int DoctorId { get; set; }  
        
    }
}
