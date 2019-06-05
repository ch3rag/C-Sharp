// POINTER MANIPUALTION
// * 
// This operator is used to create a pointer variable (i.e., a variable that represents a direct location in memory) indirection.

// & 
// This operator is used to obtain the address of a variable in memory.

// -> 
// This operator is used to access fields of a type that is represented by a pointer

// [] 
// This operator (in an unsafe context) allows you to index the slot pointed to by a pointer variable

// ++, -- 
// In an unsafe context, the increment and decrement operators can be applied to pointer types.

// +, - 
// In an unsafe context, the addition and subtraction operators can be applied to pointer types.

// ==,!=, <, >, <=, => 
// In an unsafe context, the comparison and equality operators can be applied to pointer types.

// stackalloc 
// In an unsafe context, the stackalloc keyword can be used to allocate C# arrays directly on the stack.

// fixed 
// In an unsafe context, the fixed keyword can be used to temporarily fix a variable so that its address can be found.

// In the event that you do decide to make use of this C# language feature, you are required to inform the C# compiler (csc.exe) of your 
// intentions by enabling your project to support “unsafe code.” To do so at the command line, simply supply the following /unsafe flag 
// as an argument:
// csc /unsafe *.cs

// When you want to work with pointers in C#, you must specifically declare a block of “unsafe code” using the unsafe keyword (any code that 
// is not marked with the unsafe keyword is considered “safe” automatically).
// In addition to declaring a scope of unsafe code within a method, you can build structures, classes, type members, and parameters that 
// are “unsafe.” 

using System;

namespace Experiment {

    public class Complex {
        public int Real;
        public int Imaginary;
        public Complex(int real, int imaginary) {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public override string ToString() {
            return string.Format("{0} + ({1}i)", this.Real, this.Imaginary);
        }
    }

    struct Point {
        public int X;
        public int Y;
        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return string.Format("[X: {0}; Y: {1}]", this.X, this.Y);
        }
    }
    // This entire structure is "unsafe" and can be used only in an unsafe context.
    unsafe struct Node {
        public int Value;
        public Node* left;
        public Node* right;
    }

    public struct NodeTwo {
        public int Value;
        // These can be accessed only in an unsafe context!
        public unsafe NodeTwo* left;
        public unsafe NodeTwo* right;
    }


    public class Program {

        public static void Main(string[] args) {

            // No! This is incorrect under C#!
            // int *pi, *pj;
            // Yes! This is the way of C#.
            // int* pi, pj;

            int num = 10;
            int a = 10, b = 20;

            unsafe {
                SquareIntPtr(&num);
                Console.WriteLine("{0:X}", (int)&num);      // PRINTING ADDRESS
                UnsafeSwap(&a, &b);
            }
            Console.WriteLine(a + " " + b);
            Console.WriteLine(num);

            SafeSwap(ref a, ref b);
            Console.WriteLine(a + " " + b);

            StructPointers();
            StackMemoryAllocation();
            ReferencePointers();
            UsingSizeOf();
            Console.ReadKey();
            
        }

        // Methods (static or instance level) may be marked as unsafe as well.
        public static unsafe void SquareIntPtr(int* ptr) {
            *ptr *= *ptr;
        }

        // Unsafe Swap
        public static unsafe void UnsafeSwap(int* a, int* b) {
            int temp = *a;
            *a = *b;
            *b = temp;
        }

        // Safe Swap
        public static void SafeSwap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }

        public static unsafe void StructPointers() {
            Point p = new Point(13, 45);
            Point* ptr = &p;
            Console.WriteLine(ptr->X);
            Console.WriteLine(ptr->Y);
            Console.WriteLine(ptr->ToString());
        }

        public static unsafe void StackMemoryAllocation() {
            // In an unsafe context, you may need to declare a local variable that allocates memory directly from the
            // call stack (and is, therefore, not subject to .NET garbage collection).

            char* ptr = stackalloc char[256];
            for (int i = 0; i < 255; i++) {
                ptr[i] = 'a';
            }

            string s = new String(ptr);
            Console.WriteLine(s);

            // the allocated memory is cleaned up as soon as the allocating method has returned 

        }

        public static unsafe void ReferencePointers() {
            // C# compiler will not allow you to set a pointer to a gc managed variable except in a fixed statement
            Complex c = new Complex(25, -9);
            
            // Fix it so that it will not be GCed while performing operations
            // Properties must not be .NET properties.
            fixed (int* real = &c.Real) {
                Console.WriteLine(*real);
            }
        }

        public static unsafe void UsingSizeOf() {
            // sizeof keyword is used to obtain the size in bytes of an intrinsic data type
            // but not a custom type, unless within an unsafe context. 
            Console.WriteLine(sizeof(int));
            Console.WriteLine(sizeof(Point));
        }
    }
}
