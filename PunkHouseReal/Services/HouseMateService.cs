using Microsoft.AspNetCore.Identity;
using PunkHouseReal.Data;
using PunkHouseReal.Models;
using PunkHouseReal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services
{
    public class HouseMateService : IHouseMateService
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        public HouseMateService(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
        {
            _database = database;
            _userManager = userManager;
        }

        public HouseMate GetHouseMate(string userId)
        {
            return _database.HouseMates.FirstOrDefault(housemate => housemate.Id == userId);
        }

        public async Task UpdateHouseId(HouseMate houseMate, int houseId)
        {
            houseMate.HouseId = houseId;
            await _userManager.UpdateAsync(houseMate);


        }
    }
}
