using Microsoft.EntityFrameworkCore;
using PunkHouseReal.Data;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services
{
    public class HouseService : IHouseService
    {
        #region properties

        private readonly ApplicationDbContext _database;

        #endregion 

        #region constructors

        public HouseService(ApplicationDbContext database)
        {
            _database = database;
        }

        #endregion  

        #region public methods

        public void Initialize()
        {
            if (_database.Houses.Count() == 0)
            {
                _database.Houses.Add(new House()
                {
                    Address1 = "test Address1",
                    Address2 = "test Address2",
                    Zip = "90042",
                    City = "Los Angeles",
                    State = "CA",
                    Name = "Strange View"
                });

                _database.SaveChanges();
            }
            return;
        }

        public List<House> GetAll()
        {
            return _database.Houses.ToList();
        }

        public House GetHouse(int houseId)
        {
            return _database.Houses.Include(house => house.HouseMates).First(house => house.Id == houseId);
        }

        public House AddHouse(House house)
        {
            _database.Houses.Add(house);
            _database.SaveChanges();
            return house;
        }

        #endregion  


    }
}
