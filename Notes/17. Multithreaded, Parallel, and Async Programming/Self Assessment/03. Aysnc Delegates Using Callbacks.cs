using System;
using System.Threading;
using System.Net;

// Use AsyncResult to display result in anonymous functions
using System.Runtime.Remoting.Messaging;

namespace Experiment {
    public class Program {

        public static void Main(string[] args) {

            Func<string, string> getWeather = (city) => {
                WebClient downloader = new WebClient();
                string data = string.Empty;
                try {
                    data = downloader.DownloadString(new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=dc24747f658480e73ae9491a9181b5d8"));
                } catch (WebException ex) {
                    Console.WriteLine(ex.Message);
                }
                return data;
            };

            Console.Write("Enter the city: ");
            string userInput = Console.ReadLine();
            getWeather.BeginInvoke(userInput, new AsyncCallback((result) => {
                // !!                
                string data = ((Func<string, string>)((AsyncResult)result).AsyncDelegate).EndInvoke(result);
                Console.WriteLine(data);
            }), null);

            Console.ReadKey();
        }
    }
}