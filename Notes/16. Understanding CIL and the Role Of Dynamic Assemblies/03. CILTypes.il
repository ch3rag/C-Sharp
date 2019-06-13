// define external assemblies
.assembly extern mscorlib {
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
    .ver 4:0:0:0
}

.assembly CILTypes {
    .ver 1:0:0:0
}

.module CILTypes.dll

// defining namespace
.namespace MyNamespace {
    // defining classes
    .class public MyBaseClass {
        // defined object level fields
        .field private string stringField = "hello!"
        .field private int32 intField = int32(34)

        // defining constructors
        // instance-level constructors are represented using the .ctor token & a static-level constructor is expressed via .cctor
        .method public hidebysig specialname rtspecialname instance void .ctor(string s, int32 i) cil managed {
            // code
        }

        // defining properties
        .property instance string TheString() {
            .get instance string MyNamespace.MyBaseClass::get_TheString()
            .set instance void MyNamespace.MyBaseClass::set_TheString(string)
        }

        .method public hidebysig specialname instance string get_TheString() cil managed {

        }

        .method public hidebysig specialname instance void set_TheString(string 'value') cil managed {

        }

        // defining static method
        .method public hidebysig static void  MyStaticMethod() cil managed {
            // defining a generic type
            // List<int> myList = new List<int>();
            newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
            // Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            newobj instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string, int32>::.ctor()
            // List<List<int>> myList = new List<List<int>>();
            newobj instance void class [mscorlib]System.Collections.Generic.List`1<class [mscorlib]System.Collections.List`1<int32>>::.ctor()
        }

        // method that takes int32 (by value), int32 (reference), a ArrayList, and a out parameter (int32).
        .method public hidebysig static void MyMethod(int32 inputInt, int32& refInt, class [mscorlib]System.Collections.ArrayList ar, [out] int32& outputInt) cil managed {
            // .maxstack
            // .maxstack establishes the maximum number of variables that may be pushed onto the stack during the execution of the method.
            // default value is 8
            .maxstack 1
            ldstr "Hello World!"
            call void [mscorlib]System.Console.WriteLine(string)
            ret
        }

        .method public hidebysig static void MyLocalVariables() cil managed {
            // local variables
            .maxstack 8

            // define three local variables
            .locals init([0] string str, [1] int32 myInt, [2] object myObj)

            // load string onto VES(Virtual Execution Stack)
            ldstr "CIL Code is fun!"

            // pop off the value at the top of the stack and store it in local variable 0
            stloc.0

            // load a constant of type int32(i4)
            ldc.i4.s 33
            stloc.1

            // create a new object and place in onto the stack
            newobj instance void [mscorlib]System.Object::.ctor()
            stloc.2

            ret
        }

        .method public hidebysig static int32 Add(int32 a, int32 b) cil managed {
            .maxstack 2
            
            ldarg.0 // load a onto the stack
            ldarg.1 // load b onto the stack
            add     // add  two values on top of the stack i.e. a, b and store the sum onto the stack
            ret     // pop the sum and return it to the caller
            // if add method was non-static then argument 0 represents this pointer and arg1, args2 represent a, b respectively
        }

        // Creating Loops
        .method public hidebysig static void CountToTen() cil managed {
            .maxstack 2
            .locals init ([0] int32 i)
            IL_0000: ldc.i4.0
            IL_0001: stloc.0
            IL_0002: br.s IL_0008
            IL_0004: ldloc.0        // load locals [0] onto the stack
            IL_0005: ldc.i4.1       // load 1 onto the stack
            IL_0006: add            // add
            IL_0007: stloc.0        // store at locals [0]
            IL_0008: ldloc.0        // load locals[0] onto the stack
            IL_0009: ldc.i4.s 10    // load 10 onto the stack
            IL_000b: blt.s IL_0004  // if less then jump to IL_0004
            IL_000d: ret    
        } 
    }

    // defining interfaces
    .class public interface IMyInterface { }

    // inheriting class and implementing interfaces
    .class public MyDerivedClass extends MyNamespace.MyBaseClass implements MyNamespace.IMyInterface {

    }

    // extending interfaces
    // unlike C#, in CIL interface are extended using implements keyword again
    .class public interface IExtendedInterface implements MyNamespace.IMyInterface {

    }

    // defining structs
    // must be sealed and extends System.ValueType
    .class public sealed MyStruct extends [mscorlib]System.ValueType { 
        
    }

    // Shorthand notation for declaring a structure using value attribue
    .class public sealed value MyStructShort { 

    }

    // defining Enums
    .class public sealed MyEnum extends [mscorlib]System.Enum {
        // defining static fields
        .field public static literal valuetype MyNamespace.MyEnum A = in32(0)
        .field public static literal valuetype MyNamespace.MyEnum B = int32(1)
        .field public static literal valuetype MyNamespace.MyEnum C = int32(2)
    }

    // shorthand
    .class public sealed enum MyEnumShort {

    }
}