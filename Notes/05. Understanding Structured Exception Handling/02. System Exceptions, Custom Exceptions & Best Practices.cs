// SYSTEM EXCEPTIONS
// Exceptions that are thrown by the .NET platform are (appropriately) called system exceptions. These exceptions are generally regarded as 
// nonrecoverable, fatal errors. System exceptions derive directly from a base class named System.SystemException, which in turn derives from 
// System.Exception (which derives from System.Object).

// APPLICATION EXCEPTIONS
// Given that all .NET exceptions are class types, you are free to create your own application-specific exceptions. However, because the 
// System.SystemException base class represents exceptions thrown from the CLR, you might naturally assume that you should derive your custom 
// exceptions from the System.Exception type. You could do this, but you could instead derive from the System.ApplicationException class.

// CREATING CUSTOM EXCEPTIONS
// The Best Practice Includes: 
// •	 Derives from Exception/ApplicationException                            [X]
// •	 Is marked with the [System.Serializable] attribute                     [X]
// •	 Defines a default constructor                                          [X]
// •	 Defines a constructor that sets the inherited Message property         [X]
// •	 Defines a constructor to handle “inner exceptions”                     [X]
// •	 Defines a constructor to handle the serialization of your type         [X]


using System;

namespace Experiment {

    [Serializable]
    public class CarIsDeadException : ApplicationException {

        public DateTime ErrorTimeStamp { get; set; }
        public string Cause { get; set; }

        public CarIsDeadException() { }
        
        public CarIsDeadException(string message) : base(message) { }
        
        public CarIsDeadException(string message, Exception innerEx) : base(message, innerEx) { }

        public CarIsDeadException(string message, string cause, DateTime time) : base(message) {
            this.Cause = cause;
            this.ErrorTimeStamp = time;
        }

        protected CarIsDeadException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) :
                base(info, context) { }
    }

    // THE ABOVE CLASS CAN BE GENERATED THROUGH exception SNIPPET
    
    public class Radio {
        public void TurnOn(bool isOn) {
            Console.WriteLine(isOn ? "Jamming" : "Quiet Time");
        }
    }

    public class Car {

        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        private bool isDead;

        private Radio MusicBox = new Radio();

        public Car() { }
        public Car(string name, int speed) {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state) {
            MusicBox.TurnOn(state);
        }

        public void Accelerate(int del) {
            if (isDead) {
                Console.WriteLine("{0} is out of order..", PetName);
            } else {
                CurrentSpeed += del;
                if (CurrentSpeed > MaxSpeed) {
                    CurrentSpeed = 0;
                    isDead = true;

                    CarIsDeadException myException = new CarIsDeadException(String.Format("{0} has overheated!", PetName), "Engine Overheating", DateTime.Now);
                    myException.HelpLink = "www.LearnToDrive.com";
                    throw myException;

                } else {
                    Console.WriteLine("Current Speed: {0}", CurrentSpeed);
                }
            }
        }

    }
    class Program {
        static void Main(string[] args) {
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try {
                for (int i = 0; i < 10; i++) {
                    myCar.Accelerate(10);
                }
            } catch (CarIsDeadException ex) {
                Console.WriteLine("*** ERROR ***");
                Console.WriteLine();

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErrorTimeStamp);
                Console.WriteLine(ex.Cause);

            }

            Console.ReadKey();
        }
    }
}
 