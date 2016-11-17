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
    public class MessagesController : ApiController
    {
        [HttpGet]
        [Route("api/Messages/GetAllMessages/{Receiver}")]
        public List<Messages> GetAllMessages(int Receiver)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAllMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Messages/NumOfUnReadMessages/{Receiver}")]
        public Messages NumOfUnReadMessages(int Receiver)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_NumOfUnReadMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Messages/GetMessage/{ID}")]
        public Messages GetMessageByID(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetMessageById(ID);
        }

        [HttpGet]
        [Route("api/Messages/GetAllSentMessages/{Sender}")]
        public List<Messages> GetAllSentMessages(int Sender)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAllSentMessages(Sender);
        }

        [HttpGet]
        [Route("api/Messages/GetSentMessageById/{ID}")]
        public Messages GetSentMessageById(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetSentMessageById(ID);
        }

        [HttpGet]
        [Route("api/Messages/GetAllRecepients")]
        public List<Staff> GetAllRecepients()
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_GetAllRecepients();
        }

        [HttpPost]
        [Route("api/Messages/InsertMessage")]
        public bool InsertMessage(Messages messages)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_NewMessages(messages.Receiver, messages.Sender, messages.Subject, messages.Description, messages.Date);
        }

        [HttpPost]
        [Route("api/Messages/DeleteMessage/{ID}")]
        public bool DeleteMessage(int ID)
        {
            PatientDataLayer dtLayer = new PatientDataLayer();
            return dtLayer.Portal_DeleteMessages(ID);
        }
    }
}
