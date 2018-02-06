using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models.BindingModels
{
    public class HouseBindingModel
    {
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public string CreatorId { get; set; }
        [MaxLength(50)]
        public string Address1 { get; set; }
        [MaxLength(50)]
        public string Address2 { get; set; }
        [MaxLength(5)]
        public string Zip { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
    }
}
