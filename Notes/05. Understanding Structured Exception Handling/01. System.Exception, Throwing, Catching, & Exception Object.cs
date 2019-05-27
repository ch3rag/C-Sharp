// EXCEPTION HANDLING INTRO AND System.Exception

// Core Members of the System.Exception Type
// Data 
// This read-only property retrieves a collection of key-value pairs (represented by an object implementing IDictionary) that provide
// additional, programmer-defined information about the exception. By default, this collection is empty.

// HelpLink 
// This property gets or sets a URL to a help file or web site describing the error in full detail.

// InnerException
// This read-only property can be used to obtain information about the previous exceptions that caused the current exception to occur. The
// previous exceptions are recorded by passing them into the constructor of the most current exception.

// Message 
// This read-only property returns the textual description of a given error. The error message itself is set as a constructor parameter.

// Source 
// This property gets or sets the name of the assembly, or the object, that threw the current exception.

// StackTrace 
// This read-only property contains a string that identifies the sequence of calls that triggered the exception. 
// This property is useful during debugging or if you want to dump the error to an external error log.

// TargetSite 
// This read-only property returns a MethodBase (System.Reflection.MethodBase) object, which describes numerous details about the method 
// that threw the exception (invoking ToString() will identify the method by name).

using System;

namespace Experiment {

    public class Radio {
        public void TurnOn(bool isOn) {
            Console.WriteLine(isOn? "Jamming" : "Quiet Time");
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

                    Exception myException = new Exception(String.Format("{0} has overheated!", PetName));
                   // TO PROVIDE HELP LINK, SPECIFY IT BEFORE THROWING
                    myException.HelpLink = "www.LearnToDrive.com";

                    // PROVIDING ADDITONAL INFORMATION IN DATA(IDictionary Object)
                    myException.Data.Add("Time Stamp", String.Format("{0} exploded at {1}", PetName, DateTime.Now));
                    myException.Data.Add("Cause", "Engine Overheating");

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
            } catch (Exception ex) {
                Console.WriteLine("*** ERROR ***");
                Console.WriteLine();

                // TARGET SITE
                Console.WriteLine("Method: {0}", ex.TargetSite);
                Console.WriteLine("Defining Class: {0}", ex.TargetSite.DeclaringType);
                Console.WriteLine("Member Type: {0}", ex.TargetSite.MemberType);
                Console.WriteLine();
                
                // HELP LINK
                Console.WriteLine("Help Link: {0}", ex.HelpLink);
                Console.WriteLine();
               
                // DATA
                foreach (System.Collections.DictionaryEntry de in ex.Data) {
                    Console.WriteLine("{0} -> {1}", de.Key, de.Value);
                }
                Console.WriteLine();

                Console.WriteLine("Message: {0}", ex.Message);
                Console.WriteLine("Source: {0}", ex.Source);

                // STACK TRACE
                Console.WriteLine();
                Console.WriteLine("Stack : {0}", ex.StackTrace);

            }

            Console.ReadKey();
        }
    }
}
 