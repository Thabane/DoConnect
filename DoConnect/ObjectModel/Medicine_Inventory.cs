﻿using System;
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
        public string PurchaseDate { get; set; }
        public int QuantityInStock { get; set; }
        public string ExpiryDate { get; set; }
        public string DrugConcentration { get; set; }
        public int Practice_ID { get; set; }
        public string PracticeName { get; set; }

        public int highlightqtyAboutToExpier  { get; set; }
        public int qtyAboutToExpier           { get; set; }
        public int highlightqtyExpiered       { get; set; }
        public int qtyExpiered                { get; set; }
        public int highlightqtyNeedRefill     { get; set; }
        public int qtyNeedRefill              { get; set; }

        public Medicine_Inventory Create(SqlDataReader reader)
        {
            return new Medicine_Inventory
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                DrugName = reader.GetString(reader.GetOrdinal("DrugName")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                QuantityPurchased = reader.GetInt32(reader.GetOrdinal("QuantityPurchased")),
                PurchaseDate = reader.GetString(reader.GetOrdinal("PurchaseDate")),
                QuantityInStock = reader.GetInt32(reader.GetOrdinal("QuantityInStock")),
                ExpiryDate = reader.GetString(reader.GetOrdinal("ExpiryDate")),
                DrugConcentration = reader.GetString(reader.GetOrdinal("DrugConcentration")),
                Practice_ID = reader.GetInt32(reader.GetOrdinal("Practice_ID")),
                PracticeName = reader.GetString(reader.GetOrdinal("PracticeName"))
            };
        }        

        public Medicine_Inventory MedicineInventoryStockCount(SqlDataReader reader)
        {
            return new Medicine_Inventory
            {
                DrugName = reader.GetString(reader.GetOrdinal("DrugName")),
                QuantityInStock = reader.GetInt32(reader.GetOrdinal("QuantityInStock"))
            };
        }
    }
}
