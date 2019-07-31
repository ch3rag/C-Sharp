using System;
using System.ServiceModel;
using MagicEightBallServiceLib;

namespace MagicEightBallServiceHost {
    class Program {
        static void Main(string[] args) {
            using(ServiceHost serviceHost = new ServiceHost(typeof(MagicEightBallService))) {
                serviceHost.Open();
                Console.WriteLine("The service is ready!");
                DisplayHostInfo(serviceHost);
                Console.WriteLine("Press enter to terminate the service");
                Console.ReadKey();
            }
        }

        public static void DisplayHostInfo(ServiceHost host) {
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("Binding: {0}", se.Binding.Name);
                Console.WriteLine("Contract: {0}", se.Contract.Name);
            }
        }
    }
}
