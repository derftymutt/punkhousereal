using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

namespace PunkHouseReal.Controllers
{
    [Produces("application/json")]
    [Route("api/House")]
    public class HouseApiController : Controller
    {
        #region properties
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHouseService _houseService;
        private readonly IHouseMateService _houseMateService;
        
        #endregion

        #region constructors
        public HouseApiController(UserManager<ApplicationUser> userManager, IHouseService houseDataAccess, IHouseMateService houseMateDataAccess)
        {
            _userManager = userManager;
            _houseService = houseDataAccess;
            _houseMateService = houseMateDataAccess;

            _houseService.Initialize();
            
        }
        #endregion

        #region public methods
        /// <summary>
        /// get a list of all houses
        /// </summary>
        /// <returns>list of all houses</returns>
        [HttpGet]
        public IEnumerable<House> GetHouses()
        {
            return _houseService.GetAll();
        }

        [HttpGet, Route("{houseId:int}")]
        [Authorize]
        public IActionResult GetHouse([FromRoute]int houseId)
        {
            //get current user
            var currentUserId = _userManager.GetUserId(HttpContext.User);
            HouseMate currentUser = _houseMateService.GetHouseMate(currentUserId);
            if (houseId != currentUser.HouseId)
                return BadRequest("Housemate's houseId does not match");

            House house = _houseService.GetHouse(houseId);
            return Ok(house);
        }

        /// <summary>
        /// Create a new house and become a member of it
        /// </summary>
        /// <param name="model"></param>
        /// <returns>House created</returns>
        [HttpPost, Route("")]
        [Authorize]
        public async Task<IActionResult> CreateHouse([FromBody]HouseBindingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var houseMate = _houseMateService.GetHouseMate(model.CreatorId);

                    if (houseMate.HouseId != 0)
                    {
                        throw new Exception("houseMate already is a member of a house");
                    }

                    //first add house to db
                    House house = new House();
                    ParseHouseFields(house, model);
                    House houseAdded = _houseService.AddHouse(house);

                    //Add houseId to houseMate in db
                    await _houseMateService.UpdateHouseId(houseMate, houseAdded.Id);

                    return Ok(houseAdded);

                }
                catch (Exception)
                {

                    throw new Exception("there was an error adding the house");
                }
            }

            return BadRequest("Shitty request");
        }

        #endregion

        #region private helper methods
        private void ParseHouseFields(House house, HouseBindingModel model)
        {
            house.Name = model.Name;
            house.Address1 = model.Address1;
            house.Address2 = model.Address2;
            house.City = model.City;
            house.Zip = model.Zip;
            house.State = model.State;
            house.CreatorId = model.CreatorId;
        }
        #endregion
    }
}