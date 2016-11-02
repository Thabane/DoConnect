using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataClient;

namespace DocConnectApp.Controllers
{
    public class ReportsController : ApiController
    {
        [HttpGet]
        [Route("api/Reports/GetAllPatientsByPracticeID/{ID}")]
        public List<GetAllPatients> GetAllPatientsByPracticeID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatientsByPracticeID(ID);
        }

    }
}
