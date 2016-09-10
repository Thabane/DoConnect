using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public Medicine_Inventory Create(SqlDataReader reader)
        {
            return new Medicine_Inventory
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                DrugName = reader.GetString(reader.GetOrdinal("DrugName")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                QuantityPurchased = reader.GetInt32(reader.GetOrdinal("QuantityPurchased")),
                PurchaseDate = reader.GetDateTime(reader.GetOrdinal("PurchaseDate")),
                QuantityInStock = reader.GetInt32(reader.GetOrdinal("QuantityInStock")),
                ExpiryDate = reader.GetDateTime(reader.GetOrdinal("ExpiryDate")),
                DrugConcentration = reader.GetString(reader.GetOrdinal("DrugConcentration")),
                Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID")),
            };
        }
    }
}
