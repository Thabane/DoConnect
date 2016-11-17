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
            return dtLayer.GetAppointments();
        }        

        [HttpGet]//Select all Appointments data
        [Route("api/Appointments/GetAllDoctors")]
        public List<Doctor> GetAllDoctors()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllDoctors();
        }

        [HttpGet]
        [Route("api/Appointments/GetAllPractices")]
        public List<Practice> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPractices();
        }

        [HttpGet] //Select Appointment by ID
        [Route("api/Appointments/GetAppointment/{ID}")]
        public Appointments GetAppointmentByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAppointmentById(ID);
        }

        [HttpGet]
        [Route("api/Appointments/GetAllPatients")]
        public List<GetAllPatients> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatients();
        }

        [HttpPost]//Update Appointment
        [Route("api/Appointments/UpdateAppointment")]
        public bool UpdateAppointment(Appointments appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateAppointment(appointment.Appointments_ID, appointment.Appointments_Date_Time, appointment.Patient_ID, appointment.Appointments_Details, appointment.Appointments_App_Status, appointment.Doctors_ID);
        }

        [HttpPost] //Insert Appointment
        [Route("api/Appointments/InsertAppointment")]
        public bool InsertAppointment(Appointments appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewAppointment(appointment.Appointments_Date_Time, appointment.Patient_ID, appointment.Appointments_Details, appointment.Appointments_App_Status, appointment.Doctors_ID);
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


