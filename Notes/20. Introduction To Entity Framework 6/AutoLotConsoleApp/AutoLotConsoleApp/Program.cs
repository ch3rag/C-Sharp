using System;
using AutoLotConsoleApp.EF;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AutoLotConsoleApp {

    public class ShortCar {
        public string CarNickName { get; set; }
        public int id { get; set; }
        public override string ToString() {
            return String.Format("Name: {0}, ID: {1}", this.CarNickName, this.id);
        }
    }

    class Program {
        static void Main(string[] args) {
            
            // INSERT
            // int id = AddNewRecord();
            // Console.WriteLine(id);

            // SELECT
            // PrintInventory();
            // PrintInventoryUsingQuery();
            // PrintInventoryAsShortCar();
            // PrintInventoryUsingLinq();

            // FIND
            // FindCar(1);

            // LAZY LOADING
            // GetAllOrdersUsingLazyLoading();

            // EAGER LOADING
            // GetAllOrdersUsingEagerLoading();

            // EXPLICIT LOADING
            // GetAllOrdersUsingExplicitLoading();

            // DELETING
            // DeleteRecordByTracking(56);
            // DeleteRecordByEntityState(57);

            // UPADTE
            UpdateCarRecord(55);

            Console.ReadKey();
        }

        public static int AddNewRecord() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                try {
                    Car car = new Car() { Make = "Yugo", Color = "Brown", PetName = "Brownie" };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
        }

        public static void PrintInventory() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                foreach (Car car in context.Cars) {
                    Console.WriteLine(car);
                }
            }
        }

        public static void PrintInventoryUsingQuery() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                foreach (Car c in context.Cars.SqlQuery("SELECT CarID, Make, Color, PetName FROM Inventory WHERE Make = @p0", "BMW")) {
                    Console.WriteLine(c);
                }
            }
        }

        public static void PrintInventoryAsShortCar() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                foreach (ShortCar car in context.Database.SqlQuery(typeof(ShortCar), "SELECT CarId AS Id, PetName AS CarNickName FROM Inventory")) {
                    Console.WriteLine(car);
                }
            }
        }

        public static void PrintInventoryUsingLinq() {
            using (AutoLotEntities context = new AutoLotEntities()) {
                (from car in context.Cars where car.Make == "VW" select new { CarId = car.CarId, Brand = car.Make }).ToList().ForEach(item => {
                    Console.WriteLine(item);
                });
            }
        }

        public static void FindCar(int id) {
            using (AutoLotEntities context = new AutoLotEntities()) {
                Console.WriteLine(context.Cars.Find(id));
            }
        }

        public static void GetAllOrdersUsingLazyLoading() {
            // unefficient!
            using (AutoLotEntities context = new AutoLotEntities()) {
                // disable lazyloading
                context.Configuration.LazyLoadingEnabled = false;
                // executes a single query to get all the cars
                foreach (Car car in context.Cars) {
                    // executes another single query to get all the orders related to car
                    foreach (Order order in car.Orders) {
                        Console.WriteLine(order);
                    }
                }
            }
        }

        public static void GetAllOrdersUsingEagerLoading() {
            // efficient 
            using (AutoLotEntities context = new AutoLotEntities()) {
                foreach (Car car in context.Cars.Include("Orders")) {
                    foreach (Order order in car.Orders) {
                        Console.WriteLine(order);
                    }
                }
            }
        }

        public static void GetAllOrdersUsingExplicitLoading() {
            // efficient
            using (AutoLotEntities context = new AutoLotEntities()) {
                context.Configuration.LazyLoadingEnabled = false;
                foreach(Car car in context.Cars) {
                    context.Entry(car).Collection("Orders").Load();
                    foreach (Order order in car.Orders) {
                        Console.WriteLine(order);
                    }
                }
                foreach (Order order in context.Orders) {
                    context.Entry(order).Reference("Car").Load();
                    Console.WriteLine(order.Car);
                }
            }
        }

        public static void DeleteRecordByTracking(int carId) {
            using (AutoLotEntities context = new AutoLotEntities()) {
                Car car = context.Cars.Find(carId);
                if (car != null) {
                    context.Cars.Remove(car);
                }
                if (context.Entry(car).State != EntityState.Deleted) {
                    throw new Exception("Unable to delete record!");
                } else {
                    Console.WriteLine("Deleted");
                }
                context.SaveChanges();
            }
        }

        public static void DeleteRecordByEntityState(int carId) {
            // If an instance with the same primary key is already being tracked, this method will fail, 
            // since you can’t have two of the same entities with the same primary key being tracked by 
            // the DbChangeTracker.

            using (AutoLotEntities context = new AutoLotEntities()) {
                Car carToDelete = new Car() { CarId = carId };
                context.Entry(carToDelete).State = EntityState.Deleted;
                try {
                    context.SaveChanges();
                    Console.WriteLine("Deleted.");
                } catch (DbUpdateConcurrencyException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void UpdateCarRecord(int carId) {
            using (AutoLotEntities context = new AutoLotEntities()) {
                Car carToUpdate = context.Cars.Find(carId);
                if (carToUpdate != null) {
                    Console.WriteLine("State Before Update: {0}", context.Entry(carToUpdate).State);
                    carToUpdate.PetName = "Sabrina";
                    Console.WriteLine("State After Update: {0}", context.Entry(carToUpdate).State);
                    context.SaveChanges();
                }
            }
        }
    }
}
