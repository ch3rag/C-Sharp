// SIMPLE SOCKET CLIENT

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient {
    class Program {
        static void Main(string[] args) {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // THE END POINT OF THE SERVER THAT YOU WANT TO CONNECT TO
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
            Console.WriteLine(message);

            // SEND DATA TO THE SERVER
            string userInput;
            while (true) {
                userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit") {
                    break;
                }

                sock.Send(Encoding.ASCII.GetBytes(userInput), userInput.Length, SocketFlags.None);

                // RECEIVE & PRINT
                data = new byte[1024];
                recvFlag = sock.Receive(data);
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recvFlag));
            }

            Console.WriteLine("Disconnecting..");
            // SHUT DOWN GRACEFULLY
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
            Console.ReadKey();
        }
    }
}
