using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Models.EnumsAndConstants;
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
            var houseMateExpenses = BuildHouseMateExpenses(expense);
            _database.HouseMateExpenses.AddRange(houseMateExpenses);
            _database.SaveChanges();
        }

        #endregion

        #region Private Helper Methods

        private List<HouseMateExpense> BuildHouseMateExpenses(Expense expense)
        {
            var result = new List<HouseMateExpense>();
            List<string> houseMateIds = new List<string>();

            if (expense.IsDividedUnevenly)
            {
                foreach (var item in expense.UnevenTotals)
                {
                    var houseMateExpense = new HouseMateExpense()
                    {
                        Expense = expense,
                        HouseMateId = item.Key,
                        CreatorId = expense.CreatorId,
                        Total = item.Value
                    };

                    result.Add(houseMateExpense);
                }               
            }
            else
            {
                houseMateIds = _database.HouseMates.Where(hm => hm.HouseId == expense.HouseId)
                                                       .Select(hm => hm.Id)
                                                       .ToList();

                var total = CalculateEvenTotal(expense.Total, expense.HouseId);

                foreach (var id in houseMateIds)
                {
                    var houseMateExpense = new HouseMateExpense()
                    {
                        Expense = expense,
                        HouseMateId = id,
                        CreatorId = expense.CreatorId,
                        Total = total
                    };

                    result.Add(houseMateExpense);
                }
            }

            return result;
        }

        private decimal CalculateEvenTotal(decimal expenseTotal, int houseId)
        {
            var houseMateCount = _database.HouseMates.Where(hm => hm.HouseId == houseId).Count();
            return expenseTotal / houseMateCount;


        }

        #endregion
    }
}
