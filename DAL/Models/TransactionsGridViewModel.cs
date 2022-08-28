using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class TransactionsGridViewModel
    {
        public Guid Transaction_Id { get; set; }
        public int Account_No { get; set; }
        public int Transaction_No { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Description { get; set; }
        public string Transaction_Type { get; set; }
    }
}
