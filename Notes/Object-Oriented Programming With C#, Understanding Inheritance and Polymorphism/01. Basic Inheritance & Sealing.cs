// INHERITANCE EXAMPLE

using System;
namespace Notes {

    public class Car {
        public readonly int maxSpeed;
        private int currentSpeed;

        public Car(int maxSpeed) {
            this.maxSpeed = maxSpeed;
        }

        public Car() {
            maxSpeed = 55;
        }

        public int Speed {
            get { return currentSpeed; }
            set {
                currentSpeed = value;
                if (currentSpeed > maxSpeed) {
                    currentSpeed = maxSpeed;
                }
            }
        }
    }

    // MINIVAN INHERITS CAR
    // MINIVAN IS SEALED AND THEREFORE CAN'T BE EXTENDED FURTHER
    public sealed class MiniVan : Car { 
        

    }
    public class Program {
        public static void Main(string[] args) {
            
            Console.ReadKey();            
        }
    }
}