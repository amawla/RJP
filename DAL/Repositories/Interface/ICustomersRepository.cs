using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface ICustomersRepository : IRepository<CustomersModel>
    {
        IEnumerable<CustomersGridViewModel> GetAllCustomers();
    }
}
