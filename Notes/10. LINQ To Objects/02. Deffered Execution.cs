// DEFERRED EXECUTION
// LINQ query expressions is that they are not actually evaluated until you iterate over the sequence. This is termed deferred execution.
using System;
using System.Linq;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var subset = from number in numbers where number % 2 == 0 select number;

            foreach (var num in subset) {
                Console.WriteLine(num);
            }

            // CHANGE DATA 
            numbers[1] = 13;
            // GOT UPDATED SUBSET WITHOUT QUERYING AGAIN!!
            foreach (var num in subset) {
                Console.WriteLine(num);
            }

            // IF YOU WANT TO EXECUTE THE QUERY IMMEDIATELY JUST CONVERT IN INTO LIST, ARRAY  DICTIONARY ETC

            int[] subsetAsArray = (from number in numbers where (number % 2 == 0) select number).ToArray<int>();
            foreach (int n in subsetAsArray) {
                Console.WriteLine(n);
            }

            Console.ReadKey();
        }
    }
}