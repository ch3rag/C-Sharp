// QUERY AS FIELDS & RETURNING THE RESULT OF LINQ QUERY

// It is possible to define a field within a class (or structure) whose value is the result of a LINQ query. To do so, however, you cannot 
// make use of implicit typing (as the var keyword cannot be used for fields), and the target of the LINQ query cannot be instance-level 
// data; therefore, it must be static.

using System;
using System.Linq;
using System.Collections.Generic;

namespace Experiment {

    public class LinqAsField {
        public static string[] videoGames = { "Grand Theft Auto", "Farcry 3", "DeadSpace", "Crysis", "Call Of Duty", "Forza", "The Crew" };

        private IEnumerable<string> subset = from game in videoGames where game.Contains(" ") orderby game select game;

        public void PrintGames() {
            foreach (string game in subset) {
                Console.WriteLine(game);
            }
        }
    }

    public class Program {
        public static void Main(string[] args) {
            LinqAsField lq = new LinqAsField();
            lq.PrintGames();

            IEnumerable<string> colors = GetStringSubset();
            foreach (string color in colors) {
                Console.WriteLine(color);
            }

            string[] colorsArray = GetStringSubsetAsArray();
            foreach (string color in colorsArray) {
                Console.WriteLine(color);
            }
            Console.ReadKey();
        }

        // RETURING STRONGLY TYPED IENUMEABLE
        public static IEnumerable<string> GetStringSubset() {
            string[] colors = { "Red", "Green", "Blue", "Dark Red", "Light Red", "Magenta" };
            IEnumerable<string> subset = from color in colors where color.Contains(" ") orderby color select color;
            return subset;
        }

        // RETURNING STRONGLY TYPED STRING ARRAY USING IMMEDIATE EXECUTION
        public static string[] GetStringSubsetAsArray() {
            string[] colors = { "Red", "Green", "Blue", "Dark Red", "Light Red", "Magenta" };
            var subset = from color in colors where color.Contains(" ") orderby color select color;
            return subset.ToArray();
        }

    }


}