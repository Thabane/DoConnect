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

        [HttpGet]
        [Route("api/Patients/GetPatient/{ID}")]
        public List<Patient> GetPatientByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPatient(ID);
        }

        [HttpPost]
        [Route("api/Patients/UpdatePatient")]
        public bool UpdatePatient(Patient patient)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdatePatient(patient.User_ID, patient.FirstName, patient.LastName, patient.ID_Number, patient.Gender, patient.DOB, patient.Cell_Number, patient.Street_Address, patient.Suburb, patient.City, patient.Country,patient.Allergies, patient.PreviousIllnesses, patient.PreviousMedication, patient.RiskFactors, patient.SocialHistory, patient.FamilyHistory,patient.Medical_Aid_ID, patient.Doctor_ID);
        }

        /*[HttpPost]
        [Route("api/Patients/InsertPatient")]
        public bool InsertPatient(Patient practice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertPatient(practice.Name, practice.Phone_Number, practice.Fax_Number, practice.Street_Address, practice.Suburb, practice.City, practice.Country, "yu", "uy", practice.Trading_Times);
        }*/

        [HttpPost]
        [Route("api/Patients/DeletePatient/{ID}")]
        public bool DeletePatient(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeletePatient(ID);
        }
    }
}
