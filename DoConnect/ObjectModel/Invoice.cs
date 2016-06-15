using System;
using System.Collections.Generic;

namespace ObjectModel
{   
    public class Invoice
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }   
    }
}
