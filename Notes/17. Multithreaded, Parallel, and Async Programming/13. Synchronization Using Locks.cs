// Lock keyword allows you to define a scope of statements that must be synchronized between threads.
// lock keyword requires you to specify a token (an object reference) that must be acquired by a thread to enter within the lock 
// scope. When you are attempting to lock down a private instance-level method, you can simply pass in a reference to the current 
// type(this) (As the outside objects can't access the method using "this" object).However, if you are locking down a region of code 
// within a public member, it is safer to declare a private object member variable to serve as the lock token. If you are attempting 
// to lock down code in a static method, simply declare a private static object member variable to serve as the lock token.

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
        private object threadLock = new Object();

        public void PrintNumbers() {
            lock (threadLock) {
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
}