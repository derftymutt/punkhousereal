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
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [MaxLength(5)]
        public int Zip { get; set; }
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public DateTimeOffset DateCreated { get; set; }


        public House()
        {
            DateCreated = DateTimeOffset.Now;
            DateModified = DateTimeOffset.Now;
        }
    }
}
