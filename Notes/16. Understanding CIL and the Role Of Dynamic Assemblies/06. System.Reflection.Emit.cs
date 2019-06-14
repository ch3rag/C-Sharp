// Creating Assemblies On The Fly Using System.Reflection.Emit

// AssemblyBuilder
// Used to create an assembly (*.dll or *.exe) at runtime. *.exes must call the ModuleBuilder.SetEntryPoint() method to set the 
// method that is the entry point to the module. If no entry point is specified, a *.dll will be generated.

// ModuleBuilder 
// Used to define the set of modules within the current assembly. 

// EnumBuilder 
// Used to create a .NET enumeration type.

// TypeBuilder 
// May be used to create classes, interfaces, structures, and delegates within a module at runtime.

// MethodBuilder LocalBuilder, PropertyBuilder, FieldBuilder, ConstructorBuilder, CustomAttributeBuilder, ParameterBuilder, EventBuilder
// Used to create type members (such as methods, local variables, properties, constructors, and attributes) at runtime.

// ILGenerator
// Emits CIL opcodes into a given type member.

// OpCodes 
// Provides numerous fields that map to CIL opcodes. This type is used in conjunction with the various members of 
// System.Reflection.Emit.ILGenerator.

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

// System.Reflection.Emit.ILGenerator
// You receive an ILGenerator type by calling specific methods of the builder-centric types, i.e,

// ConstructorBuilder myCtorBuilder = new ConstructorBuilder(args)
// ILGenerator myCILGen = myCtorBuilder.GetILGenerator()

// METHOD LIST

// BeginCatchBlock()            Begins a catch block
// BeginExceptionBlock()        Begins an exception scope for an exception
// BeginFinallyBlock()          Begins a finally block
// BeginScope()                 Begins a lexical scope
// DeclareLocal()               Declares a local variable
// DefineLabel()                Declares a new label
// Emit()                       Is overloaded numerous times to allow you to emit CIL opcodes
// EmitCall()                   Pushes a call or callvirt opcode into the CIL stream
// EmitWriteLine()              Emits a call to Console.WriteLine() with different types of values
// EndExceptionBlock()          Ends an exception block
// EndScope()                   Ends a lexical scope
// ThrowException()             Emits an instruction to throw an exception
// UsingNamespace()             Specifies the namespace to be used in evaluating locals and watches for the current active lexical scope




