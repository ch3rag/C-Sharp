// Custom App Domains

using System;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            AppDomain current = AppDomain.CurrentDomain;
            ListAllAssembliesInAppDomain(current);
            // make a new app domain
            MakeNewAppDomain();
            Console.ReadKey();
        }

        public static void ListAllAssembliesInAppDomain(AppDomain domain) {

            Assembly[] assemblies = domain.GetAssemblies();

            Console.WriteLine("List of assemblies loaded in {0}:", domain.FriendlyName);

            foreach (Assembly asm in assemblies) {
                Console.WriteLine("Name: {0}\nVersion:{1}\n", asm.GetName().Name, asm.GetName().Version);
            }
        }

        public static void MakeNewAppDomain() {
            AppDomain newDomain = AppDomain.CreateDomain("SecondAppDomain");

            try {
                newDomain.Load("CarLibrary");
            } catch (FileLoadException ex) {
                Console.WriteLine(ex);
            }
            ListAllAssembliesInAppDomain(newDomain);

        }
    }
}