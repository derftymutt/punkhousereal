using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Models.BindingModels
{
    public class UpdateHouseMateBindingModel
    {
        [Required]
        public int HouseId { get; set; }
    }
}
