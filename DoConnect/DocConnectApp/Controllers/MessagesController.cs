﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;

namespace DocConnectApp.Controllers
{
    public class MessagesController : ApiController
    {
        [HttpGet]
        [Route("api/Messages/GetAllMessages/{Receiver}")]
        public List<Messages> GetAllMessages(int Receiver)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Messages/NumOfUnReadMessages/{Receiver}")]
        public Messages NumOfUnReadMessages(int Receiver)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NumOfUnReadMessages(Receiver);
        }

        [HttpGet]
        [Route("api/Messages/GetMessage/{ID}")]
        public Messages GetMessageByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetMessageById(ID);
        }

        [HttpGet]
        [Route("api/Messages/GetAllSentMessages/{Sender}")]
        public List<Messages> GetAllSentMessages(int Sender)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllSentMessages(Sender);
        }

        [HttpGet]
        [Route("api/Messages/GetSentMessageById/{ID}")]
        public Messages GetSentMessageById(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetSentMessageById(ID);
        }

        [HttpGet]
        [Route("api/Messages/GetAllRecepients")]
        public List<Staff> GetAllRecepients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllRecepients();
        }

        [HttpPost]
        [Route("api/Messages/InsertMessage")]
        public bool InsertMessage(Messages messages)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewMessages(messages.Receiver, messages.Sender, messages.Subject, messages.Description, messages.Date);
        }

        [HttpPost]
        [Route("api/Messages/DeleteMessage/{ID}")]
        public bool DeleteMessage(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteMessages(ID);
        }
    }
}
