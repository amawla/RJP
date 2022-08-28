using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using RJP.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RJP.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public AccountsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("AccountsList")]
        public ActionResult Index()
        {
            List<AccountsGridViewModel> model = new List<AccountsGridViewModel>();
            var allAccounts = _unitOfWork.Accounts.GetAllAccounts();
            return View(allAccounts);
        }

        [Route("CreateAccount")]
        [HttpPost]
        public ActionResult CreateAccount(OpenAccountViewModel model)
        {
            string saveMessage = "";
            int accountsCounter = _unitOfWork.Accounts.GetAllAccounts().Count();
            int transactionsCounter = _unitOfWork.Transactions.GetAllTransactions().Count();
            try
            {
                var createAccountModel = new AccountsModel
                {
                    Account_Id = Guid.NewGuid(),
                    Balance = model.Balance,
                    Account_No = accountsCounter + 1,
                    Customer_Id = model.Customer_Id,
                    Creation_Date = DateTime.Now,
                    Modification_Date = DateTime.Now
                };
                _unitOfWork.Accounts.CreateAccount(createAccountModel);

                if(model.Balance > 0)
                {
                    _unitOfWork.Transactions.CreateTransaction(new TransactionsModel
                    {
                        Account_Id = createAccountModel.Account_Id,
                        Transaction_Id = Guid.NewGuid(),
                        Description = "A new Account have been opened for the customer whose Account No is " + createAccountModel.Account_No + " on " +
                        DateTime.Now + " with Balance : " + createAccountModel.Balance + " $",
                        Transaction_No = transactionsCounter + 1,
                        Transaction_Type = "New Account",
                        Transaction_Date = DateTime.Now,
                        Creation_Date = DateTime.Now,
                        Modification_Date = DateTime.Now,

                    });
                }
                saveMessage += "Account created Successfully";

            }
            catch(Exception ex)
            {
                saveMessage = ex.Message.ToString();
                return Json(new { Status = "success", Message = saveMessage });
            }
          
            return Json(new { Status = "success", Message = saveMessage });
        }

        [Route("CheckAccountIfExists")]
        [HttpPost]
        public ActionResult CheckAccountIfExists(string customerId="")
        {
            var accountExists = new AccountsGridViewModel();
            if (!string.IsNullOrEmpty(customerId))
            {
                accountExists = _unitOfWork.Accounts.GetAccountByCustomerId(new Guid(customerId));
                return Json(new { Status = "success", AccountExists = accountExists != null, Account_Id = accountExists != null ? accountExists.Account_Id : Guid.Empty });
            }
            else
            {
                return Json(new { Status = "error"});
            }
            
        }
    }
}
