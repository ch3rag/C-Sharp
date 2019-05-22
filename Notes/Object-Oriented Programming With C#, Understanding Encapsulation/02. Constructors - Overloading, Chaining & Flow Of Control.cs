// CONSTRUCTOR CHAINING & FLOW
// IT IS USED TO REMOVE AMBIGUOUS CODE SUCH AS VALIDATIONS FROM EACH OVERLOADED CONTRUCTOR
// THE CONSTRUCTOR WITH THE HIGHEST NUMBER OF ARGUMENTS IS CONSIDERED AS MASTER CONSTRUCTOR
// THE REST OF THEM PROVIES ARGUMENTS TO THE MASTER CONSTRUCTOR 
// IN THIS CASE ONLY MASTER CONSTRUCTOR NEED TO BE MAINTAINED WHILE THE REST JUST CALL THE MASTER WITH SUPPLIED ARGUMENT

using System;


namespace Notes {

    public class Car {
        public int topSpeed;
        public string driverName;
        public Car() {             // SINCE CUSTOM CONSTRUCTOR ARE DEFINED, THE DEFAULT CONSTRUCTOR NEEDS TO BE DEFINED EXPLICITELY
            Console.WriteLine("public Car()");
        }
        public Car(int topSpeed) 
            : this(topSpeed, "") {
                Console.WriteLine("public Car(int topSpeed)");
        }

        public Car(string driverName) 
            : this(0, driverName) {
                Console.WriteLine("public Car(string dirverName)");
        }
            
        public Car(int topSpeed, string driverName) {
            Console.WriteLine("public Car(int topSpeed, string driverName)");
            if(topSpeed > 10) 
                topSpeed = 10;
            this.topSpeed = topSpeed;
            this.driverName = driverName;
        }
    }
    

    public class Program {
        public static void Main(string[] args) {
            // FLOW OF CONSTRUCTOR
            Car c1 = new Car();
            // public Car()

            Car c2 = new Car(2);
            // public Car(int topSpeed, string driverName)
            // public Car(int topSpeed)

            Car c3 = new Car("Chirag");
            // public Car(int topSpeed, string driverName)
            // public Car(string dirverName)
            
            Car c4 = new Car(12, "Chirag");
            // public Car(int topSpeed, string driverName)

            // FLOW:

            // You create your object by invoking the constructor requiring a single int.

            // This constructor forwards the supplied data to the master constructor and provides
            // any additional startup arguments not specified by the caller.

            // The master constructor assigns the incoming data to the object’s field data.

            // Control is returned to the constructor originally called and executes any remaining
            // code statements.

            Console.ReadKey();
        }
    }
}