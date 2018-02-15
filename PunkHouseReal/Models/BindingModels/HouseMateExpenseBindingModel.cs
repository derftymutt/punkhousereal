using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models.BindingModels
{
    public class HouseMateExpenseBindingModel
    {
        [Required]
        public string HouseMateId { get; set; }
        [Required]
        public int ExpenseId { get; set; }
        [Required]
        public bool IsMarkedPaid { get; set; }
        public bool IsPaid { get; set; }

        public HouseMateExpenseBindingModel()
        {
            IsPaid = false;
        }
    }
}
