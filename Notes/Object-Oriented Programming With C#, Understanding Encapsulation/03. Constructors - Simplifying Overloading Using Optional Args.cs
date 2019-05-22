// SOLVING OVERLOADING USING OPTIONAL ARGS

using System;


namespace Notes {

    public class Car {
        public int topSpeed;
        public string driverName;
        public Car(int topSpeed = 0, string driverName = "") {
            this.driverName = driverName;
            if (topSpeed > 10) {
                topSpeed = 10;
            }
            this.topSpeed = topSpeed;
        }
    }
    

    public class Program {
        public static void Main(string[] args) {
            
            // ANY OF THESE WILL WORK
            Car c1 = new Car();
            
            Car c2 = new Car(2);
            
            Car c3 = new Car(driverName: "Chirag");
            
            Car c4 = new Car(12, "Chirag");
            
            Console.ReadKey();
        }
    }
}