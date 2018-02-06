using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models
{
    public class House
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<HouseMate> HouseMates { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DateCreated { get; set; }


        public House()
        {
            DateCreated = DateTimeOffset.Now;
            DateModified = DateTimeOffset.Now;
        }
    }
}
