// Anonymous Delegate Functions

// An anonymous method cannot access ref or out parameters of the defining method.

// An anonymous method cannot have a local variable with the same name as a local variable in the outer method.

// An anonymous method can access instance variables (or static variables, as appropriate) in the outer class scope.

// An anonymous method can declare local variables with the same name as outer class member variables (the local 
// variables have a distinct scope and hide the outer class member variables).

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