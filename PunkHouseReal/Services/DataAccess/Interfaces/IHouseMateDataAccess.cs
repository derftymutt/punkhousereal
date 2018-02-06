using System.Threading.Tasks;
using PunkHouseReal.Models;

namespace PunkHouseReal.Services.DataAccess.Interfaces
{
    public interface IHouseMateDataAccess
    {
        HouseMate GetHouseMate(string userId);
        Task UpdateHouseId(HouseMate houseMate, int houseId);
    }
}