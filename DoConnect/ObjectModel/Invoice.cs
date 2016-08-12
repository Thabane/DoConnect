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
    }
}
