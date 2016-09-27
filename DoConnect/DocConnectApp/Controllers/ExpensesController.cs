using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectModel;
using DataClient;
using System.Web.Http.Description;

namespace DoConnectAdmin.Controllers
{
    public class ExpensesController : ApiController
    {
        [HttpGet]
        [Route("api/Expenses/GetAllExpenses")]
        public List<Expenses> GetAllPractices()
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetAllExpenses();
        }

        [HttpGet]
        [Route("api/Expenses/GetExpense/{ID}")]
        public Expenses GetExpenseByID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetExpenseById(ID);
        }

        [HttpPost]
        [Route("api/Expenses/UpdateExpense")]
        public bool UpdateExpense(Expenses expense)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.UpdateExpense(expense.ID, expense.Description, expense.Amount);
        }

        [HttpGet]
        [Route("api/Expenses/GetPracticeIDByUser_ID/{ID}")]
        public Expenses GetPracticeIDByUser_ID(int ID)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.GetPracticeIDByUser_ID(ID);
        }

        [HttpPost]
        [Route("api/Expenses/InsertExpense")]
        public bool InsertExpense(Expenses expense)
        {
            DataLayer dtLayer = new DataLayer();
            return dtLayer.NewExpense(expense.Description, expense.Date, expense.Amount, expense.Practice_ID, expense.User_ID);
        }

        //[HttpPost]
        //[Route("api/Expenses/DeleteExpense/{ID}")]
        //public bool DeleteExpense(int ID)
        //{
        //    DataLayer dtLayer = new DataLayer();
        //    return dtLayer.DeleteExpense(ID);
        //}

    }
}
