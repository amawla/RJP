using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class TransactionsModel
    {
        [Key]
        public Guid Transaction_Id { get; set; }
        public Guid Account_Id { get; set; }
        public int Transaction_No { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Description { get; set; }
        public string Transaction_Type { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

    }
}
