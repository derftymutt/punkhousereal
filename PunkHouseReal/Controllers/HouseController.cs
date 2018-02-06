using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Models;

namespace PunkHouseReal.Controllers
{
    [Route("[controller]")]
    public class HouseController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HouseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("create")]
        public IActionResult Create()
        {

            var userId = _userManager.GetUserId(HttpContext.User);
            ItemViewModel<string> model = new ItemViewModel<string>();
            model.Item = userId;
            return View(model);
        }
    }
}