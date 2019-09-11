// ITERATION 1
// BASICS

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

        // AN OBJECT OF THAT DELEGATE TYPE IS REALLY WHAT THAT POINTS TO FUNCTION
        private NumberHandler handler;       // IT POINTS TO NO FUNCTION AT THIS MOMENT

        // A REGISTER FUNCTION SO THAT USER CAN REGISTER TO LISTEN TO EVENT RAISED BY NUMBER OBJECT
        // HOW IT CAN RECEIVE A METHOD THAT IS COMPATIBLE WITH NumberHandler SIGNATURE?
        // ANSWER IS RECEVING NumberHandler OBJECT
        public void RegisterWithNumber(NumberHandler handler) {
            // handler ===> Reference To Method That User Wanna Called
            
            // We Can Combine Both The Handler Using Delegate.Combine

            if (this.handler == null) {
                // this.handle ==> null
                // JUST SET this.handler to passed handler
                this.handler = handler;
            } else {
                // Combine!!
                this.handler = Delegate.Combine(this.handler, handler) as NumberHandler;
            }
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