﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Models.BindingModels;
using PunkHouseReal.Services;

namespace PunkHouseReal.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    [Authorize]
    public class ExpenseApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IExpenseService _expenseService;

        public ExpenseApiController(UserManager<ApplicationUser> userManager, IExpenseService expenseService)
        {
            _userManager = userManager;
            _expenseService = expenseService;
        }

        //api/expenses
        [HttpPost]
        public IActionResult CreateExpense([FromBody]ExpenseBindingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Expense expense = new Expense();
                    ParseExpenseFields(expense, model);
                    _expenseService.AddExpense(expense);
                    return Ok(expense);

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return BadRequest("error creating the expense");
        }
   
        private void ParseExpenseFields(Expense expense, ExpenseBindingModel model)
        {
            expense.CreatorId = model.CreatorId;
            expense.Description = model.Description;
            expense.ExpenseType = model.ExpenseType;
            expense.Name = model.Name;
            expense.HouseId = model.HouseId;
            expense.Total = model.Total;
            expense.DueDate = model.DueDate;
            expense.IsDividedUnevenly = model.IsDividedUnevenly;
            expense.UnevenTotals = model.UnevenTotals;
            expense.IsPaid = model.IsPaid;
        }

    }

}