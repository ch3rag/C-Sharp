// Socket Class

// Compatible SocketType And Protocol 
// Dgram           Udp             Connectionless communication
// Stream          Tcp             Connection-oriented communication
// Raw             Icmp            Internet Control Message Protocol
// Raw             Raw             Plain IP packet communication

using System;
using System.Net.Sockets;
using System.Net;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipep = new IPEndPoint(ip, 8000);

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Address Family: {0}", sock.AddressFamily);
            Console.WriteLine("Socket Type: {0}", sock.SocketType);
            Console.WriteLine("Protocol Type: {0}", sock.ProtocolType);
            Console.WriteLine("Blocking: {0}", sock.Blocking);
            sock.Blocking = false;
            Console.WriteLine("Blocking: {0}", sock.Blocking);
            Console.WriteLine("Connected: {0}", sock.Connected);

            sock.Bind(ipep);

            IPEndPoint ipep2 = (IPEndPoint)sock.LocalEndPoint;
            Console.WriteLine("Local End Point: {0}", ipep2.ToString());

            Console.ReadKey();
        }
    }
}