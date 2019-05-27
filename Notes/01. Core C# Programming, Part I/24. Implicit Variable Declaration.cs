// IMPLICIT "VAR"IABLES DECLARATION

using System;
using System.Linq;

namespace ImplicitVariables {
    class Program {
        // THIS IS NOT ALLOWED
        // private var env = "WINDOWS";

        public static void Main(String[] args) {
            var num = 12;
            var test = true;
            var name = "Chirag";

            // IMPLICIT TYPES MUST BE  GIVEN AN INITIAL VALUE
            // var age;

            // DETERMINING THEIR TYPES VIA REFLECTION

            Console.WriteLine("Type of num: {0}", num.GetType().Name);      // Int32
            Console.WriteLine("Type of test: {0}", test.GetType().Name);    // Boolean
            Console.WriteLine("Type of name: {0}", name.GetType().Name);    // String
            Console.WriteLine(Sum(1, 2));


            // VARS ARE EXTREMELY USEFUL IN LINQ QUERIES

            int[] numbers = { 10, 20, 30, 1, 2, 3, 4, 8 };

            // LINQ QUERY
            var subset = from i in numbers where i < 10 select i;
            foreach (var i in subset) {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            // REFLECTION TO DETERMINE DATATYPE OF SUBSET

            Console.WriteLine("Subset is a: {0}", subset.GetType().Name);
            Console.WriteLine("Subset is defined in: {0}", subset.GetType().Namespace);


            Console.ReadKey();

        }

        // THIS IS NOT ALLOWED
        // static var Sum(var a, var b) {
        //     return a + b;
        // }

        // THIS IS ALLOWED

        static int Sum(int a, int b) {
            var sum = a + b;
            return sum;
        }
    }
}