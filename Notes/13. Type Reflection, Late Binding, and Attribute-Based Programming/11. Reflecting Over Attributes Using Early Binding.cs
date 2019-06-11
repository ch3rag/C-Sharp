// REFLECTING OVER ATTRIBUTES USING EARLY BINDING
// REQUIRES AttributedClassLibrary
using System;
using System.Linq;
using System.Reflection;
using AttributedClassLibrary;

[assembly: CLSCompliant(true)]
namespace Experiment {

    public class Program {
        public static void Main(string[] args) {
            ReflectOnAttributesUsingEarlyBinding();
            Console.ReadKey();
        }

        private static void ReflectOnAttributesUsingEarlyBinding() {
            (from attribute in typeof(Winnebago).GetCustomAttributes(false) where (attribute is VehicleDescriptionAttribute) select attribute).ToList().ForEach(x => Console.WriteLine(((VehicleDescriptionAttribute)x).Description));
        }

    }
}
