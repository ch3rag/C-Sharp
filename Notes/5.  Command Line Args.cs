// ARRAY ARE OF TYPE System.Array

using System;
namespace CLA {
    class Program {
        public static int Main(string[] args) {
            if (args.Length < 1) {
                Console.WriteLine("Please Pass Your Name As Command Line Argument!!");
            } else {
                Console.WriteLine("Hello, " + args[0] + "!");

                // ACCESSING ARGUMENTS VIA FOREACH LOOP

                foreach (string arg in args) {
                    Console.WriteLine(arg);
                }

                // IF MAIN DOES NOT ACCEPT ARGS AS PARAMETERS
                // WE CAN USE GetCommandLineArgs() STATIC FUNCTION ON System.Environment

                string[] args2 = System.Environment.GetCommandLineArgs();

                Console.WriteLine("Application Name: " + args2[0]);

                for (int i = 0; i < args2.Length; i++) {
                    Console.WriteLine("Args[" + i + "]: " + args2[i]);
                }
            }
            Console.ReadKey();
            return 0;
        }
    }
}