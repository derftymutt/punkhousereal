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
    [Route("api/Housemates")]
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

        #endregion

    }
}