using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Prescription_DrugDetails
    {
        public int ID { get; set; }
        public int Prescription_ID { get; set; }
        public string DrugName { get; set; }
        public string Strength { get; set; }
        public string IntakeRoute { get; set; }
        public string Frequency { get; set; }
        public int DispenseNumber { get; set; }
        public int RefillNumber { get; set; }
    }
}
