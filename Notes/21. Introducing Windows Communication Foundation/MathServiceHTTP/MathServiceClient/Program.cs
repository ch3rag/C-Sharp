using System;
using MathServiceClient.ServiceReference1;

namespace MathServiceClient {
    class Program {
        static void Main(string[] args) {
            using (MyMathServiceClient client = new MyMathServiceClient("BasicHttpBinding_MyMathService")) {
                Console.Write("Enter First Number: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Second Number: ");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Here's Your Sum: {0}", client.Sum(a, b));
                   
            }
        }
    }
}
