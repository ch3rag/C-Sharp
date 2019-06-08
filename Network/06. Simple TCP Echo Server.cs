// CREATING A SIMPLE SOCKET SERVER

using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // CREATE A SOCKET INSTANCE
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // TO BIND THE SOCKET CREATE AN ENDPOINT
            IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 8000);

            // BIND IT
            sock.Bind(ep);

            // LISTEN TO INCOMING CONNECTIONS
            sock.Listen(10);
            // BACKLOG IS NUMBER OF MAXIMUM PENDING CONNECTIONS

            Console.WriteLine("Listening on {0} on port {1}...", ep.Address, ep.Port);

            // PAUSES EXECUTION AND WAITS FOR INCOMING CONNECTION
            Socket client = sock.Accept();

            // CAST REMOTE ENDPOINT TO IPENDPOINT AND DISPLAY CLIENT DETAILS
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Connected With {0} on port {1}.", clientep.Address, clientep.Port);

            // SEND A MESSAGE
            string message = "Welcome To The Test Server";

            //  CONVERT IT INTO A BYTE ARRAY
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(message);

            // SEND THE DATA TO THE CLIENT 
            client.Send(data, data.Length, SocketFlags.None);

            // RECEIVE MESSAGE FROM THE CLIENT
            int recvFlag = 0;
            while (true) {
                data = new Byte[1024];
                // WAIT FOR DATA TO ARRIVE
                recvFlag = client.Receive(data);
                // when the TCP structure has detected that the remote client has initiated a close session (by sending a TCP FIN packet), 
                // the Receive() method is allowed to return a zero value.
                if (recvFlag == 0) break;

                // PRINT THE RECEIVED DATA
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recvFlag));

                // ECHO IT BACK
                client.Send(data, recvFlag, SocketFlags.None);
            }
            Console.WriteLine("Disconnected from {0}.", clientep.Address);
            client.Close();
            sock.Close();
            Console.ReadKey();
        }
    }
}