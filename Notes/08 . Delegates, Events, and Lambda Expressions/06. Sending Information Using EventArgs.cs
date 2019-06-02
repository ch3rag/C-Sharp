// EVENTS ARGS



using System;

namespace Experiment {

    public class CarEventArgs : EventArgs {
        public readonly string Message;
        public CarEventArgs(string message) {
            this.Message = message;
        }
    }

    public class Car {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool isDead;

        public delegate void CarEngineHandler(Object source, CarEventArgs e);

        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;   


        public Car() { }

        public Car(string name, int maxSpeed, int currentSpeed) {
            this.PetName = name;
            this.MaxSpeed = maxSpeed;
            this.CurrentSpeed = currentSpeed;
        }

        public void Accelerate(int delta) {
            if (isDead) {
                // NOTIFY
                if (Exploded != null) {
                    Exploded(this, new CarEventArgs("Sorry! your car is dead..."));
                }
            } else {
                
                CurrentSpeed += delta;
                
                if ((MaxSpeed - CurrentSpeed) < 10 && AboutToBlow != null) {
                    // NOTIFY
                    AboutToBlow(this, new CarEventArgs("Careful Buddy! Gonna Blow!"));
                }

                if (CurrentSpeed > MaxSpeed) {
                    isDead = true;
                } else {
                    Console.WriteLine("Current Speed: {0}", CurrentSpeed);
                }
            }
        }
    }

    public class Program {
        public static void Main(string[] args) {

            Car.CarEngineHandler carAboutToBlow = new Car.CarEngineHandler(CarAboutToBlow);
            Car.CarEngineHandler exploded = new Car.CarEngineHandler(CarIsDoomed);

            Car c = new Car("Zippy", 100, 20);

            c.Exploded += exploded;
            c.AboutToBlow += carAboutToBlow;

            // OR USING METHOD GROUP COVERSION ASSISTANCE PROVIDED BY VISUAL STUDIO

            c.AboutToBlow += c_AboutToBlow;

            for (int i = 0; i < 20; i++) {
                c.Accelerate(5);
            }
            Console.ReadKey();
        }

        static void c_AboutToBlow(object source, CarEventArgs e) {
            if (source is Car) source = ((Car)source).PetName;
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} says: {1}", source, e.Message);
            Console.ForegroundColor = c;
        }

        public static void CarAboutToBlow(object source, CarEventArgs e) {
            if (source is Car) source = ((Car)source).PetName;
            Console.WriteLine("************ CRITICAL ALERT ************");
            Console.WriteLine("{0} says: {1}", source, e.Message);
        }

        public static void CarIsDoomed(object source, CarEventArgs e) {
            if (source is Car) source = ((Car)source).PetName;
            Console.WriteLine("{0} says: {1}", source, e.Message);
        }


    }
}