// MULTIDIMENSIONAL ARRAYS

using System;


namespace Notes {
    class Program {
        public static void Main(string[] args) {
            // TYPE I = RECTANGULAR ARRAY
            // ALL ROWS ARE OF SAME LENGTH

            int rows = 3;
            int cols = 4;

            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    matrix[i, j] = i * j;
                }
            }

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // TYPE II = JAGGED ARRAY
            // IT CONTAINS NUMBER OF INNER ARRAYS WITH DIFFERENT UPPER BOUNDS
            // ONLY UPPER BOUND OF EACH INNER CAN BE REDEFINED
            int[][] jaggedArray = new int[10][];

            for (int i = 0; i < jaggedArray.Length; i++) {
                jaggedArray[i] = new int[i + 7];
            }

            Console.WriteLine();
            // PRINT EACH ROW

            for (int i = 0; i < jaggedArray.Length; i++) {
                for (int j = 0; j < jaggedArray[i].Length; j++) {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }

    }
}