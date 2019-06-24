using System;
using System.Threading;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            int a = 10;
            Interlocked.Increment(ref a);

            Console.WriteLine(a);       // 11

            Interlocked.Decrement(ref a);

            Console.WriteLine(a);       // 10


            Interlocked.Add(ref a, 20);

            Console.WriteLine(a);       // 30

            Interlocked.Add(ref a, -15);

            Console.WriteLine(a);       // 15

            Interlocked.CompareExchange(ref a, -10, 15);

            Console.WriteLine(a);       // -10

            Console.ReadKey();
        }
    }
}
