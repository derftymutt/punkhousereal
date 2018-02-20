using System.Collections.Generic;
using System.Threading.Tasks;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;

namespace PunkHouseReal.Services
{
    public interface IHouseMateService
    {
        HouseMate GetHouseMate(string userId);
        Task UpdateHouseMate(HouseMate houseMate);
        HouseMateExpense GetHouseMateExpense(string houseMateId, int expenseId);
        List<HouseMateExpense> GetHouseMateExpenses(string houseMateId);
        void UpdateHouseMateExpense(HouseMateExpense houseMateExpense);
    }
}