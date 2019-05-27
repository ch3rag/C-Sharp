// ACCESS MODIFIERS

// 1. Public
// Public items have no access restrictions. A public member can be accessed from an object, as well
// as any derived class. A public type can be accessed from other external assemblies. 

// 2. Private
// Private items can be accessed only by the class (or structure) that defines the item.

// 3. Protected
// Protected items can be used by the class that defines it and any child class. However, protected
// items cannot be accessed from the outside world using the C# dot operator.

// 4. Internal
// Internal items are accessible only within the current assembly. Therefore, if you define a set of
// internal types within a .NET class library, other assemblies are not able to use them.

// 5. Protected Internal
// When the protected and internal keywords are combined on an item, the item is accessible within
// the defining assembly, within the defining class, and by derived classes.

// By default, type members are implicitly private while types are implicitly internal. 


// APPLICABILITY
// TYPES                internal(default), public
// TYPE MEMBERS         private, public, protected, internal, protected internal
// NESTED TYPES         private(default), protected, protected internal

using System;

namespace Notes {

    public class Car {
        // NESTED MEMBER
        private enum CarColor {
            Red = 100,
            Blue = 200,
            Green = 300
        }
    }
    public class Program {
        public static void Main(string[] args) {

            Console.ReadKey();            
        }
    }
}