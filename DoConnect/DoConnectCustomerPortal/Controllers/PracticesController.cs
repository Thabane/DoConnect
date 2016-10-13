using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;
using System.Web.Http.Description;

namespace DoConnectCustomerPortal.Controllers
{
    public class PracticesController : ApiController
    {
        [HttpGet]
        [Route("api/Practices/GetAllPractices")]
        public List<Practice> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPractices();
        }
                    
        [HttpGet]
        [Route("api/Practices/GetPractice/{ID}")]
        public Practice GetPracticeByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPracticeById(ID);
        }

        [HttpPost]
        [Route("api/Practices/UpdatePractice")]
        public bool UpdatePractice(Practice practice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdatePractice(practice.ID, practice.Name, practice.Phone_Number, practice.Fax_Number, practice.Street_Address, practice.Suburb, practice.City, practice.Country, "yu", "uy", practice.Trading_Times);
        }

        [HttpPost]
        [Route("api/Practices/InsertPractice")]
        public bool InsertPractice(Practice practice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertPractice(practice.Name, practice.Phone_Number, practice.Fax_Number, practice.Street_Address, practice.Suburb, practice.City, practice.Country, "yu", "uy", practice.Trading_Times);
        }        
        
        [HttpPost]
        [Route("api/Practices/DeletePractice/{ID}")]
        public bool DeletePractice(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeletePractice(ID);
        }
    }
}
