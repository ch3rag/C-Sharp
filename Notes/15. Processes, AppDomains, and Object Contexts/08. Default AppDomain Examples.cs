// AppDomains Example

using System;
using System.Diagnostics;
using System.Reflection;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            InitDefaultAppDomain();
            DisplayDefaultAppDomainStats();
            ListAllAssembliesInAppDomain();

            AppDomain current = AppDomain.CurrentDomain;
            current.Load("CarLibrary");

            Console.ReadKey();
        }


        public static void DisplayDefaultAppDomainStats() {
            // get the appdomain for the current thread
            AppDomain current = AppDomain.CurrentDomain;


            // print various stats
            Console.WriteLine("Name of this domain: {0}", current.FriendlyName);
            Console.WriteLine("ID of domain in this process: {0}", current.Id);
            Console.WriteLine("Is this default domain: {0}", current.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", current.BaseDirectory);
        }

        public static void ListAllAssembliesInAppDomain() {
            AppDomain current = AppDomain.CurrentDomain;

            Assembly[] assemblies = current.GetAssemblies();

            Console.WriteLine("List of assemblies loaded in {0}:", current.FriendlyName);

            foreach (Assembly asm in assemblies) {
                Console.WriteLine("Name: {0}\nVersion:{1}\n", asm.GetName().Name, asm.GetName().Version);
            }
        }

        public static void InitDefaultAppDomain() {
            AppDomain current = AppDomain.CurrentDomain;

            current.AssemblyLoad += (obj, args) => {
                Console.WriteLine("{0} has been loaded.", args.LoadedAssembly);
            };
        }


    }
}