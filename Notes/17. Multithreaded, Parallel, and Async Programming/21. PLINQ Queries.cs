// PLINQ Queries
// System.Linq.ParallelEnumerable Namespace

// AsParallel() 
// Specifies that the rest of the query should be parallelized, if possible 

// WithCancellation() 
// Specifies that PLINQ should periodically monitor the state of the provided cancellation token and cancel execution if it is 
// requested

// WithDegreeOfParallelism() 
// Specifies the maximum number of processors that PLINQ should use to parallelize the query

// ForAll() 
// Enables results to be processed in parallel without first merging back to the consumer thread, as would be the case when 
// enumerating a LINQ result using the foreach keyword


using System;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;


namespace Experiment {
    public class Program {


        private static CancellationTokenSource cancelToken = new CancellationTokenSource();

        public static void Main(string[] args) {
            do {
                Console.WriteLine("Press any key to start processing.. ");
                Console.ReadKey();
                Console.WriteLine("Processing... ");
                Task.Factory.StartNew(() => ProcessIntData());
                Console.Write("Enter Q to quit: ");
                string answer = Console.ReadLine();
                if (answer.Equals("q", StringComparison.OrdinalIgnoreCase)) {
                    cancelToken.Cancel();
                    break;
                }
            } while (true);
            Console.ReadKey();
        }

        public static void ProcessIntData() {
            int[] source = Enumerable.Range(1, 100000000).ToArray();
            int[] factors = null;
            try {
                // do in parallel is possible
                factors = (from num in source.AsParallel().WithCancellation(cancelToken.Token) where num % 3 == 0 orderby num descending select num).ToArray();
                Console.WriteLine("Found {0} numbers that match the query.", factors.Length);
            } catch (OperationCanceledException ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}