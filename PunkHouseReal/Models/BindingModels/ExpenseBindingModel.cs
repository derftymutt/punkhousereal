using PunkHouseReal.Models.EnumsAndConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models.BindingModels
{
    public class ExpenseBindingModel
    {
        [Required]
        public int HouseId { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public ExpenseType ExpenseType { get; set; }
        public bool IsDividedUnevenly { get; set; }
        public Dictionary<string, decimal> UnevenTotals { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Total { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsMarkedPaid { get; set; }
        public bool IsPaid { get; set; }

        public ExpenseBindingModel()
        {
            IsPaid = false;
        }

    }
}
