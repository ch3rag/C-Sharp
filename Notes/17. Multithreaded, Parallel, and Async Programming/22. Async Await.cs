// PLINK Queries
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
            Console.WriteLine("Calling StartTask()");
            StartTaskAsync().Wait();
            Console.ReadLine();
            Console.WriteLine("Doing More Work In Main..");
            Console.ReadKey();
        }

        public static async Task StartTaskAsync() {
            Console.WriteLine("Starting Task...");
            string result = await Task.Run(() => DoTask());
            Console.WriteLine(result);
            result = await Task.Run(() => DoTask2());
            Console.WriteLine(result);
            Console.WriteLine("Going Back To Main()");

        }

        public static string DoTask() {
            Thread.Sleep(5000);
            return "Task 1 Done";
        }

        public static string DoTask2() {
            Thread.Sleep(5000);
            return "Task 2 Done";
        }
    }
}