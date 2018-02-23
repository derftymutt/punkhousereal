using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Models.BindingModels;
using PunkHouseReal.Services;

namespace PunkHouseReal.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/houseMates")]
    public class HouseMateApiController : Controller
    {
        #region properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHouseMateService _houseMateService;

        #endregion

        #region constructors

        public HouseMateApiController(UserManager<ApplicationUser> userManager, IHouseMateService houseMateDataAccess)
        {
            _userManager = userManager;
            _houseMateService = houseMateDataAccess;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        [Authorize]
        public IActionResult GetHouseMate()
        {
            return Ok(GetCurrentHouseMate());
        }

        [HttpPatch, Route("")]
        [Authorize]
        public async Task<IActionResult> UpdateHouseMate([FromBody]UpdateHouseMateBindingModel model)
        {
            //This method is currently used to update HouseId when a housemate joins a House 
            if (ModelState.IsValid)
            {
                try
                {
                    HouseMate houseMate = GetCurrentHouseMate();
                    ParseHouseMateFields(houseMate, model);
                    await _houseMateService.UpdateHouseMate(houseMate);

                    return Ok(houseMate);

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return BadRequest("There was a problem updating the HouseMate");

        }

        //Expenses I owe, if creatorId is passed then it returns expenses I am owed
        //api/houseMates/{id}/expenses
        [HttpGet, Route("{houseMateId}/expenses")]
        public IActionResult GetHouseMateExpenses(string houseMateId, string creatorId, bool isExpensesIOwe = true)
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            if (currentUserId != houseMateId)
                throw new Exception("HouseMateId does not match current signed in user");

            //determine whether to retrieve expenses I owe or expenses owed to me
            if (!String.IsNullOrEmpty(creatorId))
                isExpensesIOwe = false;

            try
            {
                if (isExpensesIOwe)
                    return Ok(_houseMateService.GetHouseMateExpensesIOwe(houseMateId)); //Expenses I owe
                else
                    return Ok(_houseMateService.GetHouseMateExpensesOwedMe(houseMateId, creatorId)); //Expenses owed to me
            }
            catch (Exception)
            {

                throw;
            }
        }

        //api/houseMates/{id}/expenses/{id}
        [HttpPatch, Route("{houseMateId}/expenses/{expenseId:int}")]
        [Authorize]
        public IActionResult UpdateHouseMateExpense([FromRoute] string houseMateId, int expenseId, [FromBody]HouseMateExpenseBindingModel model)
        {
            if (ModelState.IsValid)
            {
                if (houseMateId != model.HouseMateId || expenseId != model.ExpenseId)
                    throw new Exception("one or more route parameters do not match model values");

                try
                {
                    HouseMateExpense houseMateExpense = _houseMateService.GetHouseMateExpense(houseMateId, expenseId);
                    ParseHouseMateExpenseFields(houseMateExpense, model);
                    _houseMateService.UpdateHouseMateExpense(houseMateExpense);

                    return Ok(houseMateExpense);
                }
                catch (Exception)
                {
                    throw new Exception("There was an error updating the HouseMateExpense");
                }

            }

            return BadRequest("There was an error updating the HouseMateExpense");

        }

        #endregion 
        
        #region Private Helper Methods

        private HouseMate GetCurrentHouseMate()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            return _houseMateService.GetHouseMate(currentUserId);
        }

        private void ParseHouseMateFields(HouseMate houseMate, UpdateHouseMateBindingModel model)
        {
            houseMate.HouseId = model.HouseId;
        }

        private void ParseHouseMateExpenseFields(HouseMateExpense houseMateExpense, HouseMateExpenseBindingModel model)
        {
            houseMateExpense.ExpenseId = model.ExpenseId;
            houseMateExpense.HouseMateId = model.HouseMateId;
            houseMateExpense.IsMarkedPaid = model.IsMarkedPaid;
            houseMateExpense.IsPaid = model.IsPaid;
        }

        #endregion

    }
}