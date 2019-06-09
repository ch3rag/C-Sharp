// Reflecting Shared Assemblies

// One variation of Assembly.Load() allows you to specify a culture value, as well as a version number and public key token value.
// The set of items identifying an assembly is termed the display name. The format of a display name is a comma-delimited string of 
// name-value pairs that begins with the friendly name of the assembly, followed by optional qualifiers (in any order). 
// Name (,Version = major.minor.build.revision) (,Culture = culture token) (,PublicKeyToken= public key token)

// PublicKeyToken=null indicates that binding and matching against a nonstrongly named assembly is required. Culture="" indicates 
// matching against the default culture of the target machine. Example:
// Load version 1.0.0.0 of CarLibrary using the default culture.

// Assembly a = Assembly.Load(@"CarLibrary, Version=1.0.0.0, PublicKeyToken=null, Culture=""");

// System.Reflection namespace has the AssemblyName type, which allows you to represent the this string information in an object.

using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Experiment {
    public class Program {
        public static void DisplayTypesInAsm(Assembly asm) {
            PrintHeading("Types In Assembly", ConsoleColor.Cyan);
            Console.WriteLine("-> {0}", asm.FullName);
            (from type in asm.GetTypes() select type).ToList().ForEach(x => Console.WriteLine("Type: {0}", x));
            Console.WriteLine();
        }

        public static void DisplayEnumInSharedAssembly(Assembly asm) {
            PrintHeading("Information About Shared Assembly", ConsoleColor.Red);
            Console.WriteLine("Is Loaded From GAC?: {0}", asm.GlobalAssemblyCache);
            Console.WriteLine("Assembly Name: {0}", asm.GetName().Name);
            Console.WriteLine("Assembly Version: {0}", asm.GetName().Version);
            Console.WriteLine("Assembly Culture: {0}", asm.GetName().CultureInfo.DisplayName);

            // ENUMS

            (from type in asm.GetTypes() where type.IsEnum && type.IsPublic select type).ToList().ForEach(x => Console.WriteLine(x));

        }

        public static void Main(string[] AssemblyLoadEventArgs) {
            PrintHeading("Shared Assembly Viewer", ConsoleColor.Red);

            // First I'll demonstrate how to load non-shared library using AssemblyName and Display Name
            string dispName = @"CarLibrary, Version=2.0.0.0, PublicKeyToken=null, Culture=""";
            try {
                Assembly asm = Assembly.Load(dispName);

                DisplayTypesInAsm(asm);
            } catch {
                Console.WriteLine("Error!");
            }

            // Loading A Shared Library
            try {
                dispName = @"System.Windows.Forms, Version=4.0.0.0, PublicKeyToken=B77A5C561934E089, Culture=""";
                Assembly asm = Assembly.Load(dispName);
                DisplayEnumInSharedAssembly(asm);
            } catch {
                Console.WriteLine("Error!");
            }
            Console.ReadKey();
        }
        public static void PrintHeading(string heading, ConsoleColor color) {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine("********* " + heading + " *********");
            Console.ForegroundColor = temp;
        }
    }
}
