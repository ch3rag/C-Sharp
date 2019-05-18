// SYSTEM.OBJECT PROPERTIES

using System;
namespace VariableDeclaration {
    class Program {
        public static void Main(string[] args) {
            Console.WriteLine("12.GetHashCode(): {0}", 12.GetHashCode());
            Console.WriteLine("12.Equals(23): {0}", 12.Equals(23));
            Console.WriteLine("12.ToString(): {0}", 12.ToString());
            Console.WriteLine("12.GetType(): {0}", 12.GetType());
            Console.ReadLine();
        }
    }
}