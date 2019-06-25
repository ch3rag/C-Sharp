// DriveInfo

using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in myDrives) {
                Console.WriteLine("Name: {0}", drive.Name);
                Console.WriteLine("Type: {0}", drive.DriveType);

                // check if the drive is mounted
                if (drive.IsReady) {
                    Console.WriteLine("Free Space: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", drive.DriveFormat);
                    Console.WriteLine("Label: {0}", drive.VolumeLabel);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}