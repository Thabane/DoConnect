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
    public class PracticesController : ApiController
    {
        [HttpGet]
        [Route("api/Practices/GetAllPractices")]
        public List<Practice> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPractices();
        }        

        [HttpPost]
        [Route("api/Practices/InsertPractice")]
        public bool InsertPractice(Practice practice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertPractice(practice.Name, practice.Phone_Number, practice.Fax_Number, practice.Street_Address, practice.Suburb, practice.City, practice.Country, "yu", "uy", practice.Trading_Times);
        }

        
    }
}
