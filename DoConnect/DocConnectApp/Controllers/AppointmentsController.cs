using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;

namespace DoConnectAdmin.Controllers
{
    public class AppointmentsController : ApiController
    {
        [HttpGet]//Select all Appointments data
        [Route("api/Appointments/GetAllAppointments")]
        public List<Appointments> GetAllAppointments()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllAppointments();
        }

        [HttpGet] //Select Appointment by ID
        [Route("api/Appointments/GetAppointment/{ID}")]
        public Appointments GetAppointmentByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAppointment(ID);
        }

        [HttpPost]//Update Appointment
        [Route("api/Appointments/UpdateAppointment")]
        public bool UpdateAppointment(Appointment appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateAppointment(appointment.ID,  appointment.Date_Time, appointment.Patient_ID, appointment.Details, appointment.App_Status);
        }

        [HttpPost] //Insert Appointment
        [Route("api/Appointments/InsertAppointment")]
        public bool InsertAppointment(Appointment appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertAppointment(appointment.Date_Time, appointment.Patient_ID, appointment.Details, appointment.App_Status);
        }

        [HttpPost]
        [Route("api/Appointments/DeleteAppointment/{ID}")]
        public bool DeleteAppointment(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteAppointment(ID);
        }
    }
}


