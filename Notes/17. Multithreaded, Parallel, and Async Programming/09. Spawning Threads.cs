// Manually Creating Secondary Threads

// 1. Create a method to be the entry point for the new thread.

// 2. Create a new ParameterizedThreadStart (or ThreadStart) delegate, passing the address of the method defined in step 1 to the 
// constructor.

// 3. Create a Thread object, passing the ParameterizedThreadStart/ThreadStart
// delegate as a constructor argument.

// 4. Establish any initial thread characteristics (name, priority, etc.).

// 5. Call the Thread.Start() method. This starts the thread at the method referenced by the delegate created in step 2 as soon as 
// possible.


using System;
using System.Threading;
using System.Windows.Forms;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Console.Write("Do you want [1] or [2] threads?: ");
            string threadCount = Console.ReadLine();


            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary Thread";

            // display thread info
            Console.WriteLine("{0} is executing Main()", Thread.CurrentThread.Name);

            // make worker class
            Printer p = new Printer();

            switch (threadCount) {
                case "1":
                    p.PrintNumbers();
                    break;
                case "2":
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary Thread";
                    backgroundThread.Start();
                    break;
                default:
                    Console.WriteLine("Invalid input. Running on single thread...");
                    goto case "1";
            }
            MessageBox.Show("I'm Busy", "Work on main thread..");
            Console.ReadKey();
        }
    }

    public class Printer {
        // step 1
        public void PrintNumbers() {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            Console.WriteLine("Your Numbers: ");
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("{0}", i);
                Thread.Sleep(2000);
            }
        }
    }
}