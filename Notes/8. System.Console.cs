// SYSTEM.CONSOLE

using System;

namespace MyConsole {
    class Program {

        public static int Main(string[] args) {
            // BEEP
            Console.Beep(1000, 1200);

            // BACKGROUND COLOR
            Console.BackgroundColor = ConsoleColor.Yellow;

            // FOREGROUND COLOR
            Console.ForegroundColor = ConsoleColor.Red;

            // BUFFER HEIGHT & WIDTH
            Console.BufferHeight = 300;
            Console.BufferWidth = 120;

            // TITLE
            Console.Title = "ConsoleApp";

            // TOP LEFT POSITION OF CONSOLE WINDOW
            Console.WindowLeft = 1;
            Console.WindowTop = 1;

            Console.WriteLine("Hello World");
            
            // HEIGHT AND WIDTH OF THE CONSOLE WINDOW
            Console.WindowHeight = 40;
            Console.WindowWidth = 80;

            Console.ReadKey();

            // CLEARS  THE CONSOLE BUFFER
            Console.Clear();
            return 0;
        }
    }
}
