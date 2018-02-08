using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Data;
using PunkHouseReal.Models;
using PunkHouseReal.Services;

namespace PunkHouseReal.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Housemate")]
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

        #region public methods

        [HttpGet]
        [Authorize]
        public IActionResult GetHouseMate()
        {
            return Ok(GetCurrentHouseMate());
        }

        [HttpPut, Route("{houseId:int}")]
        [Authorize]
        public async Task<IActionResult> UpdateHouseMate(int houseId)
        {
            try
            {
                //get current user var currentUserId = _userManager.GetUserId(HttpContext.User);
                HouseMate houseMate = GetCurrentHouseMate();

                //update houseMates HouseId
                await _houseMateService.UpdateHouseId(houseMate, houseId);

                return Ok(houseMate);

            }
            catch (Exception)
            {
                throw;
            }

        }

        private HouseMate GetCurrentHouseMate()
        {
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            return _houseMateService.GetHouseMate(currentUserId);
        }

        #endregion

    }
}