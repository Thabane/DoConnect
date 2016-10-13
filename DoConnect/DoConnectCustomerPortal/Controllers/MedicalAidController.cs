using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;

namespace DoConnectCustomerPortal.Controllers
{
    public class MedicalAidController : ApiController
    {
        [HttpGet]
        [Route("api/MedicalAids/GetAllMedicalAids")]
        public List<Medical_Aid> GetAllMedicalAids()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMedicalAid();
        }

        [HttpGet]
        [Route("api/MedicalAids/GetMedicalAid/{ID}")]
        public Medical_Aid GetMedicalAidByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMedicalAid(ID);
        }

        /*
        [HttpPost]
        [Route("api/MedicalAids/UpdateMedicalAid")]
        public bool UpdateMedicalAid(Medical_Aid medical_Aid)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateMedicalAid(medical_Aid.ID, medical_Aid.Name, medical_Aid.Cell_Number, medical_Aid.Fax_Number, medical_Aid.Email_Address, medical_Aid.Address);
        }

        [HttpPost]
        [Route("api/MedicalAids/InsertMedicalAid")]
        public bool InsertMedicalAid(Medical_Aid medical_Aid)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertMedicalAid(medical_Aid.ID, medical_Aid.Name, medical_Aid.Cell_Number, medical_Aid.Fax_Number, medical_Aid.Email_Address, medical_Aid.Address);
        }

        [HttpPost]
        [Route("api/MedicalAids/DeleteMedicalAid/{ID}")]
        public bool DeleteMedicalAid(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteMedicalAid(ID);
        }*/
    }
}
