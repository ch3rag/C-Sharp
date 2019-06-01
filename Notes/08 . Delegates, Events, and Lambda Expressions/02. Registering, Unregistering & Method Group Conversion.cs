//  Use delegates to define a Car class that has the ability to inform external entities about its current engine state:

// 1. Define a new delegate type that will be used to send notifications to the caller.
// 2. Declare a member variable of this delegate in the Car class.
// 3. Create a helper function on the Car that allows the caller to specify the method to call back on.
// 4. Implement the Accelerate() method to invoke the delegate’s invocation list under the correct circumstances.

using System;

namespace Experiment {

    public class Car {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool isDead;

        public Car() { }

        public Car(string name, int maxSpeed, int currentSpeed) {
            this.PetName = name;
            this.MaxSpeed = maxSpeed;
            this.CurrentSpeed = currentSpeed;
        }

        // Step I
        public delegate void CarEngineHandler(string messageForCaller);

        // Step II
        private CarEngineHandler listOfHandlers;

        // Step III
        public void RegisterWithCarEngine(CarEngineHandler handler) {
            listOfHandlers += handler;

            // Or long winded

            // if (listOfHandlers == null) {
            //     listOfHandlers = handler;
            // } else {
            //     listOfHandlers = CarEngineHandler.Combine(listOfHandlers, handler) as CarEngineHandler;
            // }
        }

        // Step IV
        public void Accelerate(int delta) {
            if (isDead) {
                if (listOfHandlers != null) {
                    listOfHandlers("Sorry Car Is Dead!");
                }
            } else {
                CurrentSpeed += delta;
                if ((MaxSpeed - CurrentSpeed) < 10 && listOfHandlers != null) {
                    listOfHandlers("Calm the fuck down! Engines gonna blow!");
                }

                if (CurrentSpeed > MaxSpeed) {
                    isDead = true;
                } else {
                    Console.WriteLine("Current Speed: {0}", CurrentSpeed);
                }
            }
        }

        public void UnregisterWithCarEngine(CarEngineHandler handler) {
            listOfHandlers -= handler;
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Car c = new Car("Zippy", 100, 20);

            // Car.CarEngineHandler handlerOne = new Car.CarEngineHandler(OnCarEngineEvent);
            // Car.CarEngineHandler handlerTwo = new Car.CarEngineHandler(OnCarEngineEventTwo);

            // c.RegisterWithCarEngine(handlerOne);
            // c.RegisterWithCarEngine(handlerTwo);

            // Above Step Can Be Simplified Using Method Group Conversion
            // C# provides a shortcut termed method group conversion. This feature allows you to supply a direct method name, rather than a 
            // delegate object, when calling methods that take delegates as arguments.

            c.RegisterWithCarEngine(OnCarEngineEvent);
            c.RegisterWithCarEngine(OnCarEngineEventTwo);



            for (int i = 0; i < 15; i++) {
                c.Accelerate(5);
            }

            // Unregister
            c.UnregisterWithCarEngine(OnCarEngineEventTwo);

            for (int i = 0; i < 5; i++) {
                c.Accelerate(5);
            }


            Console.ReadKey();
        }

        public static void OnCarEngineEvent(string message) {
            Console.WriteLine("Message From Car:" + message);
        }

        public static void OnCarEngineEventTwo(string message) {
            Console.WriteLine(message.ToUpper());
        }

    }
}