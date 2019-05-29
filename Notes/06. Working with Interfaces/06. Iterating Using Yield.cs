// ITERATORS
// an iterator is a member that specifies how a container’s internal items should be returned when processed by foreach

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
            // This implementation of GetEnumerator() iterates over the subitems using internal foreach
            // logic and returns each Car to the caller using the yield return syntax. The yield keyword is used to specify
            // the value (or values) to be returned to the caller’s foreach construct. When the yield return statement is
            // reached, the current location in the container is stored, and execution is restarted from this location the next
            // time the iterator is called.

            foreach (Car c in cars) {
                yield return c;
            }

            // IT IS ALSO POSSIBLE TO DEFINE ITERATOR AS FOLLOWS:
            // yield return cars[0];
            // yield return cars[1];
            // yield return cars[2];
            // yield return cars[3];
        }
    }

    class Program {
        static void Main(string[] args) {

            Garage myGarage = new Garage();
            // MANUAL TRAVERSING
            IEnumerator ie = myGarage.GetEnumerator();


            // MANUAL TRAVERSAL DOES NOT WORK AS THE ENUMERATOR GET RESET AFTER THE END THE FOREACH LOOP
            // WILL RESULT IN INFINITE LOOP
            // while (true) {
            //     try {
            //         ie.MoveNext();
            //         ((Car)ie.Current).Print();
            //     } catch (InvalidOperationException ex) {
            //         Console.WriteLine("FINISHED");
            //         ie.Reset();
            //         break;
            //     }
            // }

            // ENUMERABLE TYPES CAN BE TRAVERSED USING FOREACH LOOP
            foreach (Car c in myGarage) {
                c.Print();
            }

            Console.ReadKey();
        }
    }
}
 