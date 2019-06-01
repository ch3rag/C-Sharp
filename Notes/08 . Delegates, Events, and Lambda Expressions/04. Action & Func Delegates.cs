// Action<> & Func<> Delegates

// By using seperate classes, you typically end up with a number of custom delegates that might never be used beyond the current task at hand.
// When you simply want “some delegate” that takes a set of arguments and possibly has a return value other than void. In these cases,
// you can use the framework’s built-in Action<> and Func<> delegate types.

using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Action<string, ConsoleColor, int> printer = new Action<string, ConsoleColor, int>(DisplayMessage);

            printer("Hello", ConsoleColor.Cyan, 10);

            Func<int, int, int> adder = new Func<int, int, int>(Add);
            Console.WriteLine(adder(10, 20));

            Func<int, int, string> concater = new Func<int, int, string>(ConcatIntegers);
            Console.WriteLine(concater(20, 20));
            
            Console.ReadKey();
        }

        static void DisplayMessage(string message, ConsoleColor textColor, int printCount) {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = textColor;

            for (int i = 0; i < printCount; i++) {
                Console.WriteLine(message);
            }

            Console.ForegroundColor = previous;
        }

        static int Add(int x, int y) {
            return x + y;
        }

        static string ConcatIntegers(int x, int y) {
            return x + "" + y; 
        }
    }
}