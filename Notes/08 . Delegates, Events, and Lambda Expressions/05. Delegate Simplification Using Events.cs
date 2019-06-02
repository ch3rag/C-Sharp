// EVENTS 

// As a shortcut, so you don’t have to build custom methods to add or remove methods to a delegate’s invocation list, C# provides the event 
// keyword. When the compiler processes the event keyword, you are automatically provided with registration and unregistration methods, as 
// well as any necessary member variables for your delegate types. These delegate member variables are always declared private, and,
// therefore, they are not directly exposed from the object firing the event. To be sure, the event keyword can be used to simplify how a 
// custom class sends out notifications to external objects.

// Defining an event is a two-step process. First, you need to define a delegate type (or reuse an existing one) that will hold the list of 
// methods to be called when the event is fired. Next, you declare an event (using the C# event keyword) in terms of the related delegate type.

// When the compiler processes the C# event keyword, it generates two hidden methods, one having an add_ prefix and the other having a 
// remove_ prefix. Each prefix is followed by the name of the C# event. For example, the Exploded event results in two hidden methods named 
// add_Exploded() and remove_Exploded(). They call Delegate.Combine() & Delegate.Remove Respectively

// When you want to register with an event, follow the pattern shown here:
// NameOfObject.NameOfEvent += new RelatedDelegate(functionToCall);


using System;

namespace Experiment {
    public class Car {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool isDead;

        public delegate void CarEngineHandler(string message);

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
                    Exploded("Sorry! your car is dead...");
                }
            } else {
                
                CurrentSpeed += delta;
                
                if ((MaxSpeed - CurrentSpeed) < 10 && AboutToBlow != null) {
                    // NOTIFY
                    AboutToBlow("Careful Buddy! Gonna Blow!");
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

        static void c_AboutToBlow(string message) {
            ConsoleColor c = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = c;
        }

        public static void CarAboutToBlow(string message) {
            Console.WriteLine("************ CRITICAL ALERT ************");
            Console.WriteLine(message);
        }

        public static void CarIsDoomed(string message) {
            Console.WriteLine(message);
        }


    }
}