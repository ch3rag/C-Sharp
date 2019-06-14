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
            int result = myAddOp(5, 10);
            Console.WriteLine("Here's the result: {0}", result);
            Console.WriteLine("Doing more work in Main()");
            Console.ReadKey();
        }

        public static int Add(int a, int b) {
            Console.WriteLine("Add invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return a + b;
        }
    }

}