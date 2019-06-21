using System;
using System.Threading;
using System.Net;
namespace Experiment {
    public delegate string GetWeather(string query);
    public class Program {

        public static void Main(string[] args) {

            GetWeather myWeather = new GetWeather(getWeather);

            Console.Write("Enter the city: ");
            string userInput = Console.ReadLine();

            IAsyncResult result = myWeather.BeginInvoke(userInput, null, null);

            do {

                Console.WriteLine("Fetching..");
                Thread.Sleep(1000);

            } while (!result.IsCompleted);


            string data = myWeather.EndInvoke(result);

            Console.WriteLine(data);

            Console.ReadKey();
        }

        public static string getWeather(string city) {
            WebClient downloader = new WebClient();
            string data = downloader.DownloadString(new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=dc24747f658480e73ae9491a9181b5d8"));
            return data;
        }
    }
}