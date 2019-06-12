// Investigating Process Thread Set
// MEMBERS

// CurrentPriority                  Gets the current priority of the thread
// Id                               Gets the unique identifier of the thread
// IdealProcessor                   Sets the preferred processor for this thread to run on
// PriorityLevel                    Gets or sets the priority level of the thread
// ProcessorAffinity                Sets the processors on which the associated thread can run
// StartAddress                     Gets the memory address of the function that the operating system called that started this thread
// StartTime                        Gets the time that the operating system started the thread
// ThreadState                      Gets the current state of this thread
// TotalProcessorTime               Gets the total amount of time that this thread has spent using the processor
// WaitReason                       Gets the reason that the thread is waiting

using System.Diagnostics;
using System;
using System.Linq;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Console.Write("Enter PID: ");
            int pid;
            if (int.TryParse(Console.ReadLine(), out pid)) {
                EnumThreadsForPID(pid);
            } else {
                Console.WriteLine("Invalid Input!");
            }
            Console.ReadKey();
        }

        public static void EnumThreadsForPID(int pID) {
            Process proc = null;
            try {
                proc = Process.GetProcessById(pID);
            } catch (ArgumentException ex) {
                Console.WriteLine("Invalid PID!");
                return;
            }

            ProcessThreadCollection procCollection = proc.Threads;
            Console.WriteLine("Here are the thread spawned by: {0}", proc.ProcessName);
            foreach (ProcessThread thread in procCollection) {
                Console.WriteLine("Thread ID: {0}\tStart Time: {1}\tPriority: {2}", thread.Id, thread.StartTime.ToShortTimeString(), thread.PriorityLevel);
            }
        }
    }
}