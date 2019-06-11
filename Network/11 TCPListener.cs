using System;
using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // configure port and create a new socket listener
            const int port = 8080;
            TcpListener server = new TcpListener(port);
            server.Start(10);
            Console.WriteLine("Server Started.. Listening on port " + port);

            // wait for the client
            TcpClient client = server.AcceptTcpClient();

            // once connected send a hello message to the client
            string message = "Hello From Server";
            NetworkStream ns = client.GetStream();
            ns.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);

            // receive message from the client
            byte[] data = new byte[1024];
            int rd = ns.Read(data, 0, 1024);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, rd));

            // close network steam and client server sockets
            ns.Close();
            client.Close();
            server.Stop();

            Console.ReadKey();
        }
    }
}