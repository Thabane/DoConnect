using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocConnectApp.Models;
using DataClient;
using ObjectModel;

namespace DocConnectApp.Controllers
{
    public class DataController : Controller
    {
        // GET: /Data/
        public JsonResult UserLogin(LoginData loginData)
        {
            DataLayer dtLayer = new DataLayer();
            Login Login = new Login();
            Login = dtLayer.MyLogin(loginData.Username, loginData.Password);
            if (Login.ID != 0)
            {
                Session["User_ID"] = Login.ID;
                Session["User_Email"] = Login.Email;
                GetUserDetailsByUser_ID(Login.ID);
            }
            return new JsonResult { Data = Login, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ViewResult GetUserDetailsByUser_ID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return View(dtLayer.GetUserDetailsByUser_ID(ID));
        }
    }
}