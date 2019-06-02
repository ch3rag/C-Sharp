// ITERATION 5
// Anonymous Delegate Functions

using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            MyClass obj = new MyClass();


            // obj.NumberEvent += new EventHandler<NumberEventArgs>(PrintMessage);
            // NO NEED TO CREATE A SEPERATE FUNCTION, DECLARE IT ANONYMOUSLY
            obj.NumberEvent += delegate {
                Console.WriteLine("New Message Received!");
            };

            obj.NumberEvent += delegate(object source, NumberEventArgs e) {
                Console.WriteLine("{0} says: {1}", source, e.Message);
            };
            // COMPILER WILL DO NECESSARY COVERSION

            obj.CreateEvent(2);
            obj.CreateEvent(7);
            Console.ReadKey();
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
        // System Namespace has a built in generic type for this purpose
        // JUST CREATE A EVENT OF THAT DELEGATE TYPE
        public event EventHandler<NumberEventArgs> NumberEvent;
        

        public void CreateEvent(int number) {
            if (number % 2 == 0) {
                this.NumberEvent(this, new NumberEventArgs("Number Is Even"));
            } else {
                this.NumberEvent(this, new NumberEventArgs("Number Is Odd"));
            }
        }
    }
}