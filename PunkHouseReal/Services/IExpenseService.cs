using PunkHouseReal.Models;

namespace PunkHouseReal.Services
{
    public interface IExpenseService
    {
        Expense AddExpense(Expense expense);
    }
}