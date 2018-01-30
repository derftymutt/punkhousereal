using PunkHouseReal.Models.EnumsAndConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public ExpenseType ExpenseType { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public decimal Total { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }

        public ICollection<HouseMateExpense> HouseMateExpenses { get; set; }

        public Expense()
        {
            DateCreated = DateTimeOffset.Now;
            DateModified = DateTimeOffset.Now;
            IsPaid = false;

        }
    }
}
