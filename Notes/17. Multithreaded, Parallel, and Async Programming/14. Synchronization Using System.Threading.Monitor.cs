// Synchronization Using the System.Threading.Monitor Type
// The C# lock statement is really just a shorthand notation for working with the System.Threading.Monitor class.
// If you use the Monitor type, you are able to instruct the active thread to wait for some duration of time (via the static 
// Monitor.Wait() method), inform waiting threads when the current thread is completed (via the static Monitor.Pulse() and 
// Monitor.PulseAll() methods), and so on.

using System;
using System.Threading;



namespace Experiment {
    public class Program {

        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args) {
            Printer p = new Printer();

            // create 10 threads
            Thread[] threads = new Thread[10];

            for (int i = 0; i < 10; i++) {
                threads[i] = new Thread(new ThreadStart(p.PrintNumbers)) {
                    Name = "Worker Thread: #" + i
                };
            }

            foreach (Thread t in threads) {
                t.Start();
            }

            Console.ReadKey();
        }
    }
    public class Printer {
        private object threadLock = new Object();

        public void PrintNumbers() {
            Monitor.Enter(threadLock);
            try {
                Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
                Console.WriteLine("Your Numbers:");
                for (int i = 0; i < 10; i++) {
                    Random r = new Random();
                    Thread.Sleep(500 * r.Next(1, 2));
                    Console.Write("{0}, ", i);
                }
                Console.WriteLine();

            } finally {
                Monitor.Exit(threadLock);
            }
        }
    }
}