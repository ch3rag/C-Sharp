// Synchronization Using the [Synchronization] Attribute

using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Experiment {
    public class Program {
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

    [Synchronization]
    public class Printer : ContextBoundObject {
        public void PrintNumbers() {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            Console.WriteLine("Your Numbers:");
            for (int i = 0; i < 10; i++) {
                Random r = new Random();
                Thread.Sleep(500 * r.Next(1, 2));
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}