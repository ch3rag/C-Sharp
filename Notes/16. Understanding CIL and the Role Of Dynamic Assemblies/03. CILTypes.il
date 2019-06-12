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
        // defining method
        .method public hidebysig static void  MyMethod() cil managed {
            // defining a generic type
            // List<int> myList = new List<int>();
            newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
            // Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            newobj instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string, int32>::.ctor()
            // List<List<int>> myList = new List<List<int>>();
            newobj instance void class [mscorlib]System.Collections.Generic.List`1<class [mscorlib]System.Collections.List`1<int32>>::.ctor()
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

    }

    // shorthand
    .class public sealed enum MyEnumShort {

    }


}

