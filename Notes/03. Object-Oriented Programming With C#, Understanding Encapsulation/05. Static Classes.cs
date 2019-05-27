// STATIC CLASSES
// INSTANCE OF SUCH CLASSES CAN'T BE CREATED
// ALSO THEY CAN ONLY CONTAIN STATIC MEMBERS
// UTILITY CLASSES ARE GENERALLY STATIC

using System;

namespace Notes {
    public class Program {
        static class TimeUtilities {
            public static string getTime() {
                return DateTime.Now.ToShortTimeString();
            }

            public static string getDate() {
                return DateTime.Now.ToShortDateString();
            }

            // NON STATIC MEMBERS WILL GENERATE ERRORS
            // public DateTime getDateTime() {
            //     return DateTime.Now;
            // }
        }
        public static void Main(string[] args) {

            // CREATING AN INSTANCE WILL GENERATE ERROR
            // TimeUtilities tu = new TimeUtilities();

            Console.WriteLine(TimeUtilities.getTime());
            Console.WriteLine(TimeUtilities.getDate());
            Console.ReadKey();            
        }
    }
}