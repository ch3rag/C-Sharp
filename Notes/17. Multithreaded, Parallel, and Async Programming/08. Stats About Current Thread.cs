// Obtaining Statistics About Current Thread


using System;
using System.Threading;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Thread currentThread = Thread.CurrentThread;
            currentThread.Name = "Primary Thread";

            // show hosting details
            Console.WriteLine("Name of current app domain: {0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current context: {0}", Thread.CurrentContext.ContextID);

            // some stats about this thread
            Console.WriteLine("Thread Name: {0}", currentThread.Name);
            Console.WriteLine("Has thread started: {0}", currentThread.IsAlive);
            Console.WriteLine("Priority Level: {0}", currentThread.Priority);
            Console.WriteLine("Thread State: {0}", currentThread.ThreadState);


            Console.ReadKey();
        }
    }
}