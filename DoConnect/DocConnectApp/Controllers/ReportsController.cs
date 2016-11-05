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

        [HttpGet]
        [Route("api/Reports/FinancialReport_All/{StartDate}/{EndDate}")]
        public List<Consultation> FinancialReport_All(string StartDate, string EndDate)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.FinancialReport_All(StartDate, EndDate);
        }

        [HttpGet]
        [Route("api/Reports/FinancialReportByPracticeID/{Practice_ID}/{StartDate}/{EndDate}")]
        public List<Consultation> FinancialReportByPracticeID(int Practice_ID, string StartDate, string EndDate)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.FinancialReportByPracticeID(Practice_ID, StartDate, EndDate);
        }

    }
}
