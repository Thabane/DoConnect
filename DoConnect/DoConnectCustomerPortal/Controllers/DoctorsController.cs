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
        public List<Doctor> GetAllDoctors()
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAllDoctors();
        }

        [HttpGet]
        [Route("api/Doctors/GetDoctor/{ID}")]
        public Doctor GetPracticeByID(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetDoctorById(ID);
        }


        [HttpGet]
        [Route("api/Doctors/SetAsPreffered/{PrefferedDoctor}")]
        public Doctor SetAsPreffered(int PrefferedDoctor)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetDoctorById(PrefferedDoctor);
        }
    }
}
