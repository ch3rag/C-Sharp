// Thread-safe, way to force a thread to wait until another is completed is to use the AutoResetEvent class. In the thread that 
// needs to wait (such as a Main() method), create an instance of this class and pass in false to the constructor to signify you
// have not yet been notified. Then, at the point at which you are willing to wait, call the WaitOne() method. 


using System;
using System.Threading;



namespace Experiment {
    public class Program {

        private static AutoResetEvent waitHandle = new AutoResetEvent(false);

        public static void Main(string[] args) {
            Console.WriteLine("ID of thread in Main() is: {0}", Thread.CurrentThread.ManagedThreadId);


            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(new AddParams(10, 20));

            // wait here until secondary thread is done
            Console.WriteLine("Waiting for the secondary thread to get completed.");
            waitHandle.WaitOne();
            Console.WriteLine("The other thread is done!");
            Console.ReadLine();
        }

        public static void Add(object data) {
            if (data is AddParams) {
                Thread.Sleep(2000);
                Console.WriteLine("ID of thread in Add() is: {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams adder = data as AddParams;
                Console.WriteLine("{0} + {1} = {2}", adder.a, adder.b, adder.a + adder.b);
            }
            waitHandle.Set();
        }
    }

    public class AddParams {
        public int a, b;

        public AddParams(int a, int b) {
            this.a = a;
            this.b = b;
        }
    }


}