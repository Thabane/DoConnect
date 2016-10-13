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
    public class DoctorsController : ApiController
    {
        [HttpGet]
        [Route("api/Doctors/GetAllDoctors")]
        public List<Doctor> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllDoctors();
        }
                    
        [HttpGet]
        [Route("api/Doctors/GetDoctor/{ID}")]
        public Doctor GetPracticeByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetDoctorById(ID);
        }
    }
}
