// IMPLICIT "VAR"IABLES DECLARATION

using System;

namespace CheckingOverflows {
    class Program {
        public static void Main(String[] args) {
            var num = 12;
            var test = true;
            var name = "Chirag";

            // DETERMINING THEIR TYPES VIA REFLECTION

            Console.WriteLine("Type of num: {0}", num.GetType().Name);      // Int32
            Console.WriteLine("Type of test: {0}", test.GetType().Name);    // Boolean
            Console.WriteLine("Type of name: {0}", name.GetType().Name);    // String

            Console.ReadKey();
        }
    }
}