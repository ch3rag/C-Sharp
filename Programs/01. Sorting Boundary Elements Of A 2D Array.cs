using System;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {

            int[,] array = new int[4, 6] {
             {1, 2, 3,  4, -88, 56},
             {10, 5, 6, 5, 99, -90},
             {9, 8, 88, -1, 78, 12},
             {77, -55, 18, 0, 90, 101}
            };

            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int maxI = 0, maxJ = 0, maxVal, curI = 0, curJ = 0, temp = 0, pMaxValue = Int32.MaxValue;

            while (true) {
                maxVal = Int32.MinValue;
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < cols; j++) {
                        if (i == 0) {
                            temp = array[i, j];
                        } else if (j == cols - 1) {
                            temp = array[i, j];
                        } else if (i == rows - 1) {
                            temp = array[i, j];
                        } else if (j == 0) {
                            temp = array[i, j];
                        }
                        if (temp > maxVal && temp < pMaxValue) {
                            maxI = i; maxJ = j; maxVal = temp;
                        }
                    }
                }

                temp = array[curI, curJ];
                array[curI, curJ] = array[maxI, maxJ];
                array[maxI, maxJ] = temp;
                pMaxValue = array[curI, curJ];

                if (curI == 0 && curJ < cols - 1) curJ++;
                else if (curJ == cols - 1 && curI < rows - 1) curI++;
                else if (curI == rows - 1 && curJ > 0) curJ--;
                else curI--;
                if (curJ == 0 && curI == 0) break;
            }

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}