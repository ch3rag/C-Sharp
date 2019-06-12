# Common Intermediate Language


Token set understood by the CIL compiler is subdivided into the following three broad categories based on semantics:
* CIL directives
* CIL attributes
* CIL operation codes (opcodes)

## Roles
#### CIL Directives
CIL tokens that are used to describe the overall structure of a .NET
assembly are called directives. CIL directives are used to inform the CIL compiler how to define the namespaces(s), type(s), and member(s) that will populate an assembly. Directives are represented syntactically using a single dot (.) prefix (e.g., .namespace, .class .publickeytoken, .method, .assembly, etc.)

#### CIL Attributes
CIL directives can be further specified with various CIL attributes to qualify how a directive should be processed. For example, the .class directive can be adorned with the public attribute

####  CIL Opcodes
Opcodes provide the type’s implementation logic.

--- 

### Dumping CIL Using ildasm.exe
Open *.exe with ildasm.exe and, using the File ➤ Dump menu option, save the raw CIL code to a new *.il file.

### Compiling CIL Code Using ilasm.exe
You can compile a new .NET assembly (*.li) using the ilasm.exe (CIL compiler) utility.

```
ilasm -exe MyAssembly.il -output=MyApplication.exe
```
### Verifying Assembly using peverify.exe
When you are building or modifying assemblies using CIL code, it is always advisable to verify that the compiled binary image is a well-formed .NET image using the peverify.exe command-line tool, like so:
```
peverify NewAssembly.exe
```
This tool will examine all opcodes within the specified assembly for valid CIL code. For example, in terms of CIL code, the evaluation stack must always be empty before exiting a function. If you forget to pop off any remaining values, the ilasm.exe compiler will still generate a compiled assembly (given that compilers are concerned only with syntax). peverify.exe, on the other hand, is concerned with semantics. If you did forget to clear the stack before exiting a given function, peverify.exe will let you know before you try running your code base.

---
### Defining Assemblies
###### External Assemblies
```
.assembly extern <Friendly Name> {
    .publickeytoken = (<token value>)
    .ver major:minor:patch:revision
}
```
Example:
```
.assembly extern mscorlib {
    .publickeytoken =  (B7 7A 5C 56 19 34 E0 89)
    .ver 4:0:0:0
}
```
###### Defining Current Assembly
```
.assembly <Assembly Name> {
    <Assembly Level Directives>
}
```
Example
```
.assembly MyAssembly {
    .ver 1:0:0:0
    .module MyAssembly.exe
}
```
###### Additional Assembly-Centric Directives
* **.mresources** 
 If your assembly uses internal resources (such as bitmaps or string tables), this directive is used to identify the name of the file that contains the resources to be embedded.
* **.subsystem**
 This CIL directive is used to establish the preferred UI that the assembly wants to execute within. For example, a value of 2 signifies that the assembly should run within a GUI application, whereas a value of 3 denotes a console executable.

 ---
 ### Defining Namespaces
 ```
.namespace <Namespace Name> {
    // CODE
}
 ```

---
### Defining Types
##### Classes
```
.namespace MyNameSpace {
    .class <attributes> <Classname> {
        // CODE
    }
}
```
###### Extending
```
.namespace MyNameSpace {
    .class public MyBaseClass { }
    .class public MyDerivedClass extends MyNameSpace.MyBaseClass { }
}
```
---
#### Various Attributes Used in Conjunction with the .class Directive
* ***public, private, nested assembly, nested famandassem, nested family, nested famorassem, nested public, nested private***
CIL defines various attributes that are used to specify the visibility of a given type. As you can see, raw CIL offers numerous possibilities other than those offered by C#. Refer to ECMA 335 for details if you are interested.

* ***abstract, sealed*** 
 These two attributes may be tacked onto a .class directive to define an abstract class or sealed class, respectively.

* ***auto, sequential, explicit*** 
 These attributes are used to instruct the CLR how to lay out field data in memory. For class types, the default layout flag (auto) is appropriate. Changing this default can be helpful if you need to use P/Invoke to call into unmanaged C code.

* ***extends, implements*** 
 These attributes allow you to define the base class of a type (via extends) or implement an interface on a type (via implements).

