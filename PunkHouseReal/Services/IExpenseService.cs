using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using System.Collections.Generic;

namespace PunkHouseReal.Services
{
    public interface IExpenseService
    {
        void AddExpense(Expense expense);
        List<Expense> GetByHouseId(int houseId);
    }
}