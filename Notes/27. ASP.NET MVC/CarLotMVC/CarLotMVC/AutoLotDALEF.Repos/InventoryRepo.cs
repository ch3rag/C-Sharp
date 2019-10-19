using System;
using AutoLotDALEF.Repos;
using AutoLotDALEF.Models;
using System.Linq;

namespace AutoLotDALEF.Repos {
    public class InventoryRepo : BaseRepo<Inventory> {
        public override System.Collections.Generic.List<Inventory> GetAll() {
            return Context.Cars.OrderBy(x => x.PetName).ToList();
        }
    }
}
