using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CustomersGridViewModel
    {
        public Guid Customer_Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
