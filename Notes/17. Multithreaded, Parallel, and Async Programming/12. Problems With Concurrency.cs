// Problems With Concurrency

using System;
using System.Threading;



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
    public class Printer {
        public void PrintNumbers() {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            Console.WriteLine("Your Numbers:");
            for (int i = 0; i < 10; i++) {
                Random r = new Random();
                Thread.Sleep(1000 * r.Next(5));
                Console.Write("{0}, ", i);
            }
        }
    }
}