using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models
{
    public class HouseMate
    {
        public int Id { get; set; }
        [ForeignKey("HouseId")]
        public int HouseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }

        public ICollection<HouseMateExpense> HouseMateExpenses { get; set; }

        public HouseMate()
        {
            DateCreated = DateTimeOffset.Now;
            DateModified = DateTimeOffset.Now;
        }
    }
}
