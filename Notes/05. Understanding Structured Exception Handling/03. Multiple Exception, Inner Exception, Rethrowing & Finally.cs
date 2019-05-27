// MULTIPLE EXCEPTIONS, RETHOWING EXCEPTIONS, INNER EXCEPTIONS, FINALLY
using System;
using System.IO;

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
            if (del < 0) {
                throw new ArgumentOutOfRangeException("del", "Acceleration Must Be Positive");
            }
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

            // The rule of thumb to keep in mind is to make sure your catch blocks are structured such that the first
            // catch is the most specific exception (i.e., the most derived type in an exception-type inheritance chain),
            // leaving the final catch for the most general (i.e., the base class of a given exception inheritance chain, in this
            // case System.Exception)

            try {
                // for (int i = 0; i < 10; i++) {
                //     myCar.Accelerate(10);
                // }
                myCar.Accelerate(-10);
            } catch (CarIsDeadException ex) {
                Console.WriteLine(ex);
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            
            // C# ALSO SUPPORT GENERAL CATCH STATEMENTS
            try {
                int a = 10;
                int b = 0;
                int c = a / b;
            } catch {
                Console.WriteLine("Something bad happend...");
            }

            // RETHROWING EXCEPTIONS
            // AccelerateCar() Throws Exception Back To Caller
            try {
                AccelerateCar(myCar, 100);
            } catch (CarIsDeadException) {
                Console.WriteLine("Car Is Dead!");
            }

            // INNER EXCEPTIONS
            // It is entirely possible to trigger an exception at the time you are handling another exception
            // EXAMPLE: RECORDING STACK TRACE IN A FILE WHEN CATCH A CarIsDeadException
            myCar = new Car("Zippy", 20);
            try {
                AccelerateCarAndSaveToFile(myCar, 100);
            } catch (CarIsDeadException ex) {
                Console.WriteLine(ex.Message);
                // ACCESSING INNER EXCEPTION
                Console.WriteLine(ex.InnerException.Message);
            }

            // FINALLY BLOCK GETS EXECUTED NOT MATTER WHETHER EXCEPTION OCCURED OR NOT
            myCar = new Car("Zippy", 20);
            try {
                myCar.Accelerate(10);
            } catch (CarIsDeadException ex) {
                Console.WriteLine(ex.Message);
            } finally {
                Console.WriteLine("Turning Off Radio..");
                myCar.CrankTunes(false);
            }
            Console.ReadKey();
        }

        public static void AccelerateCar(Car myCar, int del) {
            try {
                myCar.Accelerate(del);
            } catch (CarIsDeadException) {
                Console.WriteLine("Can't Solve The Problem, Throwing It Back To My Caller!!");
                throw;
            } 
           

        }

        public static void AccelerateCarAndSaveToFile(Car myCar, int del) {
            try {
                AccelerateCar(myCar, 100);
            } catch (CarIsDeadException ex) {
                // When you encounter an exception while processing another exception, best practice states that you
                // should record the new exception object as an “inner exception” within a new object of the same type as the
                // initial exception.
                try {
                    FileStream fs = File.Open("C:\\Car_Errors.txt", FileMode.Open);
                } catch (FileNotFoundException fx) {
                    throw new CarIsDeadException(ex.Message, fx);
                }
            }
        }
    }
}
 