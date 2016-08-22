using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public  class Patient_Consultation
    {
        public int ID { get; set; }
        public int Patient_ID { get; set; }
        
        public Patient_Consultation Create(SqlDataReader reader)
        {
            return new Patient_Consultation
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
            };
        }
    }
}
