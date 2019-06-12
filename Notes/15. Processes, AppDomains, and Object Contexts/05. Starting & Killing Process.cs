// Starting and Stopping Processes


using System.Diagnostics;
using System;
using System.Linq;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            StartAndKillProcess();
        }

        public static void StartAndKillProcess() {
            Process proc = null;
            try {
                proc = Process.Start("iexplore.exe", "www.google.com");
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