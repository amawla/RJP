using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class AccountsModel
    {
        [Key]
        public Guid Account_Id { get; set; }
        public int Account_No { get; set; }
        public Guid Customer_Id { get; set; }
        public decimal Balance { get; set; }

        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }
    }
}
