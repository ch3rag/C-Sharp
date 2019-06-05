// ANONYMOUS TYPES
// When you define an anonymous type, you do so by using the var keyword 
// Every Anonymous type derive System.Object
// THE VALUES ARE DEFINED AS KEY VALUE PAIR
// THE VALUE ONCE DEFINED ARE READ ONLY
// All anonymous types automatically derive from System.Object and are provided with an overridden version of Equals(), GetHashCode(), 
// and ToString().

// public override string ToString() {
//    StringBuilder builder = new StringBuilder();
//    builder.Append("{ Color = ");
//    builder.Append(this.<Color>i__Field);
//    builder.Append(", Make = ");
//    builder.Append(this.<Make>i__Field);
//    builder.Append(", CurrentSpeed = ");
//    builder.Append(this.<CurrentSpeed>i__Field);
//    builder.Append(" }");
//    return builder.ToString();
// }

// The GetHashCode() implementation computes a hash value using each anonymous type’s member variables as input to the 
// System.Collections.Generic.EqualityComparer<T> type. Using this implementation of GetHashCode(), two anonymous types will yield the same 
// hash value if (and only if) they have the same set of properties that have been assigned the same values. Given this implementation,
// anonymous types are well-suited to be contained within a Hashtable container.

// Limitations of Anonymous Types

// •     You don’t control the name of the anonymous type.
// •	 Anonymous types always extend System.Object.
// •	 The fields and properties of an anonymous type are always read-only.
// •	 Anonymous types cannot support events, custom methods, custom operators, or custom overrides.
// •	 Anonymous types are always implicitly sealed.
// •	 Anonymous types are always created using the default construct


using System;
using System.Reflection;

namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            var c1 = BuildAnonymousType("BMW", "Black", 90);

            var person1 = new { Name = "Max", Age = 30, Gender = "Male" };
            var person2 = new { Name = "Max", Age = 30, Gender = "Male" };
            // BOTH WILL BE THE OBJECTS SAME ANONYMOUS CLASS BECAUSE THEY HAVE THE SAME KEYS


            // compiler-generated Equals() method uses value-based semantics when testing for equality
            if (person1.Equals(person2)) {
                Console.WriteLine("Equal");
            } else {
                Console.WriteLine("Not Equal");

            }

            // anonymous types do not receive overloaded versions of the C# equality operators (== and !=)
            // checked on the basis of reference
            if (person1 == person2) {
                Console.WriteLine("Equal");
            } else {
                Console.WriteLine("Not Equal");

            }


            // the compiler will generate a new class definition only when an anonymous type contains unique names of the anonymous type. Thus, 
            // if you declare identical anonymous types (again, meaning the same names) within the same assembly, the compiler generates only
            // a single anonymous type definition.

            if (person1.GetType().Name == person2.GetType().Name) {
                Console.WriteLine("Equal");
            } else {
                Console.WriteLine("Not Equal");

            }

            // ANONYMOUS TYPES CAN CONTAIN OTHER ANONYMOUS TYPES TOO

            var purchase = new {
                TimeBought = DateTime.Now,
                ItemBought = new {
                    Color = "Red",
                    Make = "Saab",
                    CurrentSpeed = 55
                },
                Price = 34000
            };

            Console.ReadKey();
        }
        public static object BuildAnonymousType(string make, string color, int currentSpeed) {
            var car = new { Make = make, Color = color, Speed = currentSpeed };
            // car.Make = "Jaguar";  ERROR! READ ONLY

            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);
            Console.WriteLine("ToString() == {0}", car.ToString());
            ReflectOverAnonymousType(car);
            return car;
        }

        public static void ReflectOverAnonymousType(object obj) {
            Console.WriteLine("Object is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base Class Of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("Object.ToString(): {0}", obj.ToString());
            Console.WriteLine("Object.GetHashCode(): {0}", obj.GetHashCode());
        }
    }
}