// PASSING GENERIC PARAMS
using System;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            int[] myIntArray = { 10, -1, 2, -99, 0, 23, 77, 11 };

            Array.Sort<int>(myIntArray);

            foreach (int i in myIntArray) Console.WriteLine(i);
            Console.ReadKey();
        }
    }
}