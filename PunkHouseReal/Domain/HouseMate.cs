using PunkHouseReal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Domain
{
    public class HouseMate : ApplicationUser
    {
        public int? HouseId { get; set; }
        public House House { get; set; }

        public DateTimeOffset DateModified { get; set; }

        public ICollection<HouseMateExpense> HouseMateExpenses { get; set; }

        public HouseMate()
        {
            DateModified = DateTimeOffset.Now;
        }
    }
}
