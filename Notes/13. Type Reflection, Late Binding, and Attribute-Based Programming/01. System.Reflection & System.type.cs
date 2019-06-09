// System.Reflection
// Reflection is the process of runtime type discovery. 
// Using reflection services, you are able to programmatically obtain the same metadata information.

// Assembly 
// This abstract class contains a number of members that allow you to load, investigate, and manipulate an assembly.

// AssemblyName 
// This class allows you to discover numerous details behind an assembly’s identity (version information, culture information, and so forth).

// EventInfo 
// This abstract class holds information for a given event.

// FieldInfo 
// This abstract class holds information for a given field.

// MemberInfo 
// This is the abstract base class that defines common behaviors for the EventInfo, FieldInfo, MethodInfo, and PropertyInfo types.

// MethodInfo 
// This abstract class contains information for a given method.

// Module 
// This abstract class allows you to access a given module within a multifile assembly.

// ParameterInfo 
// This class holds information for a given parameter.

// PropertyInfo 
// This abstract class holds information for a given property.

// -------------------------------------------------------------------------------------------------------------------------------

// System.Type 
// The System.Type class defines a number of members that can be used to examine a type’s metadata, a great number of which return 
// types from the System.Reflection namespace

// IsAbstract          -----|
// IsArray                  |
// IsClass                  |
// IsCOMObject              |
// IsEnum                   |
// IsGenericTypeDefinition  |====> These properties (among others) allow you to discover a number of basic traits about the Type.
// IsGenericParameter       |
// IsInterface              |
// IsPrimitive              |
// IsNestedPrivate          |
// IsNestedPublic           |
// IsSealed                 |
// IsValueType          ----|


// GetConstructors()    ----|       These methods (among others) allow you to obtain an array representing
// GetEvents()              |       the items (interface, method, property, etc.) you are interested in. Each
// GetFields()              |       method returns a related array (e.g., GetFields() returns a FieldInfo
// GetInterfaces()          |       array, GetMethods() returns a MethodInfo array, etc.). Be aware that each of
// GetMembers()             |====>  these methods has a singular form (e.g., GetMethod(), GetProperty(), etc.)
// GetMethods()             |       that allows you to retrieve a specific item by name, rather than an array of
// GetNestedTypes()         |       all related items.
// GetProperties()      ----|

// FindMembers() 
// This method returns a MemberInfo array based on search criteria.

// GetType() 
// This static method returns a Type instance given a string name.

// InvokeMember() 
// This method allows “late binding” for a given item.
