using System;
using System.Threading;

namespace Experiment {
    public class Program {

        private static readonly object threadLock = new Object();
        public static void Main(string[] args) {
            Thread.CurrentThread.Name = "PrimaryThread";
            Console.WriteLine("Main Executing On Thread: {0}", Thread.CurrentThread.Name);

            for (int i = 0; i < 10; i++) {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Printer));
            }

            Console.ReadKey();
        }

        public static void Printer(object state) {
            lock (threadLock) {
                Console.WriteLine("Printer Started On Thread: {0}", Thread.CurrentThread.Name);
                for (int i = 0; i < 10; i++) {
                    Console.Write(i + ", ");
                    Thread.Sleep(1000);
                }
                Console.WriteLine();
            }
        }
    }
}
