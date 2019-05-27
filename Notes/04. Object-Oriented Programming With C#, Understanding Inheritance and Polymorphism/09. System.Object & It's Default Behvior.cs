// SYSTEM.OBJECT & DEFAULT BEHAVIOR

// Equals()
// By default, this method returns true only if the items being compared refer to the same item in memory. Thus, Equals() is used
// to compare object references, not the state of the object. Typically, this method is overridden to return true only if the objects being
// compared have the same internal state values. Be aware that if you override Equals(), you should also override GetHashCode(), as these
// methods are used internally by Hashtable types to retrieve subobjects from the container.

// Finalize()
// This method (when overridden) is called to free any allocated resources before the object is destroyed.

// GetHashCode()
// This method returns an int that identifies a specific object instance.

// ToString() 
// This method returns a string representation of this object, using the <namespace>.<type name> format (termed the fully qualified name). 
// This method will often be overridden by a subclass to return a tokenized string of name/value pairs that represent the object’s internal 
// state, rather than its fully qualified name.

// GetType() 
// This method returns a Type object that fully describes the object you are currently referencing. In short, this is a Runtime Type
// Identification (RTTI) method available to all objects

// MemberwiseClone()
// This method exists to return a member-by-member copy of the current object, which is often used when cloning an object 


using System;

namespace Experiment {

    public class Person { };
    class Program {
        static void Main(string[] args) {
            Person p = new Person();
            Console.WriteLine("ToString(): {0}", p.ToString());
            Console.WriteLine("GetHashCode(): {0}", p.GetHashCode());
            Console.WriteLine("GetType(): {0}", p.GetType());

            Person p2 = p;
            Object o = p2;
            if(o.Equals(p) && p2.Equals(o)) {
                Console.WriteLine("SAME INSTANCE!");
            }

            Console.ReadKey();
        }
    }
}
