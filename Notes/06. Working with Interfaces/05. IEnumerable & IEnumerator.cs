// IENUMERABLE & IENUMERATOR


// System.Collections.IEnumerable:
// This interface is used to allow a class or struct to be able to get traversed

// public interface IEnumerable {
//     IEnumerator GetEnumerator();
// }


// System.Collections.IEnumerator:
// This interface provides the infrastructure to allow the caller to traverse
// the internal objects contained by the IEnumerable-compatible container.

// public interface IEnumerator {
//     bool MoveNext ();            // Advance the internal position of the cursor.
//     object Current { get;}       // Get the current item (read-only property).
//     void Reset ();               // Reset the cursor before the first member.
// }

using System;
using System.Collections;

namespace Experiment {
    class Car {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }

        public Car() { }
        public Car(string name, int speed) {
            this.PetName = name;
            this.CurrentSpeed = speed;
        }

        public void Print() {
            Console.WriteLine("{0} is moving at {1} KMPH", this.PetName, this.CurrentSpeed);
        }
    }

    // IN ORDER TO MAKE GARAGE ENUMERABLE WE HAVE TO IMPLEMENT GetEnumerator() METHOD IN System.Collections.IEnumerable INTERFACE
    public class Garage : IEnumerable {
        private Car[] cars = new Car[4];
        public Garage() {
            cars[0] = new Car("Rusty", 30);
            cars[1] = new Car("Clunker", 55);
            cars[2] = new Car("Zippy", 30);
            cars[3] = new Car("Fred", 30);
        }

        public IEnumerator GetEnumerator() {
            return cars.GetEnumerator();
        }

        // BETTER PRACTISE IS TO HIDE GETENUMERATOR() METHOD BY EXPLICIT IMPLEMENTATION
        // IEnumerator IEnumerable.GetEnumerator() {
        //     return cars.GetEnumerator();
        // }
        // I'M NOT DOING SO JUST TO SHOW MANUAL TRAVERSAL
    }

    class Program {
        static void Main(string[] args) {

            Garage myGarage = new Garage();
            // MANUAL TRAVERSING
            IEnumerator ie = myGarage.GetEnumerator();

            
            // MUST START IT MY MOVING IT FORWARD
            while (true) {
                try {
                    ie.MoveNext();
                    ((Car)ie.Current).Print();
                } catch (InvalidOperationException ex) {
                    Console.WriteLine("FINISHED");
                    ie.Reset();
                    break;
                }
            }

            // "ENUMERABLE" TYPES CAN BE TRAVERSED USING FOREACH LOOP
            foreach (Car c in myGarage) {
                c.Print();
            }

            Console.ReadKey();
        }
    }
}
 