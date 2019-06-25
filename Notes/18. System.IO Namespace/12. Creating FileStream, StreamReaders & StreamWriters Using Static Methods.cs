// Ways To Obtain FileStream & StreamReader/StreamWriter Using File

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // using Create()
            using (FileStream fs = File.Create(@"C:\data.txt")) {
                // Use File Stream
            }

            // using Open            
            using (FileStream fs = File.Open(@"C:\data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) {
                // use file stream
            }

            // open file to only read
            using (FileStream fs = File.OpenRead(@"C:\data.txt")) {
                // use file stream
            }

            // open file to write only  
            using (FileStream fs = File.OpenWrite(@"C:\data.txt")) {
                // use file stream
            }


            // StreamReader
            using (StreamReader sr = File.OpenText(@"C:\data.txt")) {
                // use stream reader
            }

            // StreamWriter
            using (StreamWriter sw = File.CreateText(@"C:\data.txt")) {
                // use stream writer
            }

            using (StreamWriter sw = File.AppendText(@"C:\data.txt")) {
                // use stream writers
            }

            Console.ReadLine();
        }
    }
}