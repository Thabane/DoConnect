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
        public int Sender { get; set; }//Refers to Sender's User_ID
        public int Receiver { get; set; }//Refers to Receiver's User_ID
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public int NumOfUnReadMessages { get; set; }
        public int ReadStatus { get; set; } //0 == read //1 == unread

        public Messages Create(SqlDataReader reader)
        {
            return new Messages
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Sender = reader.GetInt32(reader.GetOrdinal("Sender")),
                Receiver = reader.GetInt32(reader.GetOrdinal("Receiver")),
                Subject = reader.GetString(reader.GetOrdinal("Subject")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                Date = reader.GetString(reader.GetOrdinal("Date")),
                ReceiverEmail = reader.GetString(reader.GetOrdinal("ReceiverEmail")),
                ReadStatus = reader.GetInt32(reader.GetOrdinal("ReadStatus")),
                NumOfUnReadMessages = reader.GetInt32(reader.GetOrdinal("NumOfUnReadMessages"))
            };
        }

        public Messages readerMessageSender(SqlDataReader reader)
        {
            return new Messages
            {
                SenderEmail = reader.GetString(reader.GetOrdinal("SenderEmail"))
            };
        }
    }
}
