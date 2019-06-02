// LAMDAS


using System;
using System.Collections.Generic;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            List<int> numbers = new List<int>() {
                1, 2, 4, 5, 6, 7, 12, 34, 565, 3, 324, 45
            };

            List<int> evens;

            // ITERATION 1:  USING SEPERATE METHOD
            evens = numbers.FindAll(isEven);

            // ITERATION 2: USING ANONYMOUS DELEGATE FUNCTIONS

            evens = numbers.FindAll(delegate(int n) {
                return n % 2 == 0;
            });

            // ITERTION 3: USING LAMBDAS!!
            evens = numbers.FindAll(x => x % 2 == 0);


            foreach (int n in evens) {
                Console.WriteLine(n);
            }

            Console.ReadKey();
        }

        public static bool isEven(int n) {
            return n % 2 == 0;
        }
    } 
}