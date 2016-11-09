﻿using System.Net;
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
    public class EmployeesController : ApiController
    {
        [HttpGet]//Select all Employee data
        [Route("api/Employees/GetAllEmployees")]
        public List<Staff> GetAllEmployees()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllStaff();
        }

        [HttpGet] //Select Employee by ID
        [Route("api/Employees/GetEmployee/{ID}")]
        public Staff GetEmployeeByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetStaffById(ID);
        }

        [HttpPost]//Update Employee
        [Route("api/Employees/UpdateEmployee")]
        public bool UpdateEmployee(Staff staff)
        {            
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateStaff(staff.ID, staff.FirstName, staff.LastName, staff.ID_Number, staff.Gender, staff.DOB, staff.Phone, staff.Street_Address, staff.Suburb, staff.City, staff.Country, staff.Employee_Type, staff.Practice_ID, staff.Email);
        }

        [HttpGet]
        [Route("api/Employees/GetAllAccessLevel")]
        public List<AccessLevel> GetAllAccessLevel()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllAccessLevel();
        }

        [HttpGet]
        [Route("api/Employees/GetAccessLevel/{ID}")]
        public AccessLevel GetAccessLevelByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAccessLevelById(ID);
        }

        [HttpGet]
        [Route("api/Employees/GetAllPractices")]
        public List<Practice> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPractices();
        }

        [HttpPost]
        [Route("api/Employees/InsertEmployee")]
        public bool InsertEmployee(Staff staff)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertStaff(staff.FirstName, staff.LastName, staff.ID_Number, staff.Gender, formatDate(staff.DOB.ToString()), staff.Phone, staff.Street_Address, staff.Suburb, staff.City, staff.Country, staff.ACCESSLEVEL_ID, staff.Employee_Type, staff.Practice_ID, dtLayer.GetNewUserID(), staff.Email);

            //return dtLayer.InsertStaff("Josephine", "Chivinge", "012456874", "M", "04-20-1994", "0837135032", "A", "B", "C", "D", 1, "Admin", 6, dtLayer.GetNewUserID(), "Jose@gmail.com");

        }

        [HttpPost]
        [Route("api/Employees/DeleteEmployee/{ID}")]
        public bool DeleteEmployee(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteStaff(ID);
        }

        public string formatDate(string dt)
        {
            string[] date = dt.Split('T');
            string[] Date = date[0].Split('-');
            string ftDate = (Date[1] + "-" + Date[2] + "-" + Date[0]);
            return ftDate;
        }
    }
}
