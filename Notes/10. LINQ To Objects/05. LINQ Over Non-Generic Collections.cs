// Applying LINQ Queries to Non-Generic Collection Objects

// It is possible to iterate over data contained within nongeneric collections using the generic Enumerable.OfType<T>() extension method.
// When calling OfType<T>() from a nongeneric collection object (such as the ArrayList), simply specify the type of item within the 
// container to extract a compatible IEnumerable<T> object. In code, you can store this data point using an implicitly typed variable.


using System;
using System.Linq;
using System.Collections;
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
            ArrayList myCars = new ArrayList {
                new Car() { PetName = "Henry", Color = "Silver", Speed = 100, Make = "BMW" },
                new Car() { PetName = "Daisy", Color = "Tan", Speed = 90, Make = "BMW" },
                new Car() { PetName = "Mary", Color = "Black", Speed = 55, Make = "BMW" },
                new Car() { PetName = "Clunker", Color = "Rust", Speed = 5, Make = "Yugo" },
                new Car() { PetName = "Melvin", Color = "White", Speed = 43, Make = "Ford" }
            };


            // Transform ArrayList into an IEnumerable<T>-compatible type
            var myCarsEnum = myCars.OfType<Car>();

            // FIND CARS WHOSE SPEED IS GREATER THAN 55
            var fastCars = from car in myCarsEnum where car.Speed > 55 select car;
            foreach (Car car in fastCars) {
                Console.WriteLine(car);
            }

            // FIND CARS WHOSE SPEED > 90 AND MAKE IS BMW

            var fastBMWCars = from car in myCarsEnum where car.Make == "BMW" && car.Speed > 90 select car;

            foreach (Car car in fastBMWCars) {
                Console.WriteLine(car);
            }


            // ALSO OfType Can BE USED TO FILTER DATA FROM NON GENERIC COLLECTION

            ArrayList mixed = new ArrayList() { 1, new Car(), "string", 'a', 56, };

            // FILTER OUT INTEGER DATA
            var filtered = mixed.OfType<int>();
            foreach (var x in filtered) {
                Console.WriteLine(x);
            }



            Console.ReadKey();
        }
    }
}