﻿using System;
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
        /*[HttpGet]
        [Route("api/Messages/GetAllMessages")]
        public List<Messages> GetAllMessages()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMessages();
        }

        [HttpGet]
        [Route("api/Messages/GetMessage/{ID}")]
        public Messages GetMessageByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMessage(ID);
        }

        [HttpPost]
        [Route("api/Messages/InsertMessage")]
        public bool InsertMessage(Messages messages)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.InsertMessage(messages.Sender, messages.Receiver, messages.Subject, messages.Description, messages.Date);
        }

        [HttpPost]
        [Route("api/Messages/DeleteMessage/{ID}")]
        public bool DeleteMessage(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteMessage(ID);
        }*/
    }
}
