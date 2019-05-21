// OPTIONAL ARGUMENTS & NAMED ARGUMENTS

// OPTIONAL ARGS =>
// THESE PARAMETERS MUST BE KNOWN AT THE COMPILE TIME
// OTHERWISE IT WILL GENERATE AN ERROR

// NAMED ARGS =>
// If you begin to invoke a method using positional parameters, you must list them before any named parameters

using System;
namespace Notes {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine(Increment(2));        // 3
            Console.WriteLine(Increment(5, 2));     // 7
            


            // NAMED ARGUMENTS

            DisplayConsoleMessage(message: "Welcome To C#", foregroundColor: ConsoleColor.Cyan, backgroundColor: ConsoleColor.DarkMagenta);

            // NAMED + POSITIONAL 

            DisplayConsoleMessage(ConsoleColor.DarkRed, message: "Welcome To Programming", foregroundColor: ConsoleColor.Gray);

            // OPTIONAL + NAMED
            DisplayConsoleMessageHybrid(message: "Welcome To Computer Science");
            Console.ReadKey();
        }

        static int Increment(int num, int offset = 1) {
            return num + offset;
        }

        // THIS WON'T WORK
        // BECAUSE DateTime.Now IS RESOLVED AT RUNTIME
        // static DateTime GetDifference(DateTime past, DateTime present = DateTime.Now) {
        //    // RETURN DIFFERENCE
        // }

        static void DisplayConsoleMessage(ConsoleColor backgroundColor, ConsoleColor foregroundColor, string message) {

            ConsoleColor oldBg = Console.BackgroundColor;
            ConsoleColor oldFg = Console.ForegroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldFg;
            Console.BackgroundColor = oldBg;
        }

        // OPTIONAL + NAMED
        static void DisplayConsoleMessageHybrid(ConsoleColor backgroundColor = ConsoleColor.White, ConsoleColor foregroundColor = ConsoleColor.DarkRed, string message = "TEST MESSAGE") {
            ConsoleColor oldBg = Console.BackgroundColor;
            ConsoleColor oldFg = Console.ForegroundColor;

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldFg;
            Console.BackgroundColor = oldBg;
        }
    }
}