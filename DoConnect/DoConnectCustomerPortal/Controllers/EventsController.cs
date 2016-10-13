using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;
namespace DoConnectCustomerPortal.Controllers
{
    public class EventsController : ApiController
    {
        /*[HttpGet]
        [Route("api/Events/GetAllEvents")]
        public List<Events> GetAllEvents()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllEvents();
        }

        [HttpGet]
        [Route("api/Events/GetEvent/{ID}")]
        public Events GetEventByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetEvent(ID);
        }

        [HttpPost]
        [Route("api/Events/UpdateEvent")]
        public bool UpdateEvent(Events Event)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateEvent(Event.ID, Event.Title, Event.Details, Event.StartDateTime, Event.EndDateTime, Event.AppointmentStatus);
        }

        [HttpPost]
        [Route("api/Events/InsertEvent")]
        public bool InsertEvent(Events Event)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertEvent(, Event.Title, Event.Details, Event.StartDateTime, Event.EndDateTime, Event.AppointmentStatus);

        }

        [HttpPost]
        [Route("api/Events/DeleteEvent/{ID}")]
        public bool DeleteEvent(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteEvent(ID);
        }*/
    }
}
