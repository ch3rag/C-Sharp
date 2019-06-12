// Investigating Process Module Set

using System.Diagnostics;
using System;
using System.Linq;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Console.Write("Enter PID: ");
            int pid;
            if (int.TryParse(Console.ReadLine(), out pid)) {
                EnumModulesForPID(pid);
            } else {
                Console.WriteLine("Invalid Input");
            }

            Console.ReadKey();
        }

        public static void EnumModulesForPID(int pId) {
            Process proc = null;
            try {
                proc = Process.GetProcessById(pId);
            } catch (ArgumentException ex) {
                Console.WriteLine("Invalid Argument");
                return;
            }

            Console.WriteLine("Here are the modules loaded for {0}:", proc.ProcessName);

            ProcessModuleCollection procModCollection = proc.Modules;
            foreach (ProcessModule module in procModCollection) {
                Console.WriteLine("Module Name: {0}", module.ModuleName);
            }
        }
    }
}