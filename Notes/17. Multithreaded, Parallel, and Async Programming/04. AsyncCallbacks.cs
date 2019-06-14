// System.Threading
using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace Experiment {

    public delegate int BinaryOp(int x, int y);
    public class Program {
        private static bool isDone = false;
        public static void Main(string[] args) {
            Console.WriteLine("Main invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp myAddOp = new BinaryOp(Add);

            // compute result on secondary thread
            IAsyncResult ar = myAddOp.BeginInvoke(10, 5, new AsyncCallback(OnAddComplete), null);

            // do work until the secondary thread is completed
            while (!isDone) {
                Console.WriteLine("Doing more work in Main()");
                Thread.Sleep(1000);
            }

            // obtain the result
            int result = myAddOp.EndInvoke(ar);
            Console.WriteLine("Here's the result: {0}", result);

            Console.ReadKey();
        }

        public static void OnAddComplete(IAsyncResult iar) {
            Console.WriteLine("OnAddComplete() invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            isDone = true;
        }

        public static int Add(int a, int b) {
            Console.WriteLine("Add invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return a + b;
        }
    }

}