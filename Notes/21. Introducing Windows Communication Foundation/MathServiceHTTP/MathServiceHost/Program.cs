using System;
using System.ServiceModel;
using MathServiceLibrary;
// See App.config 
namespace MathServiceHost {
    class Program {
        static void Main(string[] args) {
            using (ServiceHost host = new ServiceHost(typeof(MyMathService))) {
                host.Open();
                Console.WriteLine("Service Started... Press Any Key To Terminate..");
                DisplayHostInfo(host);
                Console.ReadLine();
            }
        }

        public static void DisplayHostInfo(ServiceHost host) {
            Console.WriteLine("*************** HOST INFORMATION ***************");
            Console.WriteLine("Close Timeout: {0}", host.CloseTimeout);
            Console.WriteLine("Open Timeout: {0}", host.OpenTimeout);
            Console.WriteLine("State: {0}", host.State);

            Console.WriteLine("*************** END POINTS ***************");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
                Console.WriteLine();
            }
        }
    }
}
