using PunkHouseReal.Data;
using PunkHouseReal.Models;
using PunkHouseReal.Services.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PunkHouseReal.Services.DataAccess
{
    public class HouseDataAccess : IHouseDataAccess
    {
        #region properties

        private readonly ApplicationDbContext _database;

        #endregion 

        #region constructors

        public HouseDataAccess(ApplicationDbContext database)
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

        public House AddHouse(House house)
        {
            _database.Houses.Add(house);
            _database.SaveChanges();
            return house;
        }

        #endregion  


    }
}
