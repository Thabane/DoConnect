using DataClient;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnectCustomerPortal.Controllers
{
    public class MedicalHistoryController : ApiController
    {
        [HttpGet]
        [Route("api/MedicalHistory/GetMedicalHistoryByPatientID/{patientID}")]
        public List<MedicalHistory> GetMedicalHistoryByPatientID(int patientID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetMedicalHistoryByPatientID(patientID);
        }
        
        [HttpGet]
        [Route("api/MedicalHistory/Portal_GetMedicalHistoryID/{id}")]
        public MedicalHistory Portal_GetMedicalHistoryID(int id)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetMedicalHistoryID(id);
        }
    }
}
