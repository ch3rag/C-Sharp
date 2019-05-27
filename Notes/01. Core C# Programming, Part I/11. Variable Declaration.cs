// VARIABLE DECLARATION
using System;
namespace VariableDeclaration {
    class Program {
        public static void Main(string[] args) {
            // C# 7.1 FEATURE TO INITIALIZE VALUES TO THEIR DEFAULT VALUES
            // int i = default;

            // SINCE ALL DATATYPES ARE OBJECT THEY CAN BE INITIALIZED USING NEW OPERATOR

            bool b = new System.Boolean();
            int i = new System.Int32();
            double d = new System.Double();
            DateTime dt = new DateTime();

            Console.WriteLine("{0}, {1}, {2}, {3}", b, i, d, dt);
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}