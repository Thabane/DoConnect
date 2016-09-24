using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;

namespace DocConnectApp.Controllers
{
    public class MedicineInventoryController : ApiController
    {
        [HttpGet]
        [Route("api/MedicineInventory/GetAllMedicines")]
        public List<Medicine_Inventory> GetAllMedicines()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMedicine_Inventory();
        }

        [HttpGet]
        [Route("api/MedicineInventory/GetMedicine/{ID}")]
        public Medicine_Inventory GetMedicineByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedicine_InventoryById(ID);
        }

        [HttpPost]
        [Route("api/MedicineInventory/UpdateMedicine")]
        public bool UpdateMedicine(Medicine_Inventory medicine)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateMedicine_Inventory(medicine.ID, medicine.DrugName, medicine.Description, medicine.QuantityInStock, medicine.DrugConcentration);
        }

        [HttpPost]
        [Route("api/MedicineInventory/InsertMedicine")]
        public bool InsertMedicine(Medicine_Inventory medicine)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewMedicine_Inventory(medicine.DrugName, medicine.Description, medicine.QuantityPurchased, medicine.PurchaseDate, medicine.ExpiryDate, medicine.DrugConcentration, medicine.Practice_ID);
        }

        [HttpPost]
        [Route("api/MedicineInventory/DeleteMedicine/{ID}")]
        public bool DeleteMedicine(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteMedicine_Inventory(ID);
        }
    }
}
