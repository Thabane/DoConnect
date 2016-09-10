using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Events
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int AppointmentStatus { get; set; }

        public Events Create(SqlDataReader reader)
        {
            return new Events
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Details = reader.GetString(reader.GetOrdinal("Details")),
                StartDateTime = reader.GetDateTime(reader.GetOrdinal("StartDateTime")),
                EndDateTime = reader.GetDateTime(reader.GetOrdinal("EndDateTime")),
                AppointmentStatus = reader.GetInt32(reader.GetOrdinal("AppointmentStatus")),
            };
        }
    }
}
