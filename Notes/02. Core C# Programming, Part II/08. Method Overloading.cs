// METHOD OVERLOADING

using System;
namespace Notes {
    class Program {
        public static void Main(string[] args) {
            int a = 10, b = 20;
            double p = 6.89, q = 21.45664;
            byte x = 200, y = 100;

            Console.WriteLine(Add(a, b));
            Console.WriteLine(Add(p, q));
            Console.WriteLine(Add(x, y));
            Console.ReadKey();
        }

        static int Add(int x, int y) {
            return x + y;
        }

        static double Add(double x, double y) {
            return x + y;
        }

        static byte Add(byte x, byte y) {
            byte sum;
            try {
                sum = checked((byte)(x + y));
            } catch (ArithmeticException e) {
                Console.WriteLine("OVERFLOW!!");
                sum = 0;
            }
             return sum;
        }
    }
}