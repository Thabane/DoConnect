using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public class Medical_Aid
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Cell_Number { get; set; }
        public string Fax_Number { get; set; }
        public string Email_Address { get; set; }
        public string Address { get; set; }

        public Medical_Aid Create(SqlDataReader reader)
        {
            return new Medical_Aid
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Cell_Number = reader.GetString(reader.GetOrdinal("Cell_Number")),
                Fax_Number = reader.GetString(reader.GetOrdinal("Fax_Number")),
                Email_Address = reader.GetString(reader.GetOrdinal("Email_Address")),
                Address = reader.GetString(reader.GetOrdinal("Address"))
            };
        }
    }
}
