// C#7 DIGIT SEPERATORS AND  BINARY LITERALS

using System;

namespace Features {
    class Program {
        public static void Main(String[] args) {
            
            Console.WriteLine(123_456_789L);
            // 123456789

            Console.WriteLine(123_678.345_123M);
            // 123678.345123

            // BINARY LITERALS
            Console.WriteLine(0b0001_0000);         // 16
	    Console.WriteLine(0b0000_1111);         // 15

            Console.ReadKey();

        }
    }
}
