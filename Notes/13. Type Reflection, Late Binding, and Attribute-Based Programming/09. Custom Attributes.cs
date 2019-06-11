// CUSTOM ATTRIBUTES

using System;

namespace AttributedClassLibrary {
    // It is considered a .NET best practice to design all custom attributes as sealed
    // VS provides a Attribute snippnet to quickly generate custom attributes

    // If you want to constrain the scope of a custom attribute, you will need to apply the [AttributeUsage] attribute on the 
    // definition of your custom attribute.The [AttributeUsage] attribute allows you to supply any combination of values (via
    // an OR operation) from the AttributeTargets enumeration

    // This enumeration defines the possible targets of an attribute.
    // public enum AttributeTargets {
    //     All, Assembly, Class, Constructor,
    //     Delegate, Enum, Event, Field, GenericParameter,
    //     Interface, Method, Module, Parameter,
    //     Property, ReturnValue, Struct
    // }

    // [AttributeUsage] also allows you to optionally set a named property (AllowMultiple) that specifies whether the attribute 
    // can be applied more than once on the same item (the default is false). As well, [AttributeUsage] allows you to establish 
    // whether the attribute should be inherited by derived classes using the Inherited named property (the default is true).

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class VehicleDescriptionAttribute : Attribute {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string description) {
            this.Description = description;
        }
        public VehicleDescriptionAttribute() { }
    }

    [SerializableAttribute]
    [VehicleDescriptionAttribute(Description = "My Rocking Harley")]
    public class Motorcycle {

    }

    [Serializable]
    [Obsolete("Use another vehicle")]
    [VehicleDescription("The old gray mare, she ain't what she used to be...")]
    public class HorseAndBuggy {

    }

    [Serializable, VehicleDescription("A very long, slow, but feature rich auto")]
    public class Winnebago {

    }
}