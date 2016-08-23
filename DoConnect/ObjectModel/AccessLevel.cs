using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class AccessLevel
    {
        public int ID { get; set; }
        public string Level { get; set; }

        public AccessLevel Create(SqlDataReader reader)
        {
            return new AccessLevel
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Level = reader.GetString(reader.GetOrdinal("App_Status"))                
            };
        }
    }
}
