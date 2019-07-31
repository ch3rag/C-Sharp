using System;
using AutoMapper;
using AutoLotDALEF.Models;
using AutoLotDALEF.Repos;
using System.Collections.Generic;

public class AutoLotService : IAutoLotService {
    public AutoLotService() {
        Mapper.Initialize(config => config.CreateMap<Inventory, InventoryRecord>());
    }

    public void InsertCar(string make, string color, string petName) {
        InventoryRepo repository = new InventoryRepo();
        repository.Add(new Inventory() { Make = make, Color = color, PetName = petName });
        repository.Dispose();
    }

    public void InsertCar(InventoryRecord car) {
        InventoryRepo repository = new InventoryRepo();
        repository.Add(new Inventory() { Make = car.Make, Color = car.Color, PetName = car.PetName });
        repository.Dispose();
    }

    public List<InventoryRecord> GetInventory() {
        InventoryRepo repository = new InventoryRepo();
        List<Inventory> records = repository.GetAll();
        List<InventoryRecord> results = Mapper.Map<List<InventoryRecord>>(records);
        repository.Dispose();
        return results;
    }
}
