
using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace Experiment {
    public class Program {

        private static CancellationTokenSource tokenSource = new CancellationTokenSource();

        public static void Main(string[] args) {
            Console.WriteLine("[1]: Sequence, [2] Parallel");
            Console.Write("Enter Your Choice: ");
            switch (Console.ReadLine()) {
                case "1":
                    ProcessQueryInSequence();
                    break;
                case "2":
                    Task.Factory.StartNew(() => ProcessQueryInParallel());
                    Console.WriteLine("Processing Started. Q To Stop:");
                    string input = Console.ReadLine();
                    if (input.Equals("q", StringComparison.OrdinalIgnoreCase)) {
                        tokenSource.Cancel();
                        Console.WriteLine("Processing Cancelled!");
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
            Console.ReadKey();
        }

        public static void ProcessQueryInSequence() {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int count = (from number in Enumerable.Range(0, 100000000) where number % 3 == 0 orderby number descending select number).Count();
            Console.WriteLine("Count: {0}", count);
            Console.WriteLine("Time Taken: {0}ms", timer.ElapsedMilliseconds);
            timer.Stop();
        }

        public static void ProcessQueryInParallel() {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            try {
                int count = (from number in Enumerable.Range(0, 100000000).AsParallel().WithCancellation(tokenSource.Token) where number % 3 == 0 orderby number descending select number).Count();
                Console.WriteLine("Count: {0}", count);
                Console.WriteLine("Time Taken: {0}ms", timer.ElapsedMilliseconds);
            } catch (OperationCanceledException ex) {
                Console.WriteLine(ex.Message);
            } finally {
                timer.Stop();
            }
        }
    }
}
