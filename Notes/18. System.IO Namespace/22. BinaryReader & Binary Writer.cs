// BinaryReader & BinaryWriter
using System;
using System.IO;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // writing data
            FileInfo file = new FileInfo(@"C:\data.dat");
            using(BinaryWriter bw = new BinaryWriter(file.OpenWrite())) {
                Console.WriteLine("Base Stream Is: {0}", bw.BaseStream);

                double doub = 3.14159;
                int myInt = 7;
                string name = "Chirag";

                bw.Write(doub);
                bw.Write(myInt);
                bw.Write(name);

            }

            Console.WriteLine("Writing Done!");

            // reading data

            using (BinaryReader br = new BinaryReader(file.OpenRead())) {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.ReadKey();
        }
    }
}