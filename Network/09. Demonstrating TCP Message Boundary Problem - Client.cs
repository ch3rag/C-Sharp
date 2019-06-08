// MESSAGE BOUNDARY ISSUES
// CLIENT

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient {
    class Program {
        static void Main(string[] args) {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 8000);

            try {
                sock.Connect(ep);
            } catch (SocketException ex) {
                Console.WriteLine("Unable To Connect!");
                Console.WriteLine(ex);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Connected..");

            int recvFlag = 0;
            byte[] data = new byte[1024];
            recvFlag = sock.Receive(data);
            string message = Encoding.ASCII.GetString(data, 0, recvFlag);
            // PRINT WELCOME MESSAGE
            Console.WriteLine(message);

            // SEND 5 MESSAGES
            for (int i = 0; i < 5; i++) {
                message = "Message " + i;
                sock.Send(Encoding.ASCII.GetBytes(message), message.Length, SocketFlags.None);
            }

            Console.WriteLine("Disconnecting..");
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
            Console.ReadKey();
        }
    }
}
