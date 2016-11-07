using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoConnectCustomerPortal.Controllers
{
    public class PatientLoginController : Controller
    {
        // GET: PatientLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientLogin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientLogin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientLogin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
