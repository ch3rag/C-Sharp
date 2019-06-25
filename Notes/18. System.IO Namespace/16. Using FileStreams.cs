// Using File Streams

using System;
using System.IO;
using System.Text;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            using (FileStream fs = File.Open(@"C:\myMessage.dat", FileMode.Create)) {
                string message = "Hello!";
                byte[] messageToBytes = Encoding.Default.GetBytes(message);

                fs.Write(messageToBytes, 0, messageToBytes.Length);
                
                // seek back to beginning
                fs.Seek(0, SeekOrigin.Begin);

                Console.WriteLine("Message as an array of bytes: ");

                byte[] bytesFromFile = new byte[messageToBytes.Length];
                for (int i = 0; i < messageToBytes.Length; i++) {
                    bytesFromFile[i] = (byte)fs.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }

                string decodedMsg = Encoding.Default.GetString(bytesFromFile);
                Console.WriteLine("Decoded Message: {0}", decodedMsg);
                    
            }
            Console.ReadLine();
        }
    }
}
}