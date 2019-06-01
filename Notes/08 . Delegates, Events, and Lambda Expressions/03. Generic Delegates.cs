// Generic Delegats


using System;

namespace Experiment {
    public class Program {

        public delegate void MyGenericDelegate<T>(T arg);

        public static void Main(string[] args) {
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            strTarget("Some String Data");

            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntegerTarget);
            intTarget(16);

            Console.ReadKey();
        }

        public static  void StringTarget(string message) {
            Console.WriteLine("Message In UpperCase: {0}", message.ToUpper());
        }

        public static void IntegerTarget(int number) {
            Console.WriteLine("1 + {0} is {1}", number, number + 1);
        }
    }
}