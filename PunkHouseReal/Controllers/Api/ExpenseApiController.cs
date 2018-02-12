using System;
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
    [Route("api/Expense")]
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

        [HttpGet, Route("{houseId:int}")]
        public IActionResult Get(int houseId)
        {
            if (houseId != 0)
            {
                try
                {
                   List<Expense> result = _expenseService.GetByHouseId(houseId);
                   return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return BadRequest("Houston we have an error getting the expenses for this house");
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
        }
    }

}