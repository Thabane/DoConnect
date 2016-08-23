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

        public Prescription_DrugDetails Create(SqlDataReader reader)
        {
            return new Prescription_DrugDetails
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Prescription_ID = reader.GetInt32(reader.GetOrdinal("Prescription_ID")),
                DrugName = reader.GetString(reader.GetOrdinal("DrugName")),
                Strength = reader.GetString(reader.GetOrdinal("Strength")),
                IntakeRoute = reader.GetString(reader.GetOrdinal("IntakeRoute")),
                Frequency = reader.GetString(reader.GetOrdinal("Frequency")),
                DispenseNumber = reader.GetInt32(reader.GetOrdinal("DispenseNumber")),
                RefillNumber = reader.GetInt32(reader.GetOrdinal("RefillNumber")),
            };
        }
    }
}
