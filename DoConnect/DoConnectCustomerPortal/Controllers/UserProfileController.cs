using DataClient;
using ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoConnectCustomerPortal.Controllers
{
    public class UserProfileController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllUserProfile/{ID}")]
        public Practice GetPracticeByID(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetPracticeById(ID);
        }

        [HttpGet]
        [Route("api/UserProfile/GetLoggedinUserProfile/{User_ID}")]
        public UserProfile GetLoggedinUserProfile(int User_ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetLoggedinUserProfile(User_ID);
        }

        [HttpGet]
        [Route("api/UserProfile/GetPassword/{User_ID}")]
        public UserProfile GetPassword(int User_ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetPassword(User_ID);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdatePassword")]
        public bool UpdatePassword(UserProfile userProfile)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_UpdatePassword(userProfile.User_ID, userProfile.Password);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdateProfileStaff")]
        public bool UpdateProfileStaff(Staff staff)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_UpdateProfileStaff(staff.User_ID, staff.FirstName, staff.LastName, staff.ID_Number, staff.Gender, staff.DOB, staff.Phone, staff.Street_Address, staff.Suburb, staff.City, staff.Country);
        }

        [HttpPost]
        [Route("api/UserProfile/UpdateProfileDoctor")]
        public bool UpdateProfileDoctor(Staff staff)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_UpdateProfileDoctor(staff.User_ID, staff.FirstName, staff.LastName, staff.Gender, staff.Street_Address);
        }
    }
}
