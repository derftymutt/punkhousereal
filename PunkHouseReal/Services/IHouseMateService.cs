using System.Collections.Generic;
using System.Threading.Tasks;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Models.BindingModels;

namespace PunkHouseReal.Services
{
    public interface IHouseMateService
    {
        HouseMate GetHouseMate(string userId);
        Task UpdateHouseMate(HouseMate houseMate);
        HouseMateExpense GetHouseMateExpense(string houseMateId, int expenseId);
        List<HouseMateExpense> GetHouseMateExpenses(string houseMateId, HouseMateExpenseFilterBindingModel model);
        void UpdateHouseMateExpense(HouseMateExpense houseMateExpense);
    }
}