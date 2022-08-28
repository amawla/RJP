using DAL.Models;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class CustomersRepository : Repository<CustomersModel>, ICustomersRepository
    {
        public CustomersRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public IEnumerable<CustomersGridViewModel> GetAllCustomers()
        {
            List<CustomersGridViewModel> allCustomers = new List<CustomersGridViewModel>();
            allCustomers = (from customers in _appContext.Customers
                            select new CustomersGridViewModel
                            {
                                Customer_Id = customers.Customer_Id,
                                FullName = customers.FName + " " + customers.LName,
                                Address = customers.Address,
                                PhoneNumber = customers.Phone_Number,
                                Email = customers.Email
                            }).ToList();
            return allCustomers;
        }
    }
}
