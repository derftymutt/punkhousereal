using System.Collections.Generic;
using PunkHouseReal.Domain;
using PunkHouseReal.Models;

namespace PunkHouseReal.Services
{
    public interface IHouseService
    {
        House AddHouse(House house);
        List<House> GetAll();
        House GetHouse(int houseId);
        void Initialize();
    }
}