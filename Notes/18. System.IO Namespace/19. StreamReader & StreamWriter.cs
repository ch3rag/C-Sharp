// Using Stream Writer & Stream Writer

using System;
using System.IO;
using System.Text;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            // using(StreamWriter sw = new StreamWriter("hobbies.txt") {
            // OR
            using(StreamWriter sw = File.CreateText("hobbies.txt")) {
                sw.WriteLine("Programming");
                sw.WriteLine("Video Games");
                sw.WriteLine("Watching Movies");
                sw.WriteLine("Cricket");
                for (int i = 0; i < 10; i++) {
                    sw.Write(i + " ");
                }
                sw.Write(sw.NewLine);
            }
            Console.WriteLine("Writing Done!");

            // using(StreamReader sr = File.OpenText("hobbies.txt")) {
            // OR
            using(StreamReader sr = new StreamReader("hobbies.txt")) {
                string line = string.Empty;
                while((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }

            Console.WriteLine("Reading Done!");
            Console.ReadLine();
        }
    }
}