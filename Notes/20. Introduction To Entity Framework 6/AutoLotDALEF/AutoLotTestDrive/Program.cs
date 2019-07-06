using System;
using AutoLotDALEF.Models;
using AutoLotDALEF.EF;
using AutoLotDALEF.Repos;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace AutoLotTestDrive {
    public class Program {
        public static void Main(string[] args) {

            // DisplayInventory();
            // TestConcurrency();
            UpdateRecord(1);
            Console.ReadKey();
        }

        public static void DisplayInventory() {
            using (InventoryRepo repo = new InventoryRepo()) {
                List<Inventory> cars = repo.GetAll();
                foreach (Inventory car in cars) {
                    Console.WriteLine(car);
                }
            }
        }

        public static void AddNewRecord(Inventory car) {
            using (InventoryRepo repo = new InventoryRepo()) {
                repo.Add(car);
            }
        }

        public static void UpdateRecord(int carId) {
            using (InventoryRepo repo = new InventoryRepo()) {
                Inventory carToUpdate = repo.GetOne(carId);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Red";
                repo.Save(carToUpdate);
            }
        }

        public static void RemoveRecordByCar(Inventory car) {
            using (InventoryRepo repo = new InventoryRepo()) {
                repo.Delete(car);
            }
        }
        public static void RemoveRecordById(int carId, byte[] timeStamp) {
            using (InventoryRepo repo = new InventoryRepo()) {
                repo.Delete(carId, timeStamp);
            }
        }

        private static void TestConcurrency() {
            InventoryRepo repo1 = new InventoryRepo();
            InventoryRepo repo2 = new InventoryRepo();
            Inventory car1 = repo1.GetOne(1);
            Inventory car2 = repo2.GetOne(1);

            car1.PetName = "NewName";
            repo1.Save(car1);

            car2.PetName = "OtherName";
            try {
                repo2.Save(car2);
                Console.WriteLine("Done!");
            } catch (DbUpdateConcurrencyException ex) {
                Console.WriteLine("Exception!");
                var entries = ex.Entries;
                foreach (var entry in entries ) {
                    Console.WriteLine("Orginal Value: {0}", entry.OriginalValues["PetName"]);
                    Console.WriteLine("Current Value: {0}", entry.CurrentValues["PetName"]);
                    Console.WriteLine("Database Value: {0}", entry.GetDatabaseValues()["PetName"]);
                }
            }
        }
    }
}
