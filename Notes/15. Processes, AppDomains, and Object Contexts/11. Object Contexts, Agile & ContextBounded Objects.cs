// Object Contexts
// A given application domain may be further subdivided into numerous context boundaries. A .NET context provides a way for a 
// single AppDomain to establish a “specific home” for a given object. Using context, the CLR is able to ensure that objects that 
// have special runtime requirements are handled in an appropriate and consistent manner by intercepting method invocations into 
// and out of a given context.


// Context-Agile & Context-Bound Objects
// .NET objects that do not demand any special contextual treatment are termed context-agile objects. 

// The objects that do demand contextual allocation are termed context-bound objects, and they must derive from the 
// System.ContextBoundObject base class. A context-sensitive type will also be adorned by a special category of .NET attributes 
// termed context attributes. All context attributes derive from the ContextAttribute base class.

using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace Experiment {

    // Sports Car class is not thread safe
    public class SportsCar {
        public SportsCar() {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty ctxProperty in ctx.ContextProperties) {
                Console.WriteLine("Context  Property: {0}", ctxProperty.Name);
            }
        }
    }

    // Sports Car class is in a thread safe context
    [Synchronization]
    public class SportsCarTS : ContextBoundObject {
        public SportsCarTS() {
            Context ctx = Thread.CurrentContext;
            Console.WriteLine("{0} object in context {1}", this.ToString(), ctx.ContextID);
            foreach (IContextProperty ctxProperty in ctx.ContextProperties) {
                Console.WriteLine("Context  Property: {0}", ctxProperty.Name);
            }
        }
    }

    public class Program {
        public static void Main(string[] args) {
            SportsCar sport = new SportsCar();
            Console.ReadLine();

            SportsCar sport2 = new SportsCar();
            Console.ReadLine();

            SportsCarTS sportTS = new SportsCarTS();
            Console.ReadLine();
        }
    }
}

