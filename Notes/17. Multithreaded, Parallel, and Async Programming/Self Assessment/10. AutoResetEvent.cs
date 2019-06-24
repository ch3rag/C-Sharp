using System;
using System.Threading;

namespace Experiment {

    public class AddWrapper {
        public int x, y;
        public AddWrapper(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
    public class Program {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        public static void Main(string[] args) {
            Thread myThread = new Thread(new ParameterizedThreadStart(Add));
            myThread.Start(new AddWrapper(19, 18));
            Console.WriteLine("Waiting...");
            // Wait until signal is received!
            waitHandle.WaitOne();

            Console.WriteLine("Done With Main()");
            Console.ReadLine();
        }

        public static void Add(object work) {
            if (work is AddWrapper) {
                AddWrapper aw = work as AddWrapper;
                int result = aw.y + aw.x;
                Thread.Sleep(2000);
                Console.WriteLine("Addition Done. Result: {0}", result);
                waitHandle.Set();
            }
        }
    }
}
