// DYNAMIC TYPES


using System;
using Microsoft.CSharp.RuntimeBinder;


namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            dynamic variable;

            variable = 12;
            Console.WriteLine(variable.GetType());
            variable = 4.6788;
            Console.WriteLine(variable.GetType());
            variable = "Hello";
            Console.WriteLine(variable.GetType());

            // NO COMPILE TIME CHECKS ON DYNAMIC TYPE IF IT SUPPORTS THE MEMBER OR NOT
            // THIS WILL COMPILE SUCCESSFULLY
            try {
                variable.Foo(DateTime.Now);
            } catch (RuntimeBinderException ex) {
                Console.WriteLine("Error: " + ex.GetType().FullName);
            }

            Console.WriteLine(variable.Length);

            Console.ReadKey();
        }
    }

    // SCOPE OF DYNAMIC KEYWORD
    // IT CAN BE USED AS CLASS AND STRUCT FIELDS, RETURN TYPES AS WELL AS PARAMETERS
    public class MyDynamicClass {
        private static dynamic myDynamicField;
        public dynamic DynamicProperty { get; set; }
        public dynamic DynamicMethod(dynamic dynamicParam) {
            dynamic dynamicLocalVariable = "Local Variable";
            int myInt = 10;
            if (dynamicParam is int) {
                return dynamicLocalVariable;
            } else {
                return myInt;
            }
        }
    }

    // Limitations of the dynamic Keyword
    // 1. Dynamic data item cannot make use of lambda expressions or C# anonymous methods when calling a method
    // 2. Dynamic point of data cannot understand any extension methods. 
}