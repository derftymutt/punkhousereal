using Microsoft.AspNetCore.Identity;
using PunkHouseReal.Data;
using PunkHouseReal.Models;
using PunkHouseReal.Services.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services.DataAccess
{
    public class HouseMateDataAccess : IHouseMateDataAccess
    {
        private readonly ApplicationDbContext _database;
        private readonly UserManager<ApplicationUser> _userManager;

        public HouseMateDataAccess(ApplicationDbContext database, UserManager<ApplicationUser> userManager)
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
