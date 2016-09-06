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

namespace DocConnectApp.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/Login/VerifyUser/{Email}")]
        public Login VerifyUser(string Email)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.MyLogin(Email);
        }
    }
}
