using System;
using AutoLotDAL.Models;
using AutoLotDAL.DataOperations;
using AutoLotDAL.BulkImport;
using System.Collections.Generic;
using System.Linq;

namespace AutoLotClient {
    class Program {
        static void Main(string[] args) {
            
            InventoryDAL dal = new InventoryDAL("Data Source=CHIRAG-DESK\\SQLEXPRESS; Initial Catalog=AutoLot; Integrated Security=true");

            // DisplayInventory(dal);
            // GetFirstCarByName(dal);
            // AddNewCar(dal);
            // DisplayInventory(dal);
            // GetPetName(dal, 10);
            TestBulkCopy();
            DisplayInventory(dal);
            Console.ReadKey();
        }

        public static void TestBulkCopy() {
            List<Car> cars = new List<Car>() {
                new Car { PetName = "Ray", Color = "Black", Make = "Hyundai" },
                new Car { PetName = "Charge", Color = "Violet", Make = "Toyota" },
                new Car { PetName = "Electro", Color = "Maroon", Make = "Ferrari" },
                new Car { PetName = "Mark", Color = "Blue", Make = "Volvo" }
            };

            ProcessBulkImport importer = new ProcessBulkImport("Data Source=CHIRAG-DESK\\SQLEXPRESS; Initial Catalog=AutoLot; Integrated Security=true");
            importer.ExecuteBulkImport<Car>(cars, "Inventory");
            Console.WriteLine("************* BULK IMPORT DONE *************");
        }

        public static void DisplayInventory(InventoryDAL dal) {
            List<Car> cars = dal.GetAllInventory();
            Console.WriteLine("CarId\tMake\tColor\tPet Name");
            foreach (Car car in cars) {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", car.CarId, car.Make, car.Color, car.PetName);
            }
            Console.WriteLine();
        }

        public static void GetFirstCarByName(InventoryDAL dal) {
            List<Car> cars = dal.GetAllInventory();
            Car firstCar = dal.GetCar(cars.OrderBy(x => x.PetName).Select(x => x.CarId).First());
            Console.WriteLine("******* First Car By Name *******");
            Console.WriteLine("{0}\t{1}\t{2}\t{3}", firstCar.CarId, firstCar.Make, firstCar.Color, firstCar.PetName);
            Console.WriteLine();
        }

        public static void DeleteCarById(InventoryDAL dal, int id) {
            try {
                dal.DeletCar(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        public static void AddNewCar(InventoryDAL dal) {
            Car newCar = new Car() {
                PetName = "Camaro",
                Make = "Ford",
                Color = "Yellow"
            };

            dal.InsertAuto(newCar);
        }

        public static void GetPetName(InventoryDAL dal, int id) {
            string petName = dal.LookUpPetName(id);
            Console.WriteLine("PetName For CarId = {1} Is: {0}", petName, id);
        }

        public static void SimulateTransactions(InventoryDAL dal) {
            dal.ProcessCreditRisk(true, 1);
            dal.ProcessCreditRisk(false, 1);
        }
    }
}
