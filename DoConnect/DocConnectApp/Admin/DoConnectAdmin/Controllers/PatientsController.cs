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
        [HttpGet]
        [Route("api/Patients/GetAllPatients")]
        public List<Patient> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();            
        }

        [HttpPost]
        [Route("api/Patients/InsertPatient")]
        public bool InsertPatient(Patient patient)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.CreatePatient(patient.FirstName, patient.LastName, patient.ID_Number, patient.Gender, patient.DOB, patient.Cell_Number, patient.Street_Address, patient.Suburb, patient.City, patient.Country, patient.Allergies, patient.PreviousIllnesses, patient.PreviousMedication, patient.RiskFactors, patient.SocialHistory, patient.FamilyHistory, patient.Medical_Aid_ID, patient.Doctor_ID, patient.User_ID);
        }

        //[HttpGet]
        //[Route("api/Patients/GetPatient?ID")]
        //public List<Patient> GetPatient()
        //{
        //    DataLayer dtLayer = new DataLayer();
        //    return dtLayer.GetAllPatients();
        //}
    }
}
