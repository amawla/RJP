using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface ITransactionsRepository : IRepository<TransactionsModel>
    {
        IEnumerable<TransactionsGridViewModel> GetAllTransactions();

        void CreateTransaction(TransactionsModel model);

        TransactionsModel GetTransactionById(Guid id);

        IEnumerable<TransactionsGridViewModel> GetTransactionsByAccountId(Guid accountId);
    }
}
