using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Models.BindingModels;
using PunkHouseReal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services
{
    public class HouseMateService : IHouseMateService
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        public HouseMateService(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        public HouseMate GetHouseMate(string userId)
        {
            return _database.HouseMates.FirstOrDefault(housemate => housemate.Id == userId);
        }

        public List<HouseMateExpense> GetHouseMateExpenses(string houseMateId, HouseMateExpenseFilterBindingModel model)
        {
            List<HouseMateExpense> result = new List<HouseMateExpense>();
            //determine what expenses to get
            if (!String.IsNullOrEmpty(model.CreatorId))
            {
                if (model.IsPaid != null && model.IsPaid == false)
                    result = GetHouseMateExpensesOwedMe(houseMateId, model.CreatorId);
                else
                    result = GetHouseMateExpensesOwedMeHistory(houseMateId, model.CreatorId);
            }
            else if (model.IsPaid != null && model.IsPaid == false)
                result = GetHouseMateExpensesIOwe(houseMateId);
            else
                result = GetHouseMateExpensesIOweHistory(houseMateId);

            return result;


        }

        public HouseMateExpense GetHouseMateExpense(string houseMateId, int expenseId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.HouseMateId == houseMateId)
                                              .Where(hme => hme.ExpenseId == expenseId)
                                              .FirstOrDefault();
        }

        public async Task UpdateHouseMate(HouseMate houseMate)
        {
            await _userManager.UpdateAsync(houseMate);
        }

        public void UpdateHouseMateExpense(HouseMateExpense houseMateExpense)
        {
             _database.HouseMateExpenses.Update(houseMateExpense);
            _database.SaveChanges();
        }

        #region Private Methods

        //Expenses I OWE
        private List<HouseMateExpense> GetHouseMateExpensesIOwe(string houseMateId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.HouseMateId == houseMateId)
                                              .Where(hme => !hme.IsPaid)
                                              .Include(e => e.Expense)
                                              .ToList();
        }

        private List<HouseMateExpense> GetHouseMateExpensesIOweHistory(string houseMateId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.HouseMateId == houseMateId)
                                              .Where(hme => hme.IsPaid)
                                              .Include(e => e.Expense)
                                              .ToList();
        }

        //Expenses OWED TO ME
        private List<HouseMateExpense> GetHouseMateExpensesOwedMe(string houseMateId, string creatorId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.CreatorId == creatorId)
                                              .Where(hme => hme.HouseMateId != houseMateId)
                                              .Where(hme => !hme.IsPaid)
                                              .Include(hme => hme.Expense)
                                              .Include(hme => hme.HouseMate)
                                              .ToList();
        }

        //Expenses OWED TO ME history (already paid)
        private List<HouseMateExpense> GetHouseMateExpensesOwedMeHistory(string houseMateId, string creatorId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.CreatorId == creatorId)
                                              .Where(hme => hme.HouseMateId != houseMateId)
                                              .Where(hme => hme.IsPaid)
                                              .Include(hme => hme.Expense)
                                              .Include(hme => hme.HouseMate)
                                              .ToList();
        }

        #endregion
    }
}
