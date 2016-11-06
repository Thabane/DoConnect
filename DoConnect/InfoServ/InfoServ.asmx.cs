using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Script.Services;
using System.Xml.Serialization;
using System.Web.Services;
using DataClient;
using ObjectModel;

namespace InfoServ
{
    /// <summary>
    /// Summary description for InfoServ
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class InfoServ : WebService
    {
        /// <summary>
        /// Gets the patient profile.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [WebMethod]
        public void GetPatientProfile(int id)
        {
                AppMethods am = new AppMethods();
                string patient = am.GetPatientByID(id);
                HttpContext.Current.Response.Write($"{patient}");        
        }

        /// <summary>
        /// Updates the patient profile.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="idNumber">The identifier number.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="cellNumber">The cell number.</param>
        /// <param name="medicalAidId">The medical aid identifier.</param>
        /// <param name="doctorId">The doctor identifier.</param>
        /// <param name="streetaddress">The streetaddress.</param>
        /// <param name="suburb">The suburb.</param>
        /// <param name="city">The city.</param>
        /// <param name="country">The country.</param>
        [WebMethod]
        public void UpdatePatientProfile(int userId, string firstName, string lastName, string idNumber, char gender, string dob, string cellNumber, int medicalAidId, int doctorId, string streetaddress, string suburb, string city, string country)
        {
            AppMethods am = new AppMethods();
            bool patient = am.UpdatePatient(userId, firstName, lastName, idNumber, gender, dob, cellNumber, medicalAidId, doctorId, streetaddress, suburb, city, country);

            if (patient)
            {
                HttpContext.Current.Response.Write("true");
            }
            else
            {
                HttpContext.Current.Response.Write("false");
            }
        }

        [WebMethod]
        public void GetAppointmentsById(int id)
        {
            AppMethods am = new AppMethods();
            string appointment = am.GetApppointmentsById(id);
            HttpContext.Current.Response.Write($"{appointment}");
        }

        [WebMethod]
        public void Login(string email, string password)
        {
            AppMethods am = new AppMethods();
            string user = am.Login(email, password);
            HttpContext.Current.Response.Write($"{user}");
        }

        [WebMethod]
        public void GetAppointmentForPatient(int id)
        {
            AppMethods am = new AppMethods();
            string app = am.GetApppointmentsById(id);
            HttpContext.Current.Response.Write($"{app}");
        }

        [WebMethod]
        public void GetSingleAppointment(int id)
        {
            AppMethods am = new AppMethods();
            string singleApp = am.GetApppointmentsById(id);
            HttpContext.Current.Response.Write($"{singleApp}");
        }

        [WebMethod]
        public void RegisterPatient(string firstName, string lastName, string dob, string idNumber, char gender, string postalAddress, string email, string password)
        {
            AppMethods am = new AppMethods();
            string reg = am.RegisterPatient(firstName, lastName, idNumber, dob, gender, postalAddress, email, password);
            HttpContext.Current.Response.Write($"{reg}");
        }
    }
}
