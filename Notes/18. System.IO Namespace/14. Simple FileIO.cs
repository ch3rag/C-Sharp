// Simple File IO

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            string[] myFavouriteGames = {
                                            "Grand Theft Auto",
                                            "Doom",
                                            "Half Life",
                                            "Minecraft",
                                            "Rimworld",
                                            "Age Of Empires"
                                        };
            File.WriteAllLines(@"C:\games.txt", myFavouriteGames);

            string[] myGames = File.ReadAllLines(@"C:\games.txt");
            foreach (string game in myGames) {
                Console.WriteLine(game);
            }

            Console.ReadLine();
        }
    }
}