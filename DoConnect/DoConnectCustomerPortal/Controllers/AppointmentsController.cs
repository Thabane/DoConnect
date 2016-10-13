using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;

namespace DoConnectCustomerPortal.Controllers
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
            string Date_Time = "";
            if (appointment.Appointments_Date_Time.Length > 20)
            {   Date_Time = formatDate(appointment.Appointments_Date_Time); }
            else
            { Date_Time = appointment.Appointments_Date_Time;  }


            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateAppointment(appointment.Appointments_ID, Date_Time, appointment.Patient_ID, appointment.Appointments_Details, appointment.Appointments_App_Status, appointment.Doctors_ID);
        }

        [HttpPost] //Insert Appointment
        [Route("api/Appointments/InsertAppointment")]
        public bool InsertAppointment(Appointments appointment)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewAppointment(formatDate(appointment.Appointments_Date_Time), appointment.Patient_ID, appointment.Appointments_Details, appointment.Appointments_App_Status, appointment.Doctors_ID);
        }

        [HttpPost]
        [Route("api/Appointments/DeleteAppointment/{ID}")]
        public bool DeleteAppointment(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteAppointment(ID);
        }

        public string formatDate(string dt)
        {
            string[] date = dt.Split('T');
            string[] TimeSplit = date[1].Split('.');
            return (date[0] + " " + TimeSplit[0]); //YYYY-MM-DD HH:MM:SS
        }
    }
}


