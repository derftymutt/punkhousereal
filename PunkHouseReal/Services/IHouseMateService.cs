using System.Collections.Generic;
using System.Threading.Tasks;
using PunkHouseReal.Models;

namespace PunkHouseReal.Services
{
    public interface IHouseMateService
    {
        HouseMate GetHouseMate(string userId);
        Task UpdateHouseId(HouseMate houseMate, int houseId);
    }
}