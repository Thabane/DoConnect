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
        [Route("api/Appointments/GetAllAppointments/{patientID}")]
        public List<Appointments> GetAllAppointments(int patientID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAppointmentsByPatientID(patientID);
        }

        [HttpGet] //Select Appointment by ID
        [Route("api/Appointments/GetAppointment/{ID}")]
        public Appointments GetAppointmentByID(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAppointmentById(ID);
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


            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_UpdateAppointment(appointment.Appointments_ID, Date_Time, appointment.Patient_ID, appointment.Appointments_Details, appointment.Appointments_App_Status, appointment.Doctors_ID);
        }

        [HttpPost] //Insert Appointment
        [Route("api/Appointments/InsertAppointment")]
        public bool InsertAppointment(Appointments appointment)
        {
            string date = appointment.Appointments_Date_Time.Substring(0, 10);
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_NewAppointment(date, appointment.Patient_ID, appointment.Appointments_Details, 2, appointment.Doctors_ID);
        }

        [HttpPost]
        [Route("api/Appointments/DeleteAppointment/{ID}")]
        public bool DeleteAppointment(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_DeleteAppointment(ID);
        }

        public string formatDate(string dt)
        {
            string[] date = dt.Split('T');
            string[] TimeSplit = date[1].Split('.');
            return (date[0] + " " + TimeSplit[0]); //YYYY-MM-DD HH:MM:SS
        }
    }
}


