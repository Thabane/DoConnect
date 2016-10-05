using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using ObjectModel;
using DataClient;
using System.Globalization;

namespace DocConnectApp.Controllers
{
    public class DashboardController : ApiController
    {
        [HttpGet]
        [Route("api/Dashboard/GetRevenueSummary_Today/{Practice_ID}")]
        public Invoice GetRevenueSummary_Today(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetRevenueSummary_Today(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/GetRevenueSummary_Week/{Practice_ID}")]
        public Invoice GetRevenueSummary_Week(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetRevenueSummary_Week(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/GetNumPatientsByPractice/{Practice_ID}")]
        public Invoice GetNumPatientsByPractice(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetNumPatientsByPractice(Practice_ID);
        }
    }
}