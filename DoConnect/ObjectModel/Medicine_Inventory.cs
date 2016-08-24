using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel
{
    public class Medicine_Inventory
    {
        public int ID { get; set; }
        public string DrugName { get; set; }
        public string Description { get; set; }
        public int QuantityPurchased { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DrugConcentration { get; set; }
        public int Practice_ID { get; set; }
    }
}
