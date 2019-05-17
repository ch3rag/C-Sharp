// STRING BUILDER

using System;
using System.Text;

namespace Strings {
    class Program {
        public static void Main(String[] args) {
            StringBuilder sb = new StringBuilder("***** FANTASTIC GAMES *****", 256);
            sb.Append('\n');
            sb.AppendLine("Half Life");
            sb.AppendLine("PUBG");
            sb.AppendLine("Crysis");
            sb.AppendLine("Dues Ex " + "2");
            Console.WriteLine(sb.ToString());

            sb.Replace("2", "Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} characters", sb.Length);
            Console.ReadKey();


        }
    }
}