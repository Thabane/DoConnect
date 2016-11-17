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
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAllPractices();
        }
                    
        [HttpGet]
        [Route("api/Practices/GetPractice/{ID}")]
        public Practice GetPracticeByID(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetPracticeById(ID);
        }
    }
}
