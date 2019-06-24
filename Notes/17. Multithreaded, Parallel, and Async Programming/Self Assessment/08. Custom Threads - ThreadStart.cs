
using System;
using System.Threading;
using System.Windows.Forms;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            Thread.CurrentThread.Name = "Primary Thread";
            Console.WriteLine("Executing Main On: {0}", Thread.CurrentThread.Name);

            Console.WriteLine("Number Of Threads? [1] OR [2]: ");
            string input = Console.ReadLine();

            switch (input) {
                case "1":
                    Console.WriteLine("Printing Number Using [1] Thread..");
                    PrintNumbers();
                    break;
                case "2":
                    Console.WriteLine("Printing Number Using [2] Threads..");
                    Thread myThread = new Thread(new ThreadStart(PrintNumbers));
                    myThread.Name = "Printer Thread";
                    myThread.Start();
                    break;
                default:
                    Console.WriteLine("Invaild Input.. Using [1] Thread...");
                    PrintNumbers();
                    break;
            }

            MessageBox.Show("Doing More Work In Main()");
        }

        public static void PrintNumbers() {
            Console.WriteLine("Executing PrintNumbers() On Thread: {0}", Thread.CurrentThread.Name);
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}