// CLR ThreadPool
// Pool of worker threads that is maintained by the runtime. We can use it to queue method calls    

using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Printer p = new Printer();
            // queue 10 method class PrintNumbers()
            for (int i = 0; i < 10; i++) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(PrintTheNumbers), p);
            }
            // ThreadPool threads are background thread so if Console.ReadKey() is removed the program will exit immediately
            Console.ReadKey();
        }

        public static void PrintTheNumbers(object state) {
            Printer printer = state as Printer;
            printer.PrintNumbers();
        }
    }

    [Synchronization]
    public class Printer : ContextBoundObject {
        public void PrintNumbers() {
            for (int i = 0; i < 10; i++) {
                Thread.Sleep(100);
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}