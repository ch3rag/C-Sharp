// INDEXERS

using System;
using System.Collections;
using System.Collections.Generic;

namespace Experiment {

    public class Car {
        public string PetName { get; set; }
        public uint MaxSpeed { get; set; }

        public Car(string name, uint maxSpeed) {
            this.PetName = name;
            this.MaxSpeed = maxSpeed;
        }
    }


    public class Garage : IEnumerable {
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();

        public int CarCount {
            get {
                return cars.Count;
            }
        }

        public Car this[string key] {
            get {
                return cars[key];
            }
            set {
                cars[key] = value;
            }
        }

        public IEnumerator GetEnumerator() {
            return cars.GetEnumerator();
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Garage myGarage = new Garage();
            myGarage["Zippy"] = new Car("Zippy", 100);
            myGarage["McQueen"] = new Car("McQueen", 150);

            foreach (KeyValuePair<string, Car> c in myGarage) {
                Console.WriteLine("{0}'s top speed is {1}", c.Value.PetName, c.Value.MaxSpeed);
            }

            Console.WriteLine(myGarage["Zippy"].PetName);
            Console.ReadKey();
        }
    }
}