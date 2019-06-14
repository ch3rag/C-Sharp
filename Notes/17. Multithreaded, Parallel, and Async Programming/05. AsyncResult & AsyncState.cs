// System.Threading
using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Experiment {

    public delegate int BinaryOp(int x, int y);
    public class Program {
        private static bool isDone = false;
        public static void Main(string[] args) {
            Console.WriteLine("Main invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp myAddOp = new BinaryOp(Add);

            // compute result on secondary thread and send additional message to callback
            IAsyncResult ar = myAddOp.BeginInvoke(10, 5, new AsyncCallback(OnAddComplete), "Thanks for your great addition :)");

            // do work until the secondary thread is completed
            while (!isDone) {
                Console.WriteLine("Doing more work in Main()");
                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }

        public static void OnAddComplete(IAsyncResult iar) {
            // The incoming IAsyncResult parameter passed into the target of the AsyncCallback delegate is actually an instance of 
            // the AsyncResult class defined in the System.Runtime.Remoting.Messaging namespace. The AsyncDelegate property returns 
            // a reference to the original asynchronous delegate that was created elsewhere.

            Console.WriteLine("OnAddComplete() invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            // obtain the result

            AsyncResult ar = (AsyncResult)iar;
            BinaryOp myOp = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("Here's the result: {0}", myOp.EndInvoke(iar));

            // get additional message passed by caller
            string message = (string)iar.AsyncState;
            Console.WriteLine(message);
            isDone = true;
        }

        public static int Add(int a, int b) {
            Console.WriteLine("Add invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return a + b;
        }
    }

}