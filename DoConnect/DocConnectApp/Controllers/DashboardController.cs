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

        [HttpGet]
        [Route("api/Dashboard/Consulations_Visits/{Practice_ID}")]
        public List<Consultation> Consulations_Visits(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.Consulations_Visits(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/Appointment_Stats/{Practice_ID}")]
        public List<Consultation> Appointment_Stats(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.Appointment_Stats(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/GetPendingAppointmentsByPracticeID/{Practice_ID}")]
        public List<Appointments> GetPendingAppointmentsByPracticeID(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPendingAppointmentsByPracticeID(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/GetAppovedAppointmentsByPracticeID/{Practice_ID}")]
        public List<Appointments> GetAppovedAppointmentsByPracticeID(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAppovedAppointmentsByPracticeID(Practice_ID);
        }

        [HttpGet]
        [Route("api/Dashboard/GetRejectedAppointmentsByPracticeID/{Practice_ID}")]
        public List<Appointments> GetRejectedAppointmentsByPracticeID(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetRejectedAppointmentsByPracticeID(Practice_ID);
        }

        [HttpPost]
        [Route("api/Dashboard/AppoveAppointment")]
        public bool AppoveAppointment(Appointments appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.AppoveAppointment(appointment.Appointments_ID, appointment.Appointments_App_Status);
        }

        [HttpPost]
        [Route("api/Dashboard/RejectAppointment")]
        public bool RejectAppointment(Appointments appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.RejectAppointment(appointment.Appointments_ID, appointment.Appointments_App_Status);
        }

        [HttpGet]
        [Route("api/Dashboard/GetAllMessages/{Receiver}")]
        public List<Messages> GetAllMessages(int Receiver)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Dashboard/NumOfUnReadMessages/{Receiver}")]
        public Messages NumOfUnReadMessages(int Receiver)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NumOfUnReadMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Dashboard/MedicineInventoryStockCount/{Practice_ID}")]
        public List<Medicine_Inventory> MedicineInventoryStockCount(int Practice_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.MedicineInventoryStockCount(Practice_ID);
        }
    }
}