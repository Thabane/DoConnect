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
    }
}
