using System;
using System.Threading;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Thread currentThread = Thread.CurrentThread;

            AppDomain currentThreadDomain = Thread.GetDomain();

            Console.WriteLine("Current Domain Name: {0}", currentThreadDomain.FriendlyName);
            Console.WriteLine("Current Domain ID: {0}", currentThreadDomain.Id);
            Console.WriteLine("Current Context ID: {0}", Thread.CurrentContext.ContextID);

            Console.WriteLine("Thread ID: {0}", currentThread.ManagedThreadId);
            Console.WriteLine("Thread Name: {0}", currentThread.Name);
            Console.WriteLine("Thread Priority: {0}", currentThread.Priority);
            Console.WriteLine("Is Thread Running: {0}", currentThread.IsAlive);
            Console.WriteLine("Is Thread Background?: {0}", currentThread.IsBackground);
            Console.WriteLine("Does The Thread Belong To Thread Pool?: {0}", currentThread.IsThreadPoolThread);




            Console.ReadKey();
        }
    }
}