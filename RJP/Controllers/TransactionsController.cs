using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RJP.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        // GET: api/<controller>
        private IUnitOfWork _unitOfWork;
        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("TransactionsList")]
        public ActionResult Index(string accountId="")
        {
            List<TransactionsGridViewModel> model = new List<TransactionsGridViewModel>();
            if (!string.IsNullOrEmpty(accountId))
            {
                model = _unitOfWork.Transactions.GetTransactionsByAccountId(new Guid(accountId)).ToList();
            }
            else
            {
                model = _unitOfWork.Transactions.GetAllTransactions().ToList();
            }
           
            return View(model);
        }

        [Route("TransactionDetails")]
        public ActionResult Details(string transactionId="")
        {
            var model = new TransactionsGridViewModel();
            if (!string.IsNullOrEmpty(transactionId))
            {
                var transaction = _unitOfWork.Transactions.GetTransactionById(new Guid(transactionId));
                if(transaction != null)
                {
                    model = new TransactionsGridViewModel
                    {
                        Transaction_Id = transaction.Transaction_Id,
                        Transaction_No = transaction.Transaction_No,
                        Transaction_Type = transaction.Transaction_Type,
                        Transaction_Date = transaction.Transaction_Date,
                        Description = transaction.Description
                    };
                }
                return View(model);
            }
            else
            {
                return View(new TransactionsGridViewModel());
            } 
        }


        [Route("CreateTransactions")]
        public ActionResult CreateTransactions(string serializedTransaction="")
        {
            string saveMessage = "";
            TransactionsModel model = new TransactionsModel();
            if (!string.IsNullOrEmpty(serializedTransaction))
            {
                model = JsonConvert.DeserializeObject<TransactionsModel>(serializedTransaction);
                int transactionsCounter = _unitOfWork.Transactions.GetAllTransactions().Count();
                try
                {
                    model.Transaction_Id = Guid.NewGuid();
                    model.Transaction_No = transactionsCounter + 1;
                    model.Transaction_Date = DateTime.Now;
                    model.Creation_Date = model.Modification_Date = DateTime.Now;
                    _unitOfWork.Transactions.CreateTransaction(model);
                    saveMessage += "Transaction sent Successfully";
                }
                catch (Exception ex)
                {
                    saveMessage = ex.Message.ToString();
                    return Json(new { Status = "success", Message = saveMessage });
                }

                return Json(new { Status = "success", Message = saveMessage });
            }
            else
            {
                return Json(new { Status = "error", Message = "" });
            }
          
        }

    }
}
