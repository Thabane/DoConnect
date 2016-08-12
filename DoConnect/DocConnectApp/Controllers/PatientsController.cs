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
    public class PatientsController : ApiController
    {        
        [HttpGet]
        [Route("api/Patients/GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();            
        }
    }
}
