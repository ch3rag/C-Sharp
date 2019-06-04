// INDEXERS

using System;
using System.Collections;

namespace Experiment {

    public class Car {
        public string PetName { get; set; }
        public uint MaxSpeed { get; set; }

        public Car(string name, uint maxSpeed) {
            this.PetName = name;
            this.MaxSpeed = maxSpeed;
        }
    }


    public class Garage {
        ArrayList cars = new ArrayList();
        public int CarCount {
            get {
                return cars.Count;

            }
        }

        public Car this[int index] {
            get {
                return cars[index] as Car;
            }
            set {
                cars.Add(value);
            }
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Garage myGarage = new Garage();
            myGarage[0] = new Car("Zippy", 100);
            myGarage[1] = new Car("McQueen", 150);

            for (int i = 0; i < myGarage.CarCount; i++) {
                Console.WriteLine(myGarage[i].PetName);
            }
            Console.ReadKey();
        }
    }
}