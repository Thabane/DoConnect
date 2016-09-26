using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class GetAllPatients
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID_Number { get; set; }
        public string Cell_Number { get; set; }
        public int User_ID { get; set; }
        public string Email { get; set; }
        public int Medical_Aid_ID { get; set; }
        public string PatientFullName { get; set; }

        public GetAllPatients Create(SqlDataReader reader)
        {
            return new GetAllPatients
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                ID_Number = reader.GetString(reader.GetOrdinal("ID_Number")),               
                Cell_Number = reader.GetString(reader.GetOrdinal("Cell_Number")),                
                User_ID = reader.GetInt32(reader.GetOrdinal("User_ID")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                PatientFullName = reader.GetString(reader.GetOrdinal("PatientFullName")),
            };
        }
    }
}
