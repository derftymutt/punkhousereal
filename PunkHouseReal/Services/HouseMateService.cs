using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
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

        //Expenses I OWE
        public List<HouseMateExpense> GetHouseMateExpensesIOwe(string houseMateId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.HouseMateId == houseMateId)
                                            //  .Where(hme => !hme.IsPaid)
                                              .Include(e => e.Expense) 
                                              .ToList();
        }

        //Expenses OWED TO ME
        public List<HouseMateExpense> GetHouseMateExpensesOwedMe(string houseMateId, string creatorId)
        {
            return _database.HouseMateExpenses.Where(hme => hme.CreatorId == creatorId)
                                              .Where(hme => hme.HouseMateId != houseMateId)
                                             // .Where(hme => !hme.IsPaid)
                                              .Include(hme => hme.Expense)
                                              .Include(hme => hme.HouseMate)
                                              .ToList();
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
    }
}
