

using System;
using System.Threading;

namespace Experiment {
    public delegate int Adder(int x, int y);

    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Executing Main() On Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Adder myadder = new Adder(Add);
            IAsyncResult result = myadder.BeginInvoke(10, 50, null, null);
            Console.WriteLine("Doing More Work In Main().");

            // block until the EndInvoke completes
            int sum = myadder.EndInvoke(result);
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine("Exiting Main()");
            Console.ReadKey();
        }

        public static int Add(int x, int y) {
            Console.WriteLine("Executing Add() On Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }
    }
}