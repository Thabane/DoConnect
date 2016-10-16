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
    public class UserProfileController : ApiController
    {
        [HttpGet]
        [Route("api/UserProfile/GetLoggedinUserProfile/{User_ID}")]
        public UserProfile GetLoggedinUserProfile (int User_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetLoggedinUserProfile(User_ID);
        }

        [HttpGet]
        [Route("api/UserProfile/GetPassword/{User_ID}")]
        public UserProfile GetPassword(int User_ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPassword(User_ID);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdatePassword")]
        public bool UpdatePassword(UserProfile userProfile)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdatePassword(userProfile.User_ID, userProfile.Password);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdateProfileStaff")]
        public bool UpdateProfileStaff(Staff staff)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateProfileStaff(staff.User_ID, staff.FirstName, staff.LastName, staff.ID_Number, staff.Gender, staff.DOB, staff.Phone, staff.Street_Address, staff.Suburb, staff.City, staff.Country);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdateProfileDoctor")]
        public bool UpdateProfileDoctor(Staff staff)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateProfileDoctor(staff.User_ID, staff.FirstName, staff.LastName, staff.Gender, staff.Street_Address);
        }
    }
}
