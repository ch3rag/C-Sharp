// MESSAGE BOUNDARY ISSUES
// SERVER

using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 8000);
            sock.Bind(ep);
            sock.Listen(10);

            Console.WriteLine("Listening on {0} on port {1}...", ep.Address, ep.Port);

            Socket client = sock.Accept();

            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Connected With {0} on port {1}.", clientep.Address, clientep.Port);

            // SEND A WELCOME MESSAGE
            string message = "Welcome To The Test Server";
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(message);
            client.Send(data, data.Length, SocketFlags.None);

            int recvFlag = 0;

            while (true) {
                data = new byte[1024];
                recvFlag = client.Receive(data);
                if (recvFlag == 0) break;
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recvFlag));
            }

            Console.WriteLine("Disconnected from {0}.", clientep.Address);
            client.Close();
            sock.Close();
            Console.ReadKey();
        }
    }
}