// Synchronization Using the System.Threading.Interlocked Type
// Allows you to operate on a single point of data atomically with less overhead than with the Monitor type. 

// CompareExchange()            Safely tests two values for equality and, if equal, exchanges one of the values with a third
// Decrement()                  Safely decrements a value by 1
// Exchange()                   Safely swaps two values
// Increment()                  Safely increments a value by 1


using System;
using System.Threading;



namespace Experiment {
    public class Program {
        int myVal = 0;

        public void SafeIncreament() {
            int newVal = Interlocked.Increment(ref myVal);
        }

        public void SafeAssignment(int x) {
            Interlocked.Exchange(ref myVal, x);
        }

        public void SafeCompareAndExchange(int compare, int assign) {
            // if myVal == compare then myVal = assign
            Interlocked.CompareExchange(ref myVal, assign, compare);
        }

        public static void Main(string[] args) {
            Console.ReadKey();
        }
    }
}