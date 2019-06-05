// LINQ INTRO


using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            QueryOverArrays();
            QueryOverArraysWithExtensionMethods();
            QueryOverInts();
            Console.ReadKey();
        }

        public static void QueryOverArrays() {
            string[] videoGames = { "Grand Theft Auto", "Call Of Duty", "Battlefield", "Just Cause 2", "Assassins Creed", "Watch Dogs",
                                  "Saints Row 4", "PUBG", "Farcry" };

            // ALL ITEMS THAT HAVE A SPACE AND SORT THEM IN ALPHABETICAL ORDER
            IEnumerable<string> subset = from game in videoGames where game.Contains(" ") orderby game select game;
            RefectOverQueryResults(subset);
            foreach (string s in subset) {
                Console.WriteLine(s);
            }
        }

        public static void QueryOverArraysWithExtensionMethods() {
            string[] videoGames = { "Grand Theft Auto", "Call Of Duty", "Battlefield", "Just Cause 2", "Assassins Creed", "Watch Dogs",
                                  "Saints Row 4", "PUBG", "Farcry" };
            // ALL ITEMS THAT HAVE A SPACE AND SORT THEM IN ALPHABETICAL ORDER
            IEnumerable<string> subset = videoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);
            RefectOverQueryResults(subset);
            foreach (string s in subset) {
                Console.WriteLine(s);
            }
        }

        public static void QueryOverInts() {
            int[] numbers = { 10, 20, 1, 2, 3, 9, 12, 56, 4, 27 };
            IEnumerable<int> subset = from number in numbers where number < 10 select number;

            RefectOverQueryResults(subset);
            foreach (int s in subset) {
                Console.WriteLine(s);
            }
        }

        public static void RefectOverQueryResults(object obj, string queryType = "Query Expressions") {
            Console.WriteLine("\n***** Information About Your Query Using {0} *****\n", queryType);
            Console.WriteLine("Type: {0}", obj.GetType().Name);
            Console.WriteLine("Assembly: {0}", obj.GetType().Assembly.GetName().Name);
        }
    }
}