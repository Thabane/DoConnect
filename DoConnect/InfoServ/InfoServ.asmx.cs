using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Xml.Serialization;
using System.Web.Services;
using DataClient;

namespace InfoServ
{
    /// <summary>
    /// Summary description for InfoServ
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InfoServ : WebService
    {

        [WebMethod]
        public bool Login(string username, string password)
        {
            return false;
        }

        [WebMethod(MessageName = "OpenAccount", Description = "The method creates an account")]
        [XmlInclude(typeof(ContactResult))]
        public string GetPatientProfile(string patID)
        {
            return patID;
        }
    }
}
