// PARSING VALUES FROM STRINGS

using System;

namespace ParsingStrings {
    class Program {
        public static void Main(String[] args) {
            int num = int.Parse("32");
            double d = double.Parse("8.76543");
            bool b = bool.Parse("True");
            char c = char.Parse("W");

            Console.WriteLine("{0}, {1}, {2}, {3}", num, d, b, c);

            // HOWEVER IT WILL THROW EXCEPTION IF VALUE FAILED TO PARSE 
            // SO IT IS BETTER TO USE TRYPARSE

            bool bOut;
            if(bool.TryParse("True", out bOut)) {
                Console.WriteLine("Success! Value is: {0}", bOut);
            } else {
                Console.WriteLine("Conversion Failed!");
            }

            int number;

            if(int.TryParse("3.14159", out number)) {
                Console.WriteLine("Success! Value is: {0}", number);
            } else {
                Console.WriteLine("Conversion Failed!");
            }

            Console.ReadKey();
        }
    }
}