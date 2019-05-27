// CHECKING OVERFLOWS

using System;

namespace CheckingOverflows {
    class Program {
        public static void Main(String[] args) {
            byte b1 = 100;
            byte b2 = 200;
            try {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine("SUM: {0}", sum);
            } catch (OverflowException err) {
                Console.WriteLine(err.Message);
            }

            // OR USING CHECKED BLOCK

            try {
                checked {
                    byte sum = (byte)Add(b1, b2);
                }
            } catch (OverflowException err) {
                Console.WriteLine(err.Message);
            }

            // OR USING -checked FLAG WHILE BUILING
            // OR ENABLE IT IN ADVANCED PROJECT BUILD PROPERTIES

            // TO IGNORE OVERFLOWS IT CAN BE WRAPPED IN unchecked BLOCK IF PROJECT WIDE OVERFLOWING CHECKS ARE ENABLED

            unchecked {
                byte sum2 = (byte)Add(b1, b2);
                Console.WriteLine("Sum: {0}", sum2);
            }

            Console.ReadKey();
        }

        static int Add(byte b1, byte b2) {
            return b1 + b2;
        }
    }
}