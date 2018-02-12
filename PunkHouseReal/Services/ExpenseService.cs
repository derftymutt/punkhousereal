using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services
{
    public class ExpenseService : IExpenseService
    {
        #region Properties

        private readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        #endregion

        #region Constructors

        public ExpenseService(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        #endregion

        #region Public Methods

        public void AddExpense(Expense expense)
        {
            //Check here against PaynemtType enum to determine how to proceed? or in controller...?
            //Or in BuildHouseMateExpenses method?

            //for now, assume Divide evenly...
            var houseMateExpenses = BuildHouseMateExpenses(expense);

            _database.HouseMateExpenses.AddRange(houseMateExpenses);
            _database.SaveChanges();
        }

        public List<Expense> GetByHouseId(int houseId)
        {
            return _database.Expenses.Include(hme => hme.HouseMateExpenses)
                                     .Where(hme => hme.HouseMate.HouseId == houseId)                                            
                                     .ToList();
        }

        #endregion

        #region Private Helper Methods

        private List<HouseMateExpense> BuildHouseMateExpenses(Expense expense)
        {
            var result = new List<HouseMateExpense>();

            //Build PaymentType.DivideEvenly 
            var houseMateIds = _database.HouseMates.Where(hm => hm.HouseId == expense.HouseId)
                                                   .Select(hm => hm.Id)
                                                   .ToList();

            var totalEachEven = CalculateHouseMateExpenseDivideEvenlyTotal(expense.Total, expense.HouseId);

            foreach (var id in houseMateIds)
            {
                var houseMateExpense = new HouseMateExpense()
                {
                    Expense = expense,
                    HouseMateId = id,
                    Total = totalEachEven
                };

                result.Add(houseMateExpense);
            }

            return result;

        }

        private decimal CalculateHouseMateExpenseDivideEvenlyTotal(decimal expenseTotal, int houseId)
        {
            var houseMateCount = _database.HouseMates.Where(hm => hm.HouseId == houseId).Count();
            return expenseTotal / houseMateCount;


        }

        #endregion
    }
}
