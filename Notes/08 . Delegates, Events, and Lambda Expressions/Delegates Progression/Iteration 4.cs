// ITERATION 4
// COMPLYING TO MS EVENTS

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

        public static void PrintMessage(object source, NumberEventArgs e) {
            Console.WriteLine("{0} says: {1}", source, e.Message);
        }
    }

    public class NumberEventArgs : EventArgs {
        public readonly string Message;
        public NumberEventArgs(string args) {
            this.Message = args;
        }
    }

    public class MyClass {

        // A DELEGATE TYPE DEFINE SIGNATURE OF METHODS THAT A OBJECT OF THIS CAN POINT 
        // COMPLYING TO MS EVENT
        // params: Object, EventArgs
        // return: void
        public delegate void NumberHandler(Object source, NumberEventArgs e);

        // JUST CREATE A EVENT OF DELEGATE TYPE
        public event NumberHandler NumberEvent;
        

        public void CreateEvent(int number) {
            if (number % 2 == 0) {
                this.NumberEvent(this, new NumberEventArgs("Number Is Even"));
            } else {
                this.NumberEvent(this, new NumberEventArgs("Number Is Odd"));
            }
        }
    }
}