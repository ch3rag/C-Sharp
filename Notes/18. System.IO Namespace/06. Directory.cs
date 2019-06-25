// Directory

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            // Getting All The Drives
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives) {
               Console.WriteLine("==> {0}", drive);
            }

            // Try To Delete Directory
            try {
                Directory.Delete(@"C:\data");
                Console.WriteLine(@"C:\data deleted successfully.");
            } catch (IOException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}