using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObjectModel
{
    public class Expenses
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public int Practice_ID { get; set; }
        public string User_ID { get; set; }
    }
}
