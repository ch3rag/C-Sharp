// Extension Methods
// Using extension methods, you are able to modify types without subclassing and without modifying the type directly

// When you define extension methods, the first restriction is that they must be defined within a static class therefore, each extension 
// method must be declared with the static keyword. The second point is that all extension methods are marked as such by using the this 
// keyword as a modifier on the first (and only the first) parameter of the method in question. The “this qualified” parameter represents 
// the item being extended.


using System;
using System.Reflection;

namespace Experiment {

    static class MyExtensions {
        // THIS METHOD WILL BE AVAILABLE TO ALL OF THE OBJECTS
        public static void DisplayDefiningAssembly(this object obj) {
            Console.WriteLine("{0} lives here => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // THIS METHOD WILL BE AVAILABLE TO ALL OF THE INTS
        public static int ReverseDigits(this int num) {
            char[] s = num.ToString().ToCharArray();
            Array.Reverse(s);
            string reverse = new String(s);
            return int.Parse(reverse);
        }
    }

    

    public class Program {
        public static void Main(string[] args) {
            int myInt = 1234567;
            myInt.DisplayDefiningAssembly();
            
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();

            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.DisplayDefiningAssembly();

            int rev = myInt.ReverseDigits();
            Console.WriteLine(rev);
            Console.ReadKey();
        }
    } 
}