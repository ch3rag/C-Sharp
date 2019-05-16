// BASIC IO WITH CONSOLE CLASS
using System;
namespace IODemo {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("********** BASIC CONSOLE IO **********");

            // GETTING USER DATA
            GetUserData();
            
            // FORMATTING NUMERICAL DATA
            Console.WriteLine("Value Of 99999 in various formats.");

            // Currency
            Console.WriteLine("c format: {0:c}", 99999);

            // DECIMAL NUMBERS 
            Console.WriteLine("d9 format: {0:d9}", 99999);

            // EXPONENT NOTATION
            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("E format: {0:E}", 99999);

            // FIXED-POINT FORMATTING
            Console.WriteLine("f3 format: {0:f3}", 99999);

            // NUMERICAL FORMATTING
            Console.WriteLine("n format: {0:n}", 99999);

            // HEXADECIMAL FORMAT
            Console.WriteLine("X format: {0:X}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);

            // STRING FORMATIING CAN ALSO BE DONE USING STRING.FORMAT

            string userMessage = string.Format("100000 in hex is {0:X}", 100000);
            System.Windows.Forms.MessageBox.Show(userMessage);
            Console.ReadLine();


        }

        public static void GetUserData() {
            Console.WriteLine("Please Enter Your Name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Please Enter Your Age: ");
            string userAge = Console.ReadLine();

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Hello {0}! You are {1} years old.", userName, userAge);

            Console.ForegroundColor = prevColor;
        }
    }
}