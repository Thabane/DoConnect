using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataClient;

namespace DocConnectApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        //[System.Web.Mvc.HttpPost]
        //public ActionResult Login(string username, string password)
        //{
        //    IDataLayer dl = new DataLayer();
        //    return RedirectToAction("Login");
        //}
    }
}
