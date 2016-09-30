using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Messages
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public Messages Create(SqlDataReader reader)
        {
            return new Messages
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Sender = reader.GetString(reader.GetOrdinal("Sender")),
                Receiver = reader.GetString(reader.GetOrdinal("Receiver")),                
                Subject = reader.GetString(reader.GetOrdinal("Subject")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
            };
        }
    }
}
