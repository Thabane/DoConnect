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
        /*[HttpGet]
        [Route("api/Medicines/GetAllMedicines")]
        public List<Medicine_Inventory> GetAllMedicines()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMedicines();
        }

        [HttpGet]
        [Route("api/Medicines/GetMedicine/{ID}")]
        public Medicine_Inventory GetMedicineByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedicine(ID);
        }

        [HttpPost]
        [Route("api/Medicines/UpdateMedicine")]
        public bool UpdateMedicine(Medicine_Inventory medicine)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateMedicine(medicine.ID, medicine.DrugName, medicine.Description, medicine.DrugConcentration, medicine.QuantityInStock, medicine.PurchaseDate, medicine.ExpiryDate, medicine.Practice_ID);
        }

        [HttpPost]
        [Route("api/Medicines/InsertMedicine")]
        public bool InsertMedicine(Medicine_Inventory medicine)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertMedicine(medicine.DrugName, medicine.Description, medicine.DrugConcentration, medicine.QuantityPurchased, medicine.ExpiryDate);
        }

        [HttpPost]
        [Route("api/Medicines/DeleteMedicine/{ID}")]
        public bool DeleteMedicine(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteMedicine(ID);
        }*/
    }
}
