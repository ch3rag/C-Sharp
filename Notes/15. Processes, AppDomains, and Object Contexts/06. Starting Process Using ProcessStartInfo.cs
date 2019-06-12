// Controlling Process Startup Using the ProcessStartInfo Class
// The Start() method also allows you to pass in a System.Diagnostics.ProcessStartInfo type to specify
// additional bits of information regarding how a given process should come to life.
// Check ProcessStartInfo in object browser for more info.

using System.Diagnostics;
using System;
using System.Linq;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            StartAndKillProcess();
        }

        public static void StartAndKillProcess() {
            // Launch internet explorer and goto google.com, with maximized window
            Process proc = null;
            try {
                proc = Process.Start(new ProcessStartInfo() {
                    FileName = "iexplore.exe",
                    Arguments = "www.google.com",
                    WindowStyle = ProcessWindowStyle.Maximized
                });
            } catch (InvalidOperationException ex) {
                Console.WriteLine("Error while creating the process..");
            }

            Console.WriteLine("Process started.. Press any key to kill the process.");
            Console.ReadLine();
            try {
                proc.Kill();
                // error will be raised if the process had been killed already
            } catch (InvalidOperationException ex) {
                Console.WriteLine("Error while killing the process..");
            }
        }
    }
}