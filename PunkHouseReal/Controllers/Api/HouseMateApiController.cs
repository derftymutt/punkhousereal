using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Data;
using PunkHouseReal.Models;
using PunkHouseReal.Services.DataAccess;
using PunkHouseReal.Services.DataAccess.Interfaces;

namespace PunkHouseReal.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Housemate")]
    public class HouseMateApiController : Controller
    {
        #region properties

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHouseMateDataAccess _houseMateDataAccess;

        #endregion

        #region constructors

        public HouseMateApiController(UserManager<ApplicationUser> userManager, IHouseMateDataAccess houseMateDataAccess)
        {
            _userManager = userManager;
            _houseMateDataAccess = houseMateDataAccess;
        }

        #endregion

        #region public methods

        [HttpPut, Route("{houseId:int}")]
        public async Task<IActionResult> UpdateHouseMate(int houseId)
        {
            try
            {
                //get current user
                var currentUserId = _userManager.GetUserId(HttpContext.User);
                HouseMate houseMate = _houseMateDataAccess.GetHouseMate(currentUserId);

                //update houseMates HouseId
                await _houseMateDataAccess.UpdateHouseId(houseMate, houseId);

                return Ok(houseMate);

            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

    }
}