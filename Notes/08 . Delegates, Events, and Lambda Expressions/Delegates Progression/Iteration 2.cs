// ITERATION 2
// COMBINING USING OVERLOADED OPERATORS

using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            MyClass obj = new MyClass();
            obj.RegisterWithNumber(new MyClass.NumberHandler(PrintMessage));
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

        // A DELEGATE OBJECT IS REALLY WHAT THAT POINTS TO FUNCTION
        private NumberHandler handler;       // IT POINTS TO NO FUNCTION AT THIS MOMENT

        // A REGISTER FUNCTION SO THAT USER CAN REGISTER TO LISTEN TO EVENT RAISED BY NUMBER OBJECT
        // HOW IT CAN RECEIVE A METHOD THAT IS COMPATIBLE WITH NumberHandler SIGNATURE?
        // ANSWER IS RECEVING NumberHandler OBJECT
        public void RegisterWithNumber(NumberHandler handler) {
            // JUST COMBINE USING OVERLOADED OPERATOR += 
            this.handler += handler;
        }

        public void CreateEvent(int number) {
            if (number % 2 == 0) {
                this.handler("Number Is Even");
            } else {
                this.handler("Number Is Odd");
            }
        }
    }
}