// PARAMETER MODIFIERS
/*
 * 1. (None) 
 * 
 * If a parameter is not marked with a parameter modifier, it is assumed to be
 * passed by value, meaning the called method receives a copy of the original data.
 * 
 * 2. out 
 * 
 * Output parameters must be assigned by the method being called and, therefore,
 * are passed by reference. If the called method fails to assign output parameters,
 * you are issued a compiler error.
 * 
 * 3. ref 
 * 
 * The value is initially assigned by the caller and may be optionally modified by
 * the called method (as the data is also passed by reference). No compiler error is
 * generated if the called method fails to assign a ref parameter.
 * 
 * 4. params 
 * 
 * This parameter modifier allows you to send in a variable number of arguments
 * as a single logical parameter. A method can have only a single params modifier,
 * and it must be the final parameter of the method. In reality, you might not need
 * to use the params modifier all too often; however, be aware that numerous 
 * methods within the base class libraries do make use of this C# language feature.
 * 
 */

using System;
namespace Notes {
    class Program {
        public static void Main(string[] args) {
            
            // NONE
            int a = 10, b = 12;
            Console.WriteLine(Add(a, b));
            Console.WriteLine(a + " " + b);

            // OUT 
            // A method that defines output parameters must assign the parameter to a valid value before exiting the method scope.
            // OR IT WILL GENERATE A COMPILER ERROR
            int sum;
            Add(a, b, out sum);
            Console.WriteLine(sum);
            // WE CAN USE DISCARD (AN UNDERSCORE) IF WE DONT CARE ABOUT THE OUT VALUE AND NEED JUST RETURN VALUE
            // FOR EXAMPLE IF WE WANT TO FIND OUT IF THE NUMBER CAN BE SQUAREROOTED
            // SUPPORTED IN C# 7
            // bool isPossible = squareRoot(-1, out _);
            // Console.WriteLine(isPossible);              // FALSE

            // REF
            // REF IS USED TO PASS VALUES BY REFERNCE
            // REF VS OUT
            // Output parameters do not need to be initialized before they are passed to the method.
            // The reason for this is that the method must assign output parameters before exiting.

            // Reference parameters must be initialized before they are passed to the method.
            // The reason for this is that you are passing a reference to an existing variable. If you
            // don’t assign it to an initial value, that would be the equivalent of operating on an
            // unassigned local variable.

            string s1 = "Hello";
            string s2 = "World";
            swapStrings(ref s1, ref s2);
            Console.WriteLine(s1 + " " + s2);           // WORLD HELLO

            // IN ADDITION TO PASSING REFERENCES, WE CAN ALSO RETURN THE REFERENCES
            // SUPPORTED IN C# 7+
            // string[] arr = {"One", "Two", "Three"};

            // RETURNED REF CAN ALSO BE TREATED AS NON-REFERENCE
            // string output =  StringAtPosition(arr, 1);
            // output " NEW 1 ";       // THIS WON'T AFFECT THE ARRAY

            // REF LOCAL
            // ref string refOutput = ref StringAtPosition(arr, 1);
            // refOutput = "New";      // THIS WILL AFFECT THE ARRAY
			
            // foreach (string s in arr) {
            //    Console.WriteLine(s);
            // }
            // PRINT => One, New, Three

            // PARAMS
            // ALLOWS YOU TO SEND VARIABLE NUMBER OF ARGUMENTS OF "SAME" TYPE 
            // MUST BE THE FINAL PARAMETER IN THE PARAMETER LIST
            double average = GetAverage(1, 2, 5, 7, 1, 90, 45, 23, 78);
            Console.WriteLine(average);     // 28

            Console.ReadKey();
        }

        
        // NO MODIFIER(PASS BY VALUE)

        static int Add(int x, int y) {
            int sum = x + y;
            x = 99999;              // CALLER WILL NOT SEE THESE CHANGES
            y = 10101;
            return sum;
        }

        // OUT MODIFIER

        static void Add(int x, int y, out int sum) {
            sum = x + y;
        }

        static bool squareRoot(double x, out double sqrt) {
            if (x < 0) {
                sqrt = 0;
                return false;
            } else {
                sqrt = Math.Sqrt(x);
                return true;
            }
        }

        // REF
        static void swapStrings(ref string s1, ref string s2) {
            string temp = s1;
            s1 = s2;
            s2 = temp;
        }

        // REF RETURNS 
        // public static ref string StringAtPosition(string[] arr, int pos) {
        //     return ref arr[pos];
        // }

        // PARAMS
        static double GetAverage(params double[] values) {
            double sum = 0;
            foreach (double value in values) {
                sum += value;
            }
            return sum / values.Length;
        }
    }
}