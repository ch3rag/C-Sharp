// NULLABLES

// C# supports the concept of nullable data types. Simply put, a nullable type can represent all the values
// of its underlying type, plus the value null. Thus, if you declare a nullable bool, it could be assigned a value
// from the set {true, false, null}. This can be extremely helpful when working with relational databases,
// given that it is quite common to encounter undefined columns in database tables. Without the concept of a
// nullable data type, there is no convenient manner in C# to represent a numerical data point with no value.

// To define a nullable variable type, the question mark symbol (?) is suffixed to the underlying data
// type. Do note that this syntax is legal only when applied to value types. If you attempt to create a nullable
// reference type (including strings), you are issued a compile-time error. 

using System;
namespace Notes {
    class Program {
        static Random rand = new Random(DateTime.Now.Millisecond);
        public static void Main(string[] args) {
            
            // CREATING SOME NULLABLES
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            int?[] arrayOfNullableInts = new int?[10];

            int? nullableCopy = nullableInt;

            // THIS IS NOT ALLOWED
            // string? name = null;

            // The ? suffix notation is a shorthand for creating an instance of the generic System.Nullable<T> structure type.
            // THEREFORE WE CAN DO THIS
            System.Nullable<float> nullableFloat = 3.12f;

            // myNullable.HasValue BOOLEAN SPECIFIES WHETHER A VARIABLE HAS A VALID OF NOT

            if (nullableBool.HasValue) {
                Console.WriteLine("VALUE IS PRESENT");
            } else {
                Console.WriteLine("VALUE IS MISSING");
            }

            // IT CAN ALSO BE DONE USING THE != OPERTOR

            if (nullableDouble != null) {
                Console.WriteLine(nullableDouble);
            }

            for (int i = 0; i < 10; i++) {
                double? tryLuck = getValue();
                if (tryLuck.HasValue) {
                    Console.WriteLine("YAYY!! GOT A VALUE: {0}", tryLuck);
                } else {
                    Console.WriteLine("TRY AGAIN");
                }
            }


            // The Null Coalescing Operator(??)
            // This operator allows you to assign a value to a nullable type if the retrieved value is null

            for (int i = 0; i < 10; i++) {
                double? tryLuck = getValue() ?? -1;         // IF NULLL IS RECEIVED ASSIGN IT -1
                Console.WriteLine("YAYY!! GOT A VALUE: {0}", tryLuck);
            }

            // The Null Conditional Operator
            // THIS OPERATOR SIMPLIFIES IF ELSE CHECK ON REFERENCE VARIBLE
            int[] nums = null;

            // PRINTING LENGTH OF ARRAY
            // TRADITIONAL WAY
            
            if (nums != null) {
                Console.WriteLine(nums.Length);
            } else {
                Console.WriteLine(0);
            }

            // USING NULL CONDITIONAL OPERATOR
            // Console.WriteLine(nums?.Length ?? 0);
            Console.ReadLine();
        }

        static double? getValue() {
            double? value = (double)rand.Next(1000) / 1000;
            if (value < 0.5) {
                value = null;
            } 
            return value;
        }
    }
}

