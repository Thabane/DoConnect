using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;
using System.Web.Http.Description;

namespace DocConnectApp.Controllers
{
    public class AccountingController : ApiController
    {
        #region Invoice
        [HttpGet]
        [Route("api/Accounting/GetAllInvoices")]
        public List<Invoice> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllInvoices();
        }

        [HttpGet]
        [Route("api/Accounting/ViewUnInvoicedConsultations")]
        public List<Consultation> ViewUnInvoicedConsultations()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.ViewUnInvoicedConsultations();
        }

        [HttpGet]
        [Route("api/Accounting/GetInvoice/{ID}")]
        public Invoice GetInvoiceByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetInvoiceById(ID);
        }
        [HttpGet]
        [Route("api/Accounting/GetAllPatients")]
        public List<GetAllPatients> GetAllPatients()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllPatientsForInvoice();
        }

        [HttpGet]
        [Route("api/Accounting/GetAllDiagnosisByPatientID/{ID}")]
        public List<Invoice> GetAllDiagnosisByPatientID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllDiagnosisByPatientID(ID);
        }

        //[HttpPost]
        //[Route("api/Accounting/UpdateInvoice")]
        //public bool UpdateInvoice(Invoice invoice)
        //{
        //    DataLayer dtLayer = new DataLayer();
        //    return dtLayer.UpdateInvoice();
        //}

        [HttpPost]
        [Route("api/Accounting/InsertInvoice")]
        public bool InsertInvoice(Invoice invoice)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewInvoice(invoice.Date, invoice.InvoiceSummary, invoice.Total, invoice.AmountPaid, invoice.Medical_Aid_ID, invoice.Patient_ID, invoice.Doctor_ID);
        }

        [HttpPost]
        [Route("api/Accounting/UpdateUnInvoicedConsultations")]
        public bool UpdateUnInvoicedConsultations(Consultation consultation)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateUnInvoicedConsultations(consultation.Consultation_ID);
        }
        
        [HttpPost]
        [Route("api/Accounting/DeleteInvoice/{ID}")]
        public bool DeleteInvoice(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.DeleteInvoice(ID);
        }
        #endregion
    }
}
