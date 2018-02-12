using PunkHouseReal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Domain
{
    public class HouseMateExpense
    {
        [Key, Column(Order = 0)]
        public string HouseMateId { get; set; }
        public HouseMate HouseMate { get; set; }

        [Key, Column(Order = 1)]
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }

        public decimal Total { get; set; }
        public bool IsPaid { get; set; }

        public HouseMateExpense()
        {
            IsPaid = false;
        }
    }
}
