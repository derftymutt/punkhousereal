using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using PunkHouseReal.Services;

namespace PunkHouseReal.Controllers
{
    [Route("myhome"), Authorize]
    public class MyHomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHouseMateService _houseMateService;

        public MyHomeController(UserManager<ApplicationUser> userManager, IHouseMateService HouseMateService)
        {
            _userManager = userManager;
            _houseMateService = HouseMateService;
        }

        public IActionResult Index()
        {
            var signedInUserId = _userManager.GetUserId(HttpContext.User);
            var user = _houseMateService.GetHouseMate(signedInUserId);
            ItemViewModel<HouseMate> model = new ItemViewModel<HouseMate>();
            model.Item = user;
            return View(model);
        }
    }
}