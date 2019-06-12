// Unloading App Domains
// It is important to point out that the CLR does not permit unloading individual .NET assemblies. However, using the 
// AppDomain.Unload() method, you are able to selectively unload a given application domain from its hosting process. When you do 
// so, the application domain will unload each assembly in turn.

using System;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            AppDomain current = AppDomain.CurrentDomain;

            // get notification when the default App Domain is unloaded

            current.ProcessExit += (obj, e) => {
                Console.WriteLine("Default app domain unloaded.");
            };

            ListAllAssembliesInAppDomain(current);

            // make a new app domain and prompt user to unload
            MakeNewAppDomainAndUnload();
            Console.ReadKey();
        }

        public static void ListAllAssembliesInAppDomain(AppDomain domain) {

            Assembly[] assemblies = domain.GetAssemblies();

            Console.WriteLine("List of assemblies loaded in {0}:", domain.FriendlyName);

            foreach (Assembly asm in assemblies) {
                Console.WriteLine("Name: {0}\nVersion:{1}\n", asm.GetName().Name, asm.GetName().Version);
            }
        }

        public static void MakeNewAppDomainAndUnload() {
            AppDomain newDomain = AppDomain.CreateDomain("SecondAppDomain");

            try {
                newDomain.Load("CarLibrary");
            } catch (FileLoadException ex) {
                Console.WriteLine(ex);
            }
            ListAllAssembliesInAppDomain(newDomain);

            Console.WriteLine("Libraries has been loaded.. Press any key to unload the new appdomain..");
            Console.ReadLine();

            AppDomain.Unload(newDomain);
            Console.WriteLine("Appdomain has been unloaded..");

        }
    }
}