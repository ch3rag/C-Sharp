// Relecting Over Attributes using Late Binding and Dynamic Loading

using System;
using System.Linq;
using System.Reflection;


[assembly: CLSCompliant(true)]
namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            ReflectOnAttributesUsingLateBinding();
            Console.ReadKey();
        }

        private static void ReflectOnAttributesUsingLateBinding() {
            try {
                // LOAD THE ASSEMBLY
                Assembly asm = Assembly.Load("AttributedClassLibrary");

                // GET TYPE OBJECT OF VEHICLEDESCRIPTIONATTRIBUTE
                Type vehicleDescription = asm.GetType("AttributedClassLibrary.VehicleDescriptionAttribute");

                // GET THE INFOMATION ABOUT DESCRIPTION PROPERTY IN VEHICLEDESCRIPTION ATTRIBUTE
                PropertyInfo descProperty = vehicleDescription.GetProperty("Description");

                // GET ALL THE TYPES IN THE ASSEMBLY
                Type[] types = asm.GetTypes();

                // ITERATE OVER TYPES
                foreach (Type t in types) {

                    // SEARCH FOR VEHICLE DESCRIPTION ATTRIBUTE ASSIGNED TO THE CURRENT TYPE
                    object[] objs = t.GetCustomAttributes(vehicleDescription, false);

                    // FOR EACH VEHICLE DESCRIPTION ATTRIBUTE ASSIGNED TO THE CURRENT TYPE
                    foreach (object obj in objs) {
                        // PRINT THE NAME OF THE TYPE AND THE VALUE ASSIGNED TO DESCTIPTION PROPERTY OF THE ATTRIBUTE
                        // PropertyInfo.GetValue() method is used to trigger the property’s accessor

                        Console.WriteLine("{0}: {1}", t.Name, descProperty.GetValue(obj, null));
                    }
                }

            } catch {
                Console.WriteLine("Error!");
            }
        }

    }
}
