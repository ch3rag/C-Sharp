// Timer Callbacks

using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            // Print Time Every Second
            Timer timer = new Timer(
                                    (object obj) => Console.WriteLine("Time Is: {0}", DateTime.Now.ToLongTimeString()), // callback
                                    null,       // additional data to pass 
                                    0,          // wait before starting timer
                                    1000        // repeat every ms
                                    );
            Console.ReadKey();
        }
    }
}