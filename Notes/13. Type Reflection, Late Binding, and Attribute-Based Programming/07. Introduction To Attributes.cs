// Attributes
// Attributes are code annotations that can be applied to a given type (class, interface, structure, etc.), member (property, method, 
// etc.), assembly, or module.
// NET attributes are class types that extend the abstract System.Attribute base class.

// [CLSCompliant] 
// Enforces the annotated item to conform to the rules of the Common Language Specification (CLS). Recall that CLS-compliant types 
// are guaranteed to be used seamlessly across all .NET programming languages.

// [DllImport] 
// Allows .NET code to make calls to any unmanaged C- or C++-based code library, including the API of the underlying operating 
// system. Do note that [DllImport] is not used when communicating with COM-based software.

// [Obsolete] 
// Marks a deprecated type or member. If other programmers attempt to use such an item, they will receive a compiler warning 
// describing the error of their ways.

// [Serializable] 
// Marks a class or structure as being “serializable,” meaning it is able to persist its current state into a stream.

// [NonSerialized] 
// Specifies that a given field in a class or structure should not be persisted during the serialization process.

// [ServiceContract] 
// Marks a method as a contract implemented by a WCF service
