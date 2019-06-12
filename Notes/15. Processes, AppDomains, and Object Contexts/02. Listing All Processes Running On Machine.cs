
using System.Diagnostics;
using System;
using System.Linq;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            ListAllRunningProcesses();

            // it is also possible to get a specific process by its PID
            Process proc = null;
            try {
                proc = Process.GetProcessById(0);
                Console.WriteLine("Process: {0}", proc.ProcessName);
            } catch (ArgumentException ex) {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }

        public static void ListAllRunningProcesses() {
            // GET ALL THE PROCESSES ORDERED BY PID
            (from process in Process.GetProcesses() orderby process.Id select process).ToList().ForEach(x => {
                Console.WriteLine("PID: {0}\tName: {1}", x.Id, x.ProcessName);
            });

        }
    }
}