using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using DAL.Repositories.Interface;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IAccountsRepository _accounts;
        ITransactionsRepository _transactions;
        ICustomersRepository _customers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IAccountsRepository Accounts
        {
            get
            {
                if (_accounts == null)
                {
                    _accounts = new AccountsRepository(_context);
                }
                return _accounts;
            }

        }

        public ITransactionsRepository Transactions
        {
            get
            {
                if (_transactions == null)
                {
                    _transactions = new TransactionsRepository(_context);
                }
                return _transactions;
            }
        }
        public ICustomersRepository Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomersRepository(_context);
                }
                return _customers;
            }
        }



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
