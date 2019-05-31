// Creating Custom Generic Methods

using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            int a = 1, b = 2;
            Swap<int>(ref a, ref b);
            Console.WriteLine(a + " " + b);
            
            string m = "Hello", n = "World!";
            Swap<string>(ref m, ref n);
            Console.WriteLine(m + " " + n);
            
            Console.ReadKey();
        }
        
        public static void Swap<T>(ref T a, ref T b) {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}