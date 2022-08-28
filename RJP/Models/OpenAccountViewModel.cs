using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RJP.Models
{
    public class OpenAccountViewModel : AccountsModel
    {
        public List<CustomersGridViewModel> Customers { get; set; }
        public List<string> TransactionTypes { get; set; } = new List<string>
        {
            "Withdarwal","Deposit"
        };
    }
}
