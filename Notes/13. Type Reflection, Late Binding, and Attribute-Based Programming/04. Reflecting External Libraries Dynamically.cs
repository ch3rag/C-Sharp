// Dynamically Loading Assemblies

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace Experiment {
    public class Program {
        public static void DisplayTypesInAsm(Assembly asm) {
            PrintHeading("Types In Assembly", ConsoleColor.Cyan);
            Console.WriteLine("-> {0}", asm.FullName);
            (from type in asm.GetTypes() select type).ToList().ForEach(x => Console.WriteLine("Type: {0}", x));
            Console.WriteLine();

        }
        public static void Main(string[] AssemblyLoadEventArgs) {
            PrintHeading("External Assembly Viewer", ConsoleColor.Red);

            string asmName = "";
            Assembly asm = null;

            do {
                Console.Write("Enter name of Assembly(Quit to exit): ");

                asmName = Console.ReadLine();

                if (asmName.Equals("Quit", StringComparison.OrdinalIgnoreCase)) {
                    return;
                }
                try {
                    // Load Allows To Load Library Located In Application Directory
                    // asm = Assembly.Load(asmName);

                    // To load Asssemblies from arbitrary location use LoadFrom()
                    asm = Assembly.LoadFrom(asmName);
                    DisplayTypesInAsm(asm);
                } catch {
                    Console.WriteLine("Error!");
                }

            } while (true);
        }
        public static void PrintHeading(string heading, ConsoleColor color) {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine("********* " + heading + " *********");
            Console.ForegroundColor = temp;
        }
    }
}
