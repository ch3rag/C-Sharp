// System.Threading
using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            // get Current Thread
            Thread currentThread = Thread.CurrentThread;
            // get domain in which the current thread is executing
            AppDomain domainOfThread = Thread.GetDomain();
            // get the context of the current thread
            Context ctx = Thread.CurrentContext;
        }
    }
}