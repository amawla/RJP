using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public class AccountsRepository : Repository<AccountsModel>, IAccountsRepository
    {
        public AccountsRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public void CreateAccount(AccountsModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }
        public void UpdateAccount(AccountsModel model)
        {
            Update(model);
            _appContext.SaveChanges();
        }
        public AccountsModel GetAccountById(Guid id)
        {
            return Get(id);
        }

        public IEnumerable<AccountsGridViewModel> GetAllAccounts()
        {
            List<AccountsGridViewModel> allAccounts = new List<AccountsGridViewModel>();
            allAccounts = (from accounts in _appContext.Accounts
                           join customers in _appContext.Customers on accounts.Customer_Id equals customers.Customer_Id
                           select new AccountsGridViewModel
                           {
                               Account_Id = accounts.Account_Id,
                               Account_No = accounts.Account_No,
                               Customer = customers.FName + " " + customers.LName,
                               Balance = accounts.Balance
                           }).ToList();
            return allAccounts;
        }

        public AccountsGridViewModel GetAccountByCustomerId(Guid customerId)
        {
            AccountsGridViewModel accountByCustomer = new AccountsGridViewModel();
            accountByCustomer = GetAll().Where(x => x.Customer_Id == customerId).Select(a => new AccountsGridViewModel {
                Account_Id = a.Account_Id,
                Account_No = a.Account_No,
                Balance = a.Balance
            }).FirstOrDefault();
            return accountByCustomer;
        }
    }
}
