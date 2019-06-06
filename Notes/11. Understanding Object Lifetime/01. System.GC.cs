// System.GC
// AddMemoryPressure(), RemoveMemoryPressure()
// Allows you to specify a numerical value that represents the calling object’s “urgency level” regarding the garbage collection process. 
// Be aware that these methods should alter pressure in tandem and, thus, never remove more pressure than the total amount you have added.

// Collect() 
// Forces the GC to perform a garbage collection. This method has been overloaded to specify a generation to collect, as well as the mode of 
// collection(via the GCCollectionMode enumeration).

// CollectionCount() 
// Returns a numerical value representing how many times a given generation has been swept.

// GetGeneration() 
// Returns the generation to which an object currently belongs.

// GetTotalMemory() 
// Returns the estimated amount of memory (in bytes) currently allocated on the managed heap. A Boolean parameter specifies whether the call 
// should wait for garbage collection to occur before returning.

// MaxGeneration 
// Returns the maximum number of generations supported on the target system. Under Microsoft’s .NET 4.0, there are three possible 
// generations: 0, 1, and 2.

// SuppressFinalize() 
// Sets a flag indicating that the specified object should not have its Finalize() method called.

// WaitForPendingFinalizers()
// Suspends the current thread until all finalizable objects have been finalized. This method is typically called directly after invoking 
// GC.Collect().

using System;


namespace Experiment {

    class Car {
        public string PetName { get; set; }
        public int Speed { get; set; }

        public override string ToString() {
            return string.Format("[Petname: {0}; Speed: {1}]", this.PetName, this.Speed);
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Estimated Bytes on Heap: {0}", GC.GetTotalMemory(false));

            // GENERATIONS ARE ZERO BASED
            Console.WriteLine("Number Of Object Generations: {0}", GC.MaxGeneration + 1);

            Car car = new Car() { PetName = "Zippy", Speed = 100 };

            Console.WriteLine(car);

            Console.WriteLine("Car belongs to generation: {0}", GC.GetGeneration(car));

            // Using GC.Collect(). 
            // Here are two common situations where you might consider interacting with the collection process:
            // •	 Your application is about to enter into a block of code that you don’t want interrupted by a possible garbage collection. 
            // •	 Your application has just finished allocating an extremely large number of objects and you want to remove as much of the 
            // acquired memory as soon as possible.

            // GC.Collect(int generation);
            // GC.Collect(int generation, GCCollectionMode mode);

            // public enum GCCollectionMode {
            //     Default, // Forced is the current default.
            //     Forced, // Tells the runtime to collect immediately!
            //     Optimized // Allows the runtime to determine whether the current time is optimal to reclaim objects.
            // }

            // FORCE GC AND WAIT FOR EACH OBJECT TO BE FINALIZED
            Console.WriteLine("Performing GC....");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            object[] tonsOfObjects = new object[50000];

            for (int i = 0; i < tonsOfObjects.Length; i++) {
                tonsOfObjects[i] = new object();
            }

            GC.Collect(0, GCCollectionMode.Forced);

            Console.WriteLine("Car belongs to generation: {0}", GC.GetGeneration(car));

            if (tonsOfObjects[9000] != null) {
                Console.WriteLine("Generation Of tonsOfObjects[9000] is: {0}", GC.GetGeneration(tonsOfObjects[9000]));
            } else {
                Console.WriteLine("tonsOfObjects[9000] is no longer alive!");
            }

            Console.WriteLine("Generation  0 has been swept {0} times", GC.CollectionCount(0));
            Console.WriteLine("Generation  1 has been swept {0} times", GC.CollectionCount(1));
            Console.WriteLine("Generation  2 has been swept {0} times", GC.CollectionCount(2));

            Console.ReadKey();
        }
    }
}