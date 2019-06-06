// IP ADDRESS

using System;
using System.Net;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            IPAddress ip1 = IPAddress.Parse("192.168.1.1");

            IPAddress ip2 = IPAddress.Loopback;
            IPAddress ip3 = IPAddress.Broadcast;
            IPAddress ip4 = IPAddress.Any;
            IPAddress ip5 = IPAddress.None;

            IPHostEntry iphe = Dns.GetHostEntry(Dns.GetHostName());

            IPAddress mySelf = iphe.AddressList[0];

            if (IPAddress.IsLoopback(ip2)) {
                Console.WriteLine("Loop Back Address Is: {0}", ip2.ToString());
            } else {
                Console.WriteLine("Error Obtaining Loopback Address");
            }

            Console.WriteLine("Local IP Address Is: {0}", mySelf.ToString());

            if (mySelf == ip2) {
                Console.WriteLine("Loopback IP Is Same As Local Address");
            } else {
                Console.WriteLine("Loopback IP Is NOT Same As Local Address");
            }


            Console.WriteLine("Test Address Is: {0}", ip1.ToString());
            Console.WriteLine("BroadCast Address Is: {0}", ip3.ToString());
            Console.WriteLine("Any Address Is: {0}", ip4.ToString());
            Console.WriteLine("None Address Is: {0}", ip5.ToString());

            // Any IPAddress object points to the 0.0.0.0 address. This address is most often used when a system has
            // multiple network interfaces and you do not want to bind a socket to any particular interface.

            // The None IPAddress object points to the 255.255.255.255 address, which is often used when a system wants to
            // create a dummy socket and not bind it to any interfaces

            Console.ReadKey();
        }
    }
}