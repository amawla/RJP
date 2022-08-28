using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IUnitOfWork
    {
        IAccountsRepository Accounts { get; }

        ITransactionsRepository Transactions { get; }

        ICustomersRepository Customers { get; }

        int SaveChanges();
    }
}
