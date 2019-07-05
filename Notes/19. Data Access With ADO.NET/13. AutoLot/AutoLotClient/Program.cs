using System;
using AutoLot.AutoLotDAL;
using AutoLot.Models;
using AutoLot.BulkOperations;

using System.Collections.Generic;

namespace AutoLotClient {
    class Program {
        public static void Main(string[] args) {
            string connectionString = "Data Source=CHIRAG-DESK\\SQLEXPRESS; Initial Catalog=AutoLot; Integrated Security=true";
            InventoryDAL dal = new InventoryDAL(connectionString);
            CustomerDAL cDal = new CustomerDAL(connectionString);

            // DisplayInventory(dal);
            // DisplayCar(dal, -1);
            // AddCar(dal);
            // DeleteCar(dal, 44);
            // DisplayInventory(dal);
            // UpdateCarPetName(dal);
            // DisplayInventory(dal);
            // cDal.ProcessCreditRisk(3, false);

            // ProcessBulkImport importer = new ProcessBulkImport(connectionString);
            // if (importer.Execute<Car>(new List<Car>() {
            //     new Car() { Make = "Fiat", Color = "Violet", PetName = "Trio" },
            //     new Car() { Make = "VW", Color = "Blue", PetName = "Pug" },
            //     new Car() { Make = "Fort", Color = "Yellow", PetName = "Ben" }
            // }, "Inventory")) {
            //     Console.WriteLine("Import Successful!");
            // } else {
            //     Console.WriteLine("Import Failed!");
            // }

            DisplayInventory(dal);

            Console.ReadKey();
        }

        public static void DisplayInventory(InventoryDAL dal) {
            List<Car> cars = dal.GetInventory();
            foreach (Car car in cars) {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", car.CarId, car.PetName, car.Make, car.Color);
            }
            Console.WriteLine();
        }

        public static void DisplayCar(InventoryDAL dal, int carId) {
            Car car = dal.GetCarById(carId);
            if (car != null) {
                Console.WriteLine("*************** CAR DETAILS ***************");
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", car.CarId, car.PetName, car.Make, car.Color);
            } else {
                Console.WriteLine("Not Found!");
            }

            Console.WriteLine();
        }

        public static void AddCar(InventoryDAL dal) {
            Car car = new Car() {
                PetName = "Debby",
                Make = "Fiat",
                Color = "Magenta"
            };

            int carId;
            if (dal.AddCar(car, out carId)) {
                Console.WriteLine("Car Added! ID: {0}", carId);
            } else {
                Console.WriteLine("Insert Failed!");
            }

        }

        public static void DeleteCar(InventoryDAL dal, int CarId) {
            if (dal.DeleteCar(CarId) > 0) {
                Console.WriteLine("Delete Successful");
            } else {
                Console.WriteLine("No Rows Deleted!");
            }
        }

        public static void UpdateCarPetName(InventoryDAL dal) {
            string newPetName = "Zurk";
            if (dal.UpdatePetName(51, newPetName) > 0) {
                Console.WriteLine("Update Successful!");
            } else {
                Console.WriteLine("Update Failed!");
            }
        }
    }
}
