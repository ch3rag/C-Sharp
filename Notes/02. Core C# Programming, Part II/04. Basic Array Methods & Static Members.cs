// ARRAY PROPERTIES AND METHODS

using System;

namespace Notes {
    class Program {
        public static void Main(string[] args) {

            int[] evens = GetEvens(10);
            PrintArrayInt(evens, ", ");
            

            // CLEARING ARRAYS
            // CLEAR ARRAY AT INDEX 5, 6
            System.Array.Clear(evens, 5, 2);
            PrintArrayInt(evens, ", ");
            


            //COPYING ELEMENTS
            // DESINATION ARRAY LENGTH >= NUMBER OF ELEMS TO BE COPIED
            int[] copy = new  int[20];
            evens.CopyTo(copy, 10);
            PrintArrayInt(copy, ", ");
            

            // LENGTH
            Console.WriteLine(evens.Length);


            // NUMBER OF DIMESIONS
            int[,,] matrix3D = new int[3, 3, 3];
            Console.WriteLine(matrix3D.Rank);

            // REVERSING AN ARRAY
            System.Array.Reverse(evens);
            PrintArrayInt(evens, ", ");
            

            Console.ReadKey();
        }

        static void PrintArrayStr(string[] ar, string seperator) {
            foreach (string n in ar) {
                Console.Write(n + seperator);
            }
            Console.WriteLine();
        }

        
        static void PrintArrayInt(int[] ar, string seperator) {
            foreach (int n in ar) {
                Console.Write(n + seperator);
            }
            Console.WriteLine();
        }

        static int[] GetEvens(int length) {
            int[] evens = new int[length];
            for (int i = 0; i < length; i++) {
                evens[i] = (i + 1) * 2;
            }
            return evens;
        }
    }
}