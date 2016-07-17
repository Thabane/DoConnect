using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnectAdmin.Controllers
{
    public class PatientsController : ApiController
    {
        //call db method

        [HttpGet]
        [Route("service/GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            return new List<Patient>();
        }
    }
}
