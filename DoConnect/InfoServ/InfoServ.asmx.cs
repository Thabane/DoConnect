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
        [WebMethod]
        public void GetPatientProfile(int id)
        {
                AppMethods am = new AppMethods();
                string patient = am.GetPatientByID(id);
                HttpContext.Current.Response.Write($"{patient}");        
        }
    }
}
