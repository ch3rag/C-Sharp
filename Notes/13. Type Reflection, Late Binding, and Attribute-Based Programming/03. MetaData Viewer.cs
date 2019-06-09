// MetaData Viewer


using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Experiment {
    public class SportsCar : ICloneable {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public bool isDead = false;

        public SportsCar(string petName, int currentSpeed, int maxSpeed) {
            this.PetName = petName;
            this.CurrentSpeed = currentSpeed;
            this.MaxSpeed = maxSpeed;
        }
        public object Clone() {
            return this.MemberwiseClone();
        }
    }
    public class Program {
        public static void Main(string[] AssemblyLoadEventArgs) {
            PrintHeading("MetaViewer", ConsoleColor.Red);
            string typeName = "";
            do {
                Console.Write("\nEnter Type Name To Evaluate(Quit to exit): ");
                typeName = Console.ReadLine();

                if (typeName.Equals("Quit", StringComparison.OrdinalIgnoreCase)) {
                    return;
                }

                try {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine();
                    ListStats(t);
                    ListFields(t);
                    ListProperties(t);
                    ListMethods(t);
                    ListInterfaces(t);
                } catch {
                    Console.WriteLine("Invalid Type!");
                }
            } while (true);

            // Reflecting on Generic Types
            // When you call Type.GetType() to obtain metadata descriptions of generic types, you must make use of a special syntax 
            // involving a “backtick” character (`) followed by a numerical value that represents the number of type parameters the 
            // type supports.
            // System.Collections.Generic.List`1
            // System.Collections.Generic.Dictionary`2

        }

        public static void ListMethods(Type t) {
            PrintHeading("Method Information", ConsoleColor.Yellow);
            System.Reflection.MethodInfo[] methods = t.GetMethods();
            (from method in methods select method).ToList().ForEach(x => {

                string returnType = x.ReturnType.Name;
                string parameters = parameters = (from parameter in x.GetParameters() select parameter).Aggregate("(", (i, c) => i + c.ParameterType + " " + c.Name + ", ");
                parameters = parameters.EndsWith("(") ? parameters : parameters = parameters.Substring(0, parameters.Length - 2);
                parameters += ")";

                Console.WriteLine("{0} {1} {2}", returnType, x.Name, parameters);
            });


            Console.WriteLine();
        }

        public static void ListFields(Type t) {
            PrintHeading("Field Information", ConsoleColor.Red);
            System.Reflection.FieldInfo[] fields = t.GetFields();
            (from field in fields select field.Name).ToList().ForEach(x => Console.WriteLine("--> " + x));
            Console.WriteLine();
        }

        public static void ListProperties(Type t) {
            PrintHeading("Property Information", ConsoleColor.Green);
            System.Reflection.PropertyInfo[] properties = t.GetProperties();
            (from property in properties select property.Name).ToList().ForEach(x => Console.WriteLine("--> " + x));
            Console.WriteLine();
        }

        public static void ListInterfaces(Type t) {
            PrintHeading("Interface Information", ConsoleColor.Magenta);
            System.Type[] interfaces = t.GetInterfaces();
            (from i in interfaces select i.Name).ToList().ForEach(x => Console.WriteLine("--> " + x));
            Console.WriteLine();
        }

        public static void ListStats(Type t) {
            PrintHeading("Misc Information", ConsoleColor.White);
            Console.WriteLine("Base Class: {0}", t.BaseType);
            Console.WriteLine("Is Abstract?: {0}", t.IsAbstract);
            Console.WriteLine("Is Sealed?: {0}", t.IsSealed);
            Console.WriteLine("Is Generic?: {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is Class?: {0}", t.IsClass);
        }

        public static void PrintHeading(string heading, ConsoleColor color) {
            ConsoleColor temp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine("********* " + heading + " *********");
            Console.ForegroundColor = temp;
        }
    }
}
