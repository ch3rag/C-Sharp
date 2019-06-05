// BREAKING IT DOWN!
// •	 Query expressions are created using various C# query operators.
// •	 Query operators are simply shorthand notations for invoking extension methods defined by the System.Linq.Enumerable type.
// •	 Many methods of Enumerable require delegates (Func<> in particular) as parameters.
// •	 Any method requiring a delegate parameter can instead be passed a lambda expression.
// •	 Lambda expressions are simply anonymous methods in disguise (which greatly improve readability).
// •	 Anonymous methods are shorthand notations for allocating a raw delegate and manually building a delegate target method

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            QueryStringWithOperators();
            QueryStringWithEnumerableAndLambdas();
            QueryStringWithAnonymousMethods();
            Console.ReadKey();
        }

        public static void QueryStringWithOperators() {
            string[] games = { "Grand Theft Auto", "Farcry", "Battlefield", "Call Of Duty", "Watch Dogs", "Crysis" };

            var subset = from game in games where game.Contains(" ") orderby game select game;

            subset.ToList().ForEach(x => Console.WriteLine(x));

        }

        public static void QueryStringWithEnumerableAndLambdas() {
            string[] games = { "Grand Theft Auto", "Farcry", "Battlefield", "Call Of Duty", "Watch Dogs", "Crysis" };
            var subset = games.Where(game => game.Contains(" ")).OrderBy(game => game).Select((game, index) => (index + 1) + ". " + game);

            subset.ToList().ForEach(x => Console.WriteLine(x));

        }

        public static void QueryStringWithAnonymousMethods() {
            string[] games = { "Grand Theft Auto", "Farcry", "Battlefield", "Call Of Duty", "Watch Dogs", "Crysis" };

            Func<string, int, string> selector = delegate(string game, int index) {
                return string.Format("{1}. {0}", game, index + 1);
            };

            var subset = games.Where(delegate(string game) {
                return game.Contains(" ");
            }).OrderBy(delegate(string game) {
                return game;
            }).Select(selector);

            Action<string> printer = delegate(string s) {
                Console.WriteLine(s);
            };

            subset.ToList().ForEach(printer);
        }
    }
}