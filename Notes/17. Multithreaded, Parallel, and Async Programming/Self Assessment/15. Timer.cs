using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Experiment {

    public class Program {

        private static readonly object threadLock = new Object();
        public static void Main(string[] args) {
            Timer timer = new Timer(new TimerCallback(PrintTime), "Hi", 0, 1000);
            Thread.Sleep(4000);
            Console.ReadKey();
        }

        public static void PrintTime(object state) {
            Console.WriteLine("Message From Main(): {0}", state);
            Console.WriteLine("Current Time: {0}", DateTime.Now.ToShortTimeString());
        }
    }
}
