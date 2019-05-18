using System;
// CONSOLE APP EXAMPLE 
namespace FirstConsoleApp {
    class Program {
        public static void Main(string[] args) {
            Console.Title = "My First Console App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*******************************************");
            Console.WriteLine("*********Welcome To My Rocking App*********");
            Console.WriteLine("*******************************************");
            // WAIT FOR THE KEYPRESS
            Console.ReadKey();
        }
    }
}