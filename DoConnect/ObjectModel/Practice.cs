using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{    
    public partial class Practice
    {   
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone_Number { get; set; }
        public string Fax_Number { get; set; }
        public string Street_Address { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Trading_Times { get; set; }

        public Practice()
        {}

        public Practice(SqlDataReader reader)
        {
            ID = reader.GetInt32(reader.GetOrdinal("ID"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
            Phone_Number = reader.GetString(reader.GetOrdinal("Phone_Number"));
            Fax_Number = reader.GetString(reader.GetOrdinal("Fax_Number"));
            Street_Address = reader.GetString(reader.GetOrdinal("Street_Address"));
            Suburb = reader.GetString(reader.GetOrdinal("Suburb"));
            City = reader.GetString(reader.GetOrdinal("City"));
            Country = reader.GetString(reader.GetOrdinal("Country"));
            Latitude = reader.GetString(reader.GetOrdinal("Latitude"));
            Longitude = reader.GetString(reader.GetOrdinal("Longitude"));
            Trading_Times = reader.GetString(reader.GetOrdinal("Trading_Times"));
        }
    }
}
