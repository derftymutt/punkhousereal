using Microsoft.AspNetCore.Identity;
using PunkHouseReal.Data;
using PunkHouseReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExpenseService(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        public Expense AddExpense(Expense expense)
        {
            _database.Expenses.Add(expense);
            _database.SaveChanges();
            return expense;
        }
    }
}
