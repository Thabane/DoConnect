using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using ObjectModel;
using DataClient;
using System;
using System.Globalization;

namespace DoConnectCustomerPortal.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/Login/VerifyUser/{Email}")]
        public Login VerifyUser(string Email)
        {
            DataLayer dtLayer = new DataLayer();
            return (new Login());//return dtLayer.MyLogin(Email);
        }

        [HttpPost]
        [Route("api/Login/VerifyPatient")]
        public string VerifyPatient(Login login)
        {
            try
            {
                PatientDataLayer dtLayer = new PatientDataLayer();
                return dtLayer.Portal_Login(login.Email, login.Password).ToString();//return dtLayer.MyLogin(Email);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
