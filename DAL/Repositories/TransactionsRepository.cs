using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TransactionsRepository : Repository<TransactionsModel> , ITransactionsRepository
    {
        public TransactionsRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public void CreateTransaction(TransactionsModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }

        public IEnumerable<TransactionsGridViewModel> GetAllTransactions()
        {
            List<TransactionsGridViewModel> allTransactions = new List<TransactionsGridViewModel>();
            allTransactions = (from transactions in _appContext.Transactions
                           join accounts in _appContext.Accounts on transactions.Account_Id equals accounts.Account_Id
                           select new TransactionsGridViewModel
                           {
                              Transaction_Id = transactions.Transaction_Id,
                              Account_No = accounts.Account_No,
                              Transaction_No = transactions.Transaction_No,
                              Transaction_Date = transactions.Transaction_Date,
                              Transaction_Type = transactions.Transaction_Type,
                              Description = transactions.Description
                            
                           }).ToList();
            return allTransactions;
        }

        public TransactionsModel GetTransactionById(Guid id)
        {
            return Get(id);
        }

        public IEnumerable<TransactionsGridViewModel> GetTransactionsByAccountId(Guid accountId)
        {
            List<TransactionsGridViewModel> allTransactions = new List<TransactionsGridViewModel>();
            allTransactions = (from transactions in _appContext.Transactions
                               join accounts in _appContext.Accounts on transactions.Account_Id equals accounts.Account_Id
                               where transactions.Account_Id == accountId
                               select new TransactionsGridViewModel
                               {
                                   Transaction_Id = transactions.Transaction_Id,
                                   Account_No = accounts.Account_No,
                                   Transaction_No = transactions.Transaction_No,
                                   Transaction_Date = transactions.Transaction_Date,
                                   Transaction_Type = transactions.Transaction_Type,
                                   Description = transactions.Description

                               }).ToList();
            return allTransactions;
        }
    }
}
