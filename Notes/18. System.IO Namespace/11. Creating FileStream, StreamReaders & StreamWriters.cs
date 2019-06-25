// Ways To Obtain FileStream & StreamReader/StreamWriter

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // using Create()

            FileInfo file = new FileInfo(@"C:\data.txt");
            
            using (FileStream fs = file.Create()) {
                // Use File Stream
            }

            // using Open            
            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) {
                // use file stream
            }

            // open file to only read
            using (FileStream fs = file.OpenRead()) {
                // use file stream
            }

            // open file to write only  
            using (FileStream fs = file.OpenWrite()) {
                // use file stream
            }


            // StreamReader
            using (StreamReader sr = file.OpenText()) {
                // use stream reader
            }

            // StreamWriter
            using (StreamWriter sw = file.CreateText()) {
                // use stream writer
            }

            using (StreamWriter sw = file.AppendText()) {
                // use stream writers
            }

            Console.ReadLine();
        }
    }
}