// ITERATION 3
// REMOVING PRIVATE HANDLER & CUSTOM REGISTERS USING EVENT KEYWORD

using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            MyClass obj = new MyClass();
            
            
            // obj.NumberEvent += new MyClass.NumberHandler(PrintMessage);
            // NO NEED TO CREATE NEW HANDLER JUST THROW THE FUNCTION IN
            obj.NumberEvent += PrintMessage;

            // COMPILER WILL DO NECESSARY COVERSION

            obj.CreateEvent(2);
            obj.CreateEvent(7);
            Console.ReadKey();
        }

        public static void PrintMessage(string message) {
            Console.WriteLine(message);
        }
    }

    public class MyClass {

        // A DELEGATE TYPE DEFINE SIGNATURE OF METHODS THAT A OBJECT OF THIS CAN POINT 
        // Params: String
        // Return: Void
        public delegate void NumberHandler(string message);

        // JUST CREATE A EVENT OF DELEGATE TYPE
        public event NumberHandler NumberEvent;
        

        public void CreateEvent(int number) {
            if (number % 2 == 0) {
                this.NumberEvent("Number Is Even");
            } else {
                this.NumberEvent("Number Is Odd");
            }
        }
    }
}