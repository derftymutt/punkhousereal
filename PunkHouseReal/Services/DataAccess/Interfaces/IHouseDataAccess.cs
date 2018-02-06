using System.Collections.Generic;
using PunkHouseReal.Models;

namespace PunkHouseReal.Services.DataAccess.Interfaces
{
    public interface IHouseDataAccess
    {
        House AddHouse(House house);
        List<House> GetAll();
        void Initialize();
    }
}