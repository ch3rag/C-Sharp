// Except, Union, Concat

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            string[] cars1 = { "BMW", "Aztec", "Yugo" };
            string[] cars2 = { "BMW", "Aztec", "Saab" };

            // IN A BUT NOT IN B
            // A - B
            (from car in cars1 select car).Except(from car in cars2 select car).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            // INTERSECTION
            (from car in cars1 select car).Intersect(from car in cars2 select car).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            // UNION
            (from car in cars1 select car).Union(from car in cars2 select car).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            // CONCAT
            (from car in cars1 select car).Concat(from car in cars2 select car).ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            // REMOVING REDUNDANT DATA (ONLY DISTINCT VALUES)
            ((from car in cars1 select car).Concat(from car in cars2 select car)).Distinct().ToList().ForEach(x => Console.WriteLine(x));

            // AGGEREGATION
            int[] temps = { 32, 14, 29, 35, 42, 21, 28 };



            // MAX
            int max = (from temp in temps select temp).Max();

            // MIN
            int min = (from temp in temps select temp).Min();

            // MAP 
            var farh = temps.Select(x => x * 1.8 + 32);

            // REDUCE
            int sum = (from temp in temps select temp).Aggregate(0, (x, c) => x + c);

            // FILTER
            var hot = from temp in temps where temp > 30 select temp;
            Console.WriteLine();

            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(sum);

            Console.WriteLine();

            farh.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            hot.ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}