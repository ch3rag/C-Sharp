

using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Experiment {

    public delegate int Adder(int x, int y);

    public class Program {
        
        public static bool isDone = false;

        public static void Main(string[] args) {
            Console.WriteLine("Executing Main() On Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Adder myadder = new Adder(Add);
            myadder.BeginInvoke(10, 50, new AsyncCallback(AddComplete), "Optional Message From Main()");
            

            // wait ms and if completed return true else false
            while (!isDone) {
                Console.WriteLine("Doing More Work In Main().");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Exiting Main()");
            Console.ReadKey();
        }

        public static int Add(int x, int y) {
            Console.WriteLine("Executing Add() On Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        // a method that will inform me that the operation is completed
        public static void AddComplete(IAsyncResult result) {
            Console.WriteLine("Executinh AddComplete() On Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your Adddition Is Complete.");
            int sum = ((Adder)((AsyncResult)result).AsyncDelegate).EndInvoke(result);
            Console.WriteLine("Sum: {0}", sum);
            Console.WriteLine(result.AsyncState);
            isDone = true;
        }
    }
}