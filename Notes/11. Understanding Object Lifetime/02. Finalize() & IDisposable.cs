// Building Finalizable Objects

// When you override object.Finalize() for your custom classes, you establish a specific location to perform any necessary cleanup logic 
// for your type. Given that this member is defined as protected, it is not possible to directly call an object’s Finalize() method from a 
// class instance via the dot operator. Rather, the garbage collector will call an object’s Finalize() method (if supported) before removing
// the object from memory

// It is illegal to override Finalize() on structure types. This makes perfect sense given that structures are value types, which are never 
// allocated on the heap to begin with and, therefore, are not garbage collected! However, if you create a structure that contains unmanaged 
// resources that need to be cleaned up, you can implement the IDisposable interface

using System;


namespace Experiment {

    // FINALIZER
    class Car {
        public string PetName { get; set; }
        public int Speed { get; set; }

        public override string ToString() {
            return string.Format("[Petname: {0}; Speed: {1}]", this.PetName, this.Speed);
        }

        // ERROR!
        // protected override void Finalize() { }

        // FINALIZER SYNTAX
        ~Car() {
            Console.Beep();
        }

        // Finalizers are prefixed with a tilde symbol (~). Unlike a constructor, however, a finalizer never takes an access modifier (they 
        // are implicitly protected), never takes parameters, and can’t be overloaded (only one finalizer per class).
    }

    // IDISPOSABLE
    // Many unmanaged objects are “precious items” (such as raw database or file handles), it could be valuable to release them as soon as 
    // possible instead of relying on a garbage collection to occur. As an alternative to overriding Finalize(), your class could implement 
    // the IDisposable interface, which defines a single method named Dispose() 

    // Dispose() method not only is responsible for releasing the type’s unmanaged resources but can also call Dispose() on any other 
    // contained disposable methods. Unlike with Finalize(), it is perfectly safe to communicate with other managed objects within a Dispose() method.
    // The reason is simple: the garbage collector has no clue about the IDisposable interface and will never call Dispose(). Therefore, 
    // when the object user calls this method, the object is still living a productive life on the managed heap and has access to all 
    // other heap-allocated objects.

    public class DisposableObject : IDisposable {
        public void Dispose() {
            Console.WriteLine("Disposing...");
            Console.Beep();
        }
    }

    // COMBINATION OF FINALIZE AND IDISPOSABLE
    // If the object user does remember to call Dispose(), you can inform the garbage collector to bypass the finalization process by 
    // calling GC.SuppressFinalize(). If the object user forgets to call Dispose(), the object will eventually be finalized and have a 
    // chance to free up the internal resources. The good news is that the object’s internal unmanaged resources will be freed one way or 
    // another.

    public class DisposableAndFinalizedObject : IDisposable {
        ~DisposableAndFinalizedObject() {
            // PERFORM CLEANUP
            Console.Beep();
        }

        public void Dispose() {
            // PERFROM CLEANUP
            GC.SuppressFinalize(this);
        }
    }

    // BEST IMPLEMENTATION
    // The Finalize() and Dispose() methods each have to clean up the same unmanaged resources. This could result in duplicate code, which 
    // can easily become a nightmare to maintain. Ideally, you would define a private helper function that is called by either method.
    // Next, you’d like to make sure that the Finalize() method does not attempt to dispose of any managed objects, while the Dispose() 
    // method should do so. Finally, you’d also like to be certain the object user can safely call Dispose() multiple times without error. 
    // Currently, the Dispose() method has no such safeguards

    public class BestDisposableAndFinalizedObject : IDisposable {
        private bool isDisposed = false;

        public void Dispose() {
            // CALL THE HELPER METHOD
            // TRUE INDICATES DISPOSE INITIATED THE CLEANUP
            CleanUp(true);
            // SUPPRESS FINALIZE
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing) {
            if (!isDisposed) {
                if (disposing) {
                    // DISPOSE MANAGED RESOURCES
                }
                // CLEANUP UN-MANAGED RESOURCES HERE
            }
            isDisposed = true;
        }

        ~BestDisposableAndFinalizedObject() {
            Console.Beep();
            // CALL OUR HELPER FUNCTION
            // FALSE INDICATES GC INITIATED THE CLEANUP
            CleanUp(false);
        }

    }

    public class Program {
        public static void Main(string[] args) {
            Car c = new Car() { PetName = "Zippy", Speed = 100 };
            // HEAR BEEP WHEN APP CLOSES BY PRESSING A KEY

            DisposableObject disposeMe = new DisposableObject();
            disposeMe.Dispose();

            // When you are handling a managed object that implements IDisposable, it is quite common to make use of structured exception 
            // handling to ensure the type’s Dispose() method is called in the event of a runtime exception

            DisposableObject dispose = new DisposableObject();

            try {
                // USE DISPOSE
            } finally {
                dispose.Dispose();
            }


            // To achieve the same result in a much less obtrusive manner, C# supports a special bit of syntax

            using (DisposableObject dsp = new DisposableObject(), dsp2 = new DisposableObject()) {
                // USE dsp, dsp2
            } // AFTER THIS BLOCK Dispose WILL BE CALLED AUTOMATICALLY


            BestDisposableAndFinalizedObject bdsp = new BestDisposableAndFinalizedObject();
            // IF YOU DON'T CALL DISPOSE YOU WILL HEAR BEEP ELSE NOT
            Console.ReadKey();
        }
    }
}