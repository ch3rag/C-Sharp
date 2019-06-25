// Using StringReader & StringWriter

using System;
using System.IO;
using System.Text;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            using (StringWriter sw = new StringWriter()) {
                sw.WriteLine("Hello From Main()");
                // display contents
                Console.WriteLine("Contents Of StringWriter: {0}", sw);

                // get underlying string builder
                StringBuilder sb = sw.GetStringBuilder();

                sb.Insert(0, "New Message: ");
                Console.WriteLine("Contents Of StringBuilder: {0}", sb);
                Console.WriteLine("Contents Of StringWriter: {0}", sw);

                sb.Remove(0, "New Message: ".Length);
                Console.WriteLine("Contents Of StringBuilder: {0}", sb);
                Console.WriteLine("Contents Of StringWriter: {0}", sw);

                using(StringReader sr = new StringReader(sb.ToString())) {
                    string line = null;
                    while((line = sr.ReadLine()) != null) {
                        Console.WriteLine("Line ==> {0}", line);
                    }
                    
                }
            }
            Console.ReadLine();
        }
    }
}