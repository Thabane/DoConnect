using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataClient;

namespace DoConnectAdmin.Controllers
{
    public class PatientsController : ApiController
    {
        //[HttpPost]
        //[Route("api/Patients/InsertPatient")]
        //public int InsertPatient(Patient patient)
        //{
        //    DataLayer dtLayer = new DataLayer();
        //    return dtLayer.CreatePatient(patient.FirstName, patient.LastName, patient.ID_Number, patient.Gender, patient.DOB, patient.Cell_Number, patient.Street_Address, patient.Suburb, patient.City, patient.Country);
        //}
        
        [HttpGet]
        [Route("api/Patients/GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();            
        }

        [HttpGet]
        [Route("api/Patients/GetPatient?ID")]
        public List<Patient> GetPatient()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();
        }
    }
}
