// PASSING AND RECEIVING ARRAYS FROM FUNCTIONS

using System;

namespace Notes {
    class Program {
        public static void Main(string[] args) {

            string[] cars = { "BMW", "AUDI", "BUGGATI", "FERRARI", "HONDA", "TOYOTA" };
            PrintArrayStr(cars, ", ");


            Console.WriteLine();
            PrintArrayInt(GetEvens(40), ", ");
            Console.ReadKey();
        }

        static void PrintArrayStr(string[] ar, string seperator) {
            foreach (string n in ar) {
                Console.Write(n + seperator);
            }
        }

        
        static void PrintArrayInt(int[] ar, string seperator) {
            foreach (int n in ar) {
                Console.Write(n + seperator);
            }
        }

        static int[] GetEvens(int length) {
            int[] evens = new int[length];
            for (int i = 0; i < length; i++) {
                evens[i] = (i + 1) * 2;
            }
            return evens;
        }
    }
}