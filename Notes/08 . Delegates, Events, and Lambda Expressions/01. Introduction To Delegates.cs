// Delegates Intro

// A delegate is a type-safe object that points to another method (or possibly a list of methods) in the application, which can be invoked 
// at a later time. Specifically, a delegate maintains three important pieces of information: 
// •	 The address of the method on which it makes calls
// •	 The parameters (if any) of this method
// •	 The return type (if any) of this method

// When the C# compiler processes delegate types, it automatically generates a sealed class deriving from System.MulticastDelegate. This class 
// (in conjunction with its base class, System.Delegate) provides the necessary infrastructure for the delegate to hold onto a list of methods 
// to be invoked at a later time.
/*
public sealed class DelegateName : System.MulticastDelegate {
    public delegateReturnValue Invoke(allDelegateInputRefAndOutParams);         // for synchronous callbacks
    
    public IAsyncResult BeginInvoke(allDelegateInputRefAndOutParams, AsyncCallback cb, object state);   // for async callbacks
 * 
    public delegateReturnValue EndInvoke(allDelegateRefAndOutParams, IAsyncResult result);              // for async callbacks
}
*/

// When you build a type using the C# delegate keyword, you are indirectly declaring a class type that derives from System.MulticastDelegate. 
// This class provides descendants with access to a list that contains the addresses of the methods maintained by the delegate object, as 
// well as several additional methods (and a few overloaded operators) to interact with the invocation list. 
/*
public abstract class MulticastDelegate : Delegate {
    
    // Returns the list of methods "pointed to."
    public sealed override Delegate[] GetInvocationList();
    
    // Overloaded operators.
    public static bool operator ==(MulticastDelegate d1, MulticastDelegate d2);
    public static bool operator !=(MulticastDelegate d1, MulticastDelegate d2);
    
    // Used internally to manage the list of methods maintained by the delegate.
    private IntPtr _invocationCount;
    private object _invocationList;
}
*/

// System.MulticastDelegate obtains additional functionality from its parent class, System.Delegate.
/*
public abstract class Delegate : ICloneable, ISerializable  {
    
    // Methods to interact with the list of functions.
    public static Delegate Combine(params Delegate[] delegates);
    public static Delegate Combine(Delegate a, Delegate b);
    public static Delegate Remove(Delegate source, Delegate value);
    public static Delegate RemoveAll(Delegate source, Delegate value);
    
    // Overloaded operators.
    public static bool operator ==(Delegate d1, Delegate d2);
    public static bool operator !=(Delegate d1, Delegate d2);
    
    // Properties that expose the delegate target.
    public MethodInfo Method { get; }
    public object Target { get; }
}
*/

// Method 
// This property returns a System.Reflection.MethodInfo object that represents details of a static method maintained by the delegate.

// Target 
// If the method to be called is defined at the object level (rather than a static method), Target returns an object that represents the 
// method maintained by the delegate. If the value returned from Target equals null, the method to be called is a static member.

// Combine() This static method adds a method to the list maintained by the delegate. In C#, you trigger this method using the overloaded 
// += operator as a shorthand notation.

// GetInvocationList() 
// This method returns an array of System.Delegate objects, each representing a particular method that may be invoked.

// Remove() RemoveAll() 
// These static methods remove a method (or all methods) from the delegate’s invocation list. In C#, the Remove() method can be called 
// indirectly using the overloaded -= operator.

using System;

namespace Experiment {

    public delegate int BinaryOp(int x, int y);

    public class SimpleMath {
        public static int Add(int x, int y) {
            return x + y;
        }

        public int Subtract(int x, int y) {
            return x - y;
        }

        public static int Square(int x) {
            return x * x;
        }
    }

    public class Program {
        public static void Main(string[] args) {
            // create a delegate that points to add
            BinaryOp b = new BinaryOp(SimpleMath.Add);
            // Calls Invoke()
            Console.WriteLine("10 + 10 is {0}", b(10, 10));

            // only method that match delagate signature are permissible to be added
            // BinaryOp sq = new BinaryOp(SimpleMath.Square);   // ERROR!

            PrintDelegateInfo(b);

            SimpleMath math = new SimpleMath();
            BinaryOp s = new BinaryOp(math.Subtract);

            PrintDelegateInfo(s);

            Console.ReadKey();
        }

        public static void PrintDelegateInfo(Delegate d) {
            foreach (Delegate del in d.GetInvocationList()) {
                Console.WriteLine("Method Name: {0}", del.Method);
                Console.WriteLine("Type Name: {0}", del.Target);
            }
        }
    }
}