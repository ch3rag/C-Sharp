// Applying LINQ Queries to Collection Objects

// LINQ query expressions can also manipulate data within members of the System.Collections.Generic

using System;
using System.Linq;
using System.Collections.Generic;

namespace Experiment {

    public class Car {
        public string PetName { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public string Make { get; set; }

        public override string ToString() {
            return string.Format("[PetName: {0}; Color: {1}; Speed: {2}; Make: {3}]", this.PetName, this.Color, this.Speed, this.Make);
        }
    }
    public class Program {
        public static void Main(string[] args) {
            List<Car> myCars = new List<Car>() {
                new Car() { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car() { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car() { PetName = "Mary", Color = "Black", Speed = 55, Make = "BMW" },
                new Car() { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car() { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };


            // FIND CARS WHOSE SPEED IS GREATER THAN 55
            var fastCars = from car in myCars where car.Speed > 55 select car;
            foreach (Car car in fastCars) {
                Console.WriteLine(car);
            }

            // FIND CARS WHOSE SPEED > 90 AND MAKE IS BMW

            var fastBMWCars = from car in myCars where car.Make == "BMW" && car.Speed > 90 select car;

            foreach (Car car in fastBMWCars) {
                Console.WriteLine(car);
            }



            Console.ReadKey();
        }
    }
}