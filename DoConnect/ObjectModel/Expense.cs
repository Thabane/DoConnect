using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Expense
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }
        public int Practice_ID { get; set; }
        public int User_ID { get; set; }
    }
}
