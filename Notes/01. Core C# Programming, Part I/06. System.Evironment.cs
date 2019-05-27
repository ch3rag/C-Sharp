// USING SYSTEM.ENVIRONMENT TO PRINT DETAILS ABOUT OS

using System;
namespace Environment {
    class Program {
        public static int Main(string[] args) {
            ShowEnvironmentDetails();
            Console.ReadKey();
            return 0;
        }

        static void ShowEnvironmentDetails() {
            // PRINT LOGICAL DRIVES ON THE SYSTEM
            foreach (string drive in Environment.GetLogicalDrives()) {
                Console.WriteLine("Drive: {0}", drive);
            }

            // PRINT OS VERSION
            Console.WriteLine("OS: {0}", Environment.OSVersion);

            // NUMBER OF PROCESSORS
            Console.WriteLine("PROCESSORS: {0}", Environment.ProcessorCount);

            // .NET VERSION
            Console.WriteLine(".NET VERSION: {0}", Environment.Version);

            // OTHER USEFUL PROPERTIES
            // ExitCode                     Gets or sets the exit code for the application
            // Is64BitOperatingSystem       Returns a bool to represent whether the host machine is running a 64-bit OS
            // MachineName                  Gets the name of the current machine
            // NewLine                      Gets the newline symbol for the current environment
            // SystemDirectory              Returns the full path to the system directory
            // UserName                     Returns the name of the user that started this application
            // Version                      Returns a Version object that represents the version of the .NET platform
        }
    }
}