// BIG INTEGER

using System.Numerics;
using System;

namespace BigIntegers {
    class Program {
        public static void Main(String[] args) {
            BigInteger biggy = BigInteger.Parse("99999999999999999999999999999999999999999999999999");
            Console.WriteLine("The Value Of Biggy is {0}", biggy);
            Console.WriteLine("Is Biggy Even? {0}", biggy.IsEven);
            Console.WriteLine("Is Biggy Power Of 2? {0}", biggy.IsPowerOfTwo);
            
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("88888888888888888888888888888888888888"));

            Console.WriteLine("A Really Big Number: {0}", reallyBig);

            // IT CAN BE ALSO DONE BY BIGINTEGER'S OVERLOADED OPERATORS

            BigInteger reallyReallyBig = reallyBig * biggy;
            Console.WriteLine("A Really Really Big Number: {0}", reallyReallyBig);

            Console.ReadKey();
        }
    }
}