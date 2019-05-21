// EXPRESSION BODIED FUNCTION

using System;
namespace Notes {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine(Add(2, 4));
        }

        static int Add(int x, int y) => x + y;
    }
}