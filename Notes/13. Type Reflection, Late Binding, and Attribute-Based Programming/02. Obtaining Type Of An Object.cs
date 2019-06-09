// Obtaining a Type Reference

using System;

namespace Experiment {
    public class SportsCar {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public SportsCar(string petName, int currentSpeed, int maxSpeed) {
            this.PetName = petName;
            this.CurrentSpeed = currentSpeed;
            this.MaxSpeed = maxSpeed;
        }
    }
    public class Program {
        public static void Main(string[] AssemblyLoadEventArgs) {
            // Using System.Object.GetType();
            // This approach will work only if you have compile-time knowledge of the type you want to reflect over (SportsCar in 
            // this case) and currently have an instance of the type in memory.

            SportsCar sc = new SportsCar("Buggati", 10, 300);
            Type type1 = sc.GetType();

            // Using typeof Operator
            // The typeof operator is helpful in that you do not need to first create an object instance to extract type information. 
            // However, your codebase must still have compile-time knowledge of the type you are interested in examining, as typeof 
            // expects the strongly typed name of the type.

            Type type2 = typeof(SportsCar);


            // Using System.Type.GetType();
            // To obtain type information in a more flexible manner, you may call the static GetType() member of the System.Type 
            // class and specify the fully qualified string name of the type you are interested in examining. Using this approach, 
            // you do not need to have compile-time knowledge of the type you are extracting metadata from, given that Type.GetType()
            // takes an instance of the omnipresent System.String

            // The Type.GetType() method has been overloaded to allow you to specify two Boolean parameters, one of which controls 
            // whether an exception should be thrown if the type cannot be found, and the other of which establishes the case sensitivity of the string.

            Type type3 = Type.GetType("Experiment.SportsCar", false, true);

            if (type1 == type2 && type2 == type3) {
                Console.WriteLine("All Types Are Same!");
            }

            Console.ReadKey();
        }
    }
}
