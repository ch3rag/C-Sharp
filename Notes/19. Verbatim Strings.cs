// VERBATIM STRINGS 


using System;

namespace Strings {
    class Program {
        public static void Main(String[] args) {
            string path = @"C:\PROGRAM FILES\ADOBE\";

            string multiLine = @"
            very
                very
                    very
                        very
                            very
                                very
                                    very
                                        long string";
            string quotes = @"THIS A ""QUOTE""";

            Console.WriteLine(path);
            Console.WriteLine(multiLine);
            Console.WriteLine(quotes);

            Console.ReadKey();

        }
    }
}