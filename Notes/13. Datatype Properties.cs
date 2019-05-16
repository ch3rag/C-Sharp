// DATATYPE PROPERTIES

using System;
namespace VariableDeclaration {
    class Program {
        public static void Main(string[] args) {
            // NUMERICAL
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity : {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity : {0}", double.NegativeInfinity);

            // BOOLEANS
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);
            Console.WriteLine("bool.TrueString: {0}", bool.TrueString);


            // CHARS
            Console.WriteLine("char.IsDigit('a'): {0}", char.IsDigit('a'));
            Console.WriteLine("char.IsLetter('a'): {0}", char.IsLetter('a'));
            Console.WriteLine("char.IsWhiteSpace(\"Hello There\", 5): {0}", char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace(\"Hello There\", 6): {0}", char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}", char.IsPunctuation('?'));
            Console.ReadKey();
        }
    }
}