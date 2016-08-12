using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ObjectModel
{   
    public class Invoice
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceSummary { get; set; }
        public string Total { get; set; }
        public int Medical_Aid_ID { get; set; }
        public int Patient_ID { get; set; }
        public int Doctor_ID { get; set; }

        public Invoice GetAllInvoice(SqlDataReader reader)
        {
            return new Invoice
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                InvoiceSummary  = reader.GetString(reader.GetOrdinal("InvoiceSummary")),
                Total  = reader.GetString(reader.GetOrdinal("Total")),
                Medical_Aid_ID = reader.GetInt32(reader.GetOrdinal("Medical_Aid_ID")),
                Patient_ID = reader.GetInt32(reader.GetOrdinal("Patient_ID")),
                Doctor_ID = reader.GetInt32(reader.GetOrdinal("Doctor_ID")),
            };
        }
    }
}
