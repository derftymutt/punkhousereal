using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PunkHouseReal.Data;
using PunkHouseReal.Models;

namespace PunkHouseReal.Controllers
{
    [Produces("application/json")]
    [Route("api/House")]
    public class HouseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HouseController(ApplicationDbContext context)
        {
            _context = context;

            if (_context.Houses.Count() == 0)
            {
                _context.Houses.Add(new House()
                {
                    Address1 = "test Address1",
                    Address2 = "test Address2",
                    Zip = 90042,
                    City = "Los Angeles",
                    State = "CA",
                    Name = "Strange View"
                });

                _context.SaveChanges();
            }
        }

        //[HttpGet, Authorize]
        public IEnumerable<House> GetAll()
        {
            //var currentUser = HttpContext.User;

            return _context.Houses.ToList();

        }
    }
}