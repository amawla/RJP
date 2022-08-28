using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class AccountsGridViewModel
    {
        public Guid Account_Id { get; set; }
        public int Account_No { get; set; }
        public string Customer { get; set; }
        public decimal Balance { get; set; }
    }
}
