using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IAccountsRepository
    {
        IEnumerable<AccountsGridViewModel> GetAllAccounts();

        void CreateAccount(AccountsModel model);

        void UpdateAccount(AccountsModel model);

        AccountsModel GetAccountById(Guid id);

        AccountsGridViewModel GetAccountByCustomerId(Guid customerId);
    }
}
