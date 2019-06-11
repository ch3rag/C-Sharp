// MESSAGE BOUNDARY ISSUES
// CLIENT

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient {
    class Program {
        static void Main(string[] args) {
            TcpClient client = new TcpClient();

            // try to connect to localhost at port 8080
            try {
                client.Connect("127.0.0.1", 8080);
            } catch {
                Console.WriteLine("Error While Connecting!");
                Console.ReadKey();
                return;
            }

            // if success print message
            Console.WriteLine("Connected To Server");

            // receive data from the server using network stream
            byte[] data = new byte[1024];
            NetworkStream ns = client.GetStream();
            int rd = ns.Read(data, 0, data.Length);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, rd));

            // send hello message to the server
            string message = "Hello from client";
            ns.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);

            // close stream and sockets
            ns.Close();
            client.Close();

            Console.ReadKey();
        }
    }
}
