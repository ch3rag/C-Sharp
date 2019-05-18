// ARRAYS BASICS

using System;


namespace Notes {
    class Program {
        public static void Main(string[] args) {
            // DECLARING ARRAY WITH SIZE 3
            // VALUES WILL BE INITIALIZED TO THEIR DEFAULT VALUES
            int[] myArr = new int[3];

            myArr[0] = 1;
            myArr[1] = 2;
            myArr[2] = 3;

            foreach (int n in myArr) {
                Console.WriteLine(n);
            }

            int[] evens = { 2, 4, 5, 8, 10 };
            int[] odds = new int[5] { 1, 3, 5, 7, 9 };

            // NEW KEYWORD IS OPTIONAL IN THIS CASE BUT WHEN IT IS USED =>
            // SIZE < INITIALIZERS = ERROR
            // int[] primes = new int[3] { 2, 3, 5, 7 };

            // SIZE > INITIALIZERS = ERROR
            // int[] primes = new int[5] { 2, 3, 5, 7 };

            // IMLICITLY TYPED ARRAYS
            // MUST USE NEW IN THIS CASE

            var cars = new[] { "Honda", "Ford", "Audi", "BMW" };
            Console.WriteLine(cars.GetType().Name);         // STRING[]
            Console.WriteLine(cars.ToString());             // SYETEM.STRING[]

            // MIXED TYPES ARE NOT ALLOWED IN ANY CASE
            // HOWEVER IF AN ARRAY OF OBJECTS IS DEFINED THEN WE CAN STORE ANY OBJECT
            // SINCE ALL THE TYPES INCLUDING PRIMITIVES ARE DESCENDANT OF SYSTEM.OBJECT THEREFORE IT CAN ACCOMODATE ANY TYPE OF DATA

            object[] mixed = new object[4];
            mixed[0] = 24;
            mixed[1] = "Hello";
            mixed[2] = new DateTime();
            mixed[3] = new int[3] { 1, 2, 3 };

            foreach (object o in mixed) {
                Console.WriteLine(o.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}