// STATIC CONSTRUCTORS
// THESE CONSTRUCTORS ARE USED TO INITIALIZE THE STATIC MEMBERS OF THE CLASS
// SUCH MEMBER WHOSE VALUE CAN'T BE SPECIFIED AT COMPILE AND MUST BE COMPUTED AT THE RUN TIME
// THE RUN ONLY ONCE
// CLR calls all static constructors before the first use (and never calls them again for that instance of the application).
// A given class may define only a single static constructor. In other words, the static constructor cannot be overloaded.
// A static constructor does not take an access modifier and cannot take any parameters.
// The static constructor executes before any instance-level constructors

using System;


namespace Notes {
    public class SavingsAccout {
        public double currentBalance;
        public static double interestRate;

        public SavingsAccout(double currentBalance) {
            Console.WriteLine("Regular Constructor");
            this.currentBalance = currentBalance;
        }

        static SavingsAccout() {
            // CAN'T USE THIS HERE
            interestRate = 0.4;
            Console.WriteLine("Static Constructor");
        }

    }
    

    public class Program {
        public static void Main(string[] args) {
            SavingsAccout myAccount = new SavingsAccout(1023.0001);
            // Static Constructor 
            // Regular Constructor

            Console.ReadKey();            
        }
    }
}