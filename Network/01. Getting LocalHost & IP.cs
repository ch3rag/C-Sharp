// FINDING HOSTNAME AND IP OF CURRENT SYSTEM

using System;
using System.Net;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            string hostName = Dns.GetHostName();
            IPHostEntry mySelf = Dns.GetHostByName(hostName);
            Console.WriteLine("HOST NAME: {0}", hostName);
            foreach (IPAddress ip in mySelf.AddressList) {
                Console.WriteLine("IP: {0}", ip);
            }

            Console.ReadKey();
        }
    }
}