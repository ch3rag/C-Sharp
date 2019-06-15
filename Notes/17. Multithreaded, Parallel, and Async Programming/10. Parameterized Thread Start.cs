
// Parameterized Thread Start

using System;
using System.Threading;



namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("ID of thread in Main() is: {0}", Thread.CurrentThread.ManagedThreadId);


            Thread thread = new Thread(new ParameterizedThreadStart(Add));
            thread.Start(new AddParams(10, 20));


            Console.ReadLine();
        }

        public static void Add(object data) {
            if (data is AddParams) {
                Thread.Sleep(2000);
                Console.WriteLine("ID of thread in Add() is: {0}", Thread.CurrentThread.ManagedThreadId);
                AddParams adder = data as AddParams;
                Console.WriteLine("{0} + {1} = {2}", adder.a, adder.b, adder.a + adder.b);
            }
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