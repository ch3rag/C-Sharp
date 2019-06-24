using System;
using System.Threading;

namespace Experiment {
    public class Program {

        private static readonly object threadLock = new Object();
        public static void Main(string[] args) {
            Thread.CurrentThread.Name = "PrimaryThread";
            Console.WriteLine("Main Executing On Thread: {0}", Thread.CurrentThread.Name);
            Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++) {
                threads[i] = new Thread(new ThreadStart(Printer));
                threads[i].Name = "#" + i;
            }

            foreach (Thread thread in threads) {
                thread.Start();
            }

            Console.ReadKey();
        }

        public static void Printer() {
            Monitor.Enter(threadLock);
            try {
                Console.WriteLine("Printer Started On Thread: {0}", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++) {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
                Console.WriteLine();
            } finally {
                Monitor.Exit(threadLock);
            }
        }
    }
}
