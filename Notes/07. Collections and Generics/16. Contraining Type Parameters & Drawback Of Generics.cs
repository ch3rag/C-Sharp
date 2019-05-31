// Constraining Type Parameters

// where T : struct 
// The type parameter <T> must have System.ValueType in its chain of inheritance (i.e., <T> must be a structure).

// where T : class 
// The type parameter <T> must not have System.ValueType in its chain of inheritance (i.e., <T> must be a reference type).

// where T : new() 
// The type parameter <T> must have a default constructor. This is helpful if your generic type must create an instance of the type parameter 
// because you cannot assume you know the format of custom constructors. Note that this constraint must be listed last on a multiconstrained type.

// where T : NameOfBaseClass 
// The type parameter <T> must be derived from the class specified by NameOfBaseClass.

// where T : NameOfInterface 
// The type parameter <T> must implement the interface specified by NameOfInterface. You can separate multiple interfaces as a comma-delimited list.

using System;

namespace Experiment {

    // T has three requirements. It must be a reference type (not a structure), as marked with
    // the class token. Second, T must implement the IComparable interface. Third, it must also have a default
    // constructor. Multiple constraints are listed in a comma-delimited list; however, you should be aware that the
    // new() constraint must always be listed last
    public class MyGenericClass<T> where T : class, IComparable, new() { }

    // Multiple Type Parameters
    public class MyGenericClassTwo<K, V> where K : struct where V: class, ICloneable, new() { }

	// !!!!!!!!!!!!!!!! NOTE !!!!!!!!!!!!!!!!!!!!!
    // Generic Classes Does Not Allow To Operators
    // WON'T COMPILE!!

    // public class MyMath<T> {
    //     public static Add(T a, T b) {
    //         return a + b;
    //     }
     
    //     public static Subtract(T a, T b) {
    //         return a i b;
    //     }
    // }

    public class Program {
        public static void Main(string[] args) {
            
        }

        // Methods
        // Wil swap only value types
        public static void Swap<T>(ref T a, ref T b) where T : struct {

        }
    }
}