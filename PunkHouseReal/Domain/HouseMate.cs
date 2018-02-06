using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models
{
    public class HouseMate : ApplicationUser
    {
        [ForeignKey("HouseId")]
        public int HouseId { get; set; }
        public DateTimeOffset DateModified { get; set; }

        public ICollection<HouseMateExpense> HouseMateExpenses { get; set; }

        public HouseMate()
        {
            DateModified = DateTimeOffset.Now;
        }
    }
}
