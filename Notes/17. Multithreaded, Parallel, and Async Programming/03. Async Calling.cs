// System.Threading
using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace Experiment {
    public delegate int BinaryOp(int x, int y);
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Main invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp myAddOp = new BinaryOp(Add);

            // compute result on secondary thread
            IAsyncResult ar = myAddOp.BeginInvoke(10, 5, null, null);

            // do work until the secondary thread is completed
            while (!ar.IsCompleted) {
                Console.WriteLine("Doing more work in Main()");
                Thread.Sleep(1000);
            }

            // obtain the result
            int result = myAddOp.EndInvoke(ar);
            Console.WriteLine("Here's the result: {0}", result);

            // using WaitOne()
            // WaitOne() blocks the current thread for set amount of time
            // if the async call completes within wait time true is returned else false
            ar = myAddOp.BeginInvoke(20, 40, null, null);

            while (!ar.AsyncWaitHandle.WaitOne(1000, true)) {
                Console.WriteLine("Doing more work in Main()");
            }
            result = myAddOp.EndInvoke(ar);
            Console.WriteLine("Here's the result: {0}", result);

            Console.ReadKey();
        }

        public static int Add(int a, int b) {
            Console.WriteLine("Add invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return a + b;
        }
    }

}