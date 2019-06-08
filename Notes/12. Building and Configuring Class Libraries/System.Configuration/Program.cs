// System.Configuration

using System;
using System.Configuration;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            AppSettingsReader asr = new AppSettingsReader();
            int numOfTimes = (int)asr.GetValue("RepeatCount", typeof(int));
            string textColor = (string)asr.GetValue("TextColor", typeof(string));

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor);

            for (int i = 0; i < numOfTimes; i++) {
                Console.WriteLine("Hey");
            }

            Console.ReadKey();
        }
    }
}