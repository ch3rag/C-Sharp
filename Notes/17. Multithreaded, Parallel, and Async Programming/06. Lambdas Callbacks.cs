// System.Threading
using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Experiment {

    public class Program {

        public static void Main(string[] args) {
            Func<int, int, int> addOp = (x, y) => {
                Thread.Sleep(1000);
                return x + y;
            };

            addOp.BeginInvoke(10, 20, (x) => {
                int addition = ((Func<int, int, int>)((x as AsyncResult).AsyncDelegate)).EndInvoke(x);
                Console.WriteLine(addition);
            }, null);

            Console.ReadKey();
        }
    }
}