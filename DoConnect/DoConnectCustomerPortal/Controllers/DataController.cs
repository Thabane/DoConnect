using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataClient;
using ObjectModel;

namespace DoConnectCustomerPortal.Controllers
{
    public class DataController : Controller
    {
        // GET: /Data/
        public JsonResult UserLogin(LoginData loginData)
        {
            DataLayer dtLayer = new DataLayer();
            Login Login = new Login();
            Login = dtLayer.MyLogin("anacruz@gmail.com", "password");
            if (Login.ID != 0)
            {
                Session["User_ID"] = Login.ID;
            }
            return new JsonResult { Data = Login, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult SessionData()
        {
            Login UserData = new Login();
            UserData.User_ID = Convert.ToInt32(Session["User_ID"]);

            DataLayer dtLayer = new DataLayer();
            Staff Staff = new Staff();
            Staff = dtLayer.GetUserDetailsByUser_ID();// UserData.User_ID);

            Session["FirstName"] = Staff.FirstName;
            Session["LastName"] = Staff.LastName;
            Session["Email"] = Staff.Email;
            Session["Practice_ID"] = Staff.PRACTICE_ID;
            Session["AccessLevel"] = Staff.AccessLevel;
            UserData.FirstName = Convert.ToString(Session["FirstName"]);
            UserData.LastName = Convert.ToString(Session["LastName"]);
            UserData.Email = Convert.ToString(Session["Email"]);
            UserData.Practice_ID = Convert.ToInt32(Session["Practice_ID"]);
            UserData.AccessLevel = Convert.ToInt32(Session["AccessLevel"]);
            return new JsonResult { Data = UserData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

    public class LoginData
    {
        public string Username;
        public string Password;
    }
}