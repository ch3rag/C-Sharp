using System;
using System.ServiceModel;
using MathClient.ServiceReference1;
using System.Threading;

namespace MathClient {
    class Program {
        static void Main(string[] args) {
            using (BasicMathClient client = new BasicMathClient()) {
                client.Open();
                IAsyncResult result = client.BeginAdd(10, 20, (ar) => {
                    Console.WriteLine("Result: {0} ", client.EndAdd(ar));
                }, null);

                while (!result.IsCompleted) {
                    Thread.Sleep(1000);
                    Console.WriteLine("Client Working...");
                }
            }
        }
    }
}
