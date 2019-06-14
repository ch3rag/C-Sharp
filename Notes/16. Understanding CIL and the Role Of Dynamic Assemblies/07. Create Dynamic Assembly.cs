
/*                                                         |====> Static Methods
 *                                                         |====> Instance Methods
 *                                  |==> Class ==========> |====> Constructors
 *                  |==> Module ===>|                      |====> Propertites
 *                  |               |==> Interface         |====> Fields
 *  Assembly ======>|
 *                  |               |==> Enumerations
 *                  |==> Module ===>|
 *                                  |==> Structs
 */

// This class will be created at runtime using System.Reflection.Emit.
// public class HelloWorld {
//     private string theMessage;
//     HelloWorld() { }
//     HelloWorld(string s) { theMessage = s; }
//     public string GetMsg() { return theMessage; }
//     public void SayHello() {
//         System.Console.WriteLine("Hello from the HelloWorld class!");
//     }
// }



using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            AppDomain current = AppDomain.CurrentDomain;
            CreateDynamicAssembly(current);
            Console.WriteLine("Assembly created successfully!");

            Assembly asm = Assembly.Load("MyAssembly");
            Console.WriteLine("Loaded created assembly.");

            Type hello = asm.GetType("MyAssembly.HelloWorld");
            Console.Write("Enter a message to pass HelloWorld class: ");
            string message = Console.ReadLine();

            dynamic obj = Activator.CreateInstance(hello, new object[] { message });

            obj.SayHello();

            Console.ReadKey();
        }

        private static void CreateDynamicAssembly(AppDomain domain) {

            //  create a assembly name
            AssemblyName assemblyName = new AssemblyName("MyAssembly");
            assemblyName.Version = new Version(1, 0, 0, 0);

            // define a new assembly in current app domain

            // AssemblyBuilderAccess Enumeration
            // ReflectionOnly           Represents that a dynamic assembly can only be reflected over 
            // Run                      Represents that a dynamic assembly can be executed in memory but not saved to disk
            // RunAndSave               Represents that a dynamic assembly can be executed in memory and saved to disk
            // Save                     Represents that a dynamic assembly can be saved to disk but not executed in memory

            AssemblyBuilder assembly = domain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);



            // define a new module in assembly
            // Given that the assembly is a singlefile unit, you need to define only a single module. If you were to build a 
            // multifile assembly using the DefineDynamicModule() method, you would specify an optional second parameter that 
            // represents the name of a given module (e.g., myMod.dotnetmodule).
            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            // define a public class HelloWorld in the module

            // ModuleBuilder Useful Methods
            // DefineEnum()                 Used to emit a .NET enum definition
            // DefineResource()             Defines a managed embedded resource to be stored in this module
            // DefineType()                 Allows you to define value types, interfaces, & class, delegates

            // TypeAttributes
            // Abstract                     Specifies that the type is abstract
            // Class                        Specifies that the type is a class
            // Interface                    Specifies that the type is an interface
            // NestedAssembly               Specifies that the class is nested with assembly visibility and is thus accessible only by methods within its assembly
            // NestedFamANDAssem            Specifies that the class is nested with assembly and family visibility and is thus accessible only by methods lying in the intersection of its family and assembly
            // NestedFamily                 Specifies that the class is nested with family visibility and is thus accessible only by methods within its own type and any subtypes
            // NestedFamORAssem             Specifies that the class is nested with family or assembly visibility and is thus accessible only by methods lying in the union of its family and assembly
            // NestedPrivate                Specifies that the class is nested with private visibility
            // NestedPublic                 Specifies that the class is nested with public visibility
            // NotPublic                    Specifies that the class is not public
            // Public                       Specifies that the class is public
            // Sealed                       Specifies that the class is concrete and cannot be extended
            // Serializable                 Specifies that the class can be serialized

            TypeBuilder helloWorldClass = module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);


            // define a private string member
            FieldBuilder msgField = helloWorldClass.DefineField("theMessage", typeof(string), FieldAttributes.Private);

            // create a custom constructor
            Type[] constructorArgs = new Type[1];
            constructorArgs[0] = typeof(string);
            ConstructorBuilder constructor = helloWorldClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, constructorArgs);

            ILGenerator constructorIL = constructor.GetILGenerator();

            constructorIL.Emit(OpCodes.Ldarg_0);
            Type objectType = typeof(object);

            ConstructorInfo superConstructor = objectType.GetConstructor(new Type[0]);

            constructorIL.Emit(OpCodes.Call, superConstructor);
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);


            // create a default constructor 
            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            // create GetMsg() method
            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);


            // create SayHello Method

            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Hello from Hello World Class");
            methodIL.Emit(OpCodes.Ret);

            // "Bake" the HelloWorld Class
            helloWorldClass.CreateType();
            Console.WriteLine("Assembly created!! Now saving...");
            assembly.Save("MyAssembly.dll");
        }
    }
}