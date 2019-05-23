// ENCAPSULATION EXAMPLE(USING .NET PROPERTIES)
// EMPLOYEE CLASS

using System;

namespace Notes {

    class Employee {

        private string empName;
        private int empId;
        private float currentPay;
        private int ssn;

        // USING AUTOMATIC PROPERTY
        public int Age { get; set; }

        // STATIC MEMBER
        private static int empCount;
        
        static Employee() {

            // INITIALLY COMPANY HAS 1000 EMPLOYEES
            Count = 1000;
        }

        public Employee() { }
        public Employee(String empName, int empId, float currentPay, int ssn) :this(empName, 0, empId, currentPay, ssn) { }
        public Employee(String empName, int empAge, int empId, float currentPay, int ssn) {

            // IN ORDER TO VALIDATE THESE VALUES
            // ASSIGN THEM TO PROPERTY NAMES NOT TO RAW VARIABLES
            // this.empAge = empAge;
            // this.empName = empName;
            // this.empId = empId;

            this.Name = empName;
            this.Age = empAge;
            this.ID = empId;
            this.Pay = currentPay;
            
            Count++;

            // THIS DOES NOT HAVE MUTATOR PROPERTY SO IT CAN BE ASSIGNED DIRECTLY
            this.ssn = ssn;
        }

        public void GiveBonus(float amount) {
            // USING PROPERTIES EVERYWHERE RESULT IN VALIDATION AT EACH STEP
            // THUS CHANGE THIS
            // this.currentPay += amount;
            // TO THIS
            Pay += amount;
        }

        public void DisplayStats() {
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Employee ID: {0}", this.ID);
            Console.WriteLine("Pay: {0}", this.Pay);
            Console.WriteLine("Social Security Number: {0}", this.SocialSecurityNumber);
        }

        // Within a set scope of a property, you use a token named value, which is used to represent the incoming value used to assign the 
        // property by the caller.

        public string Name {
            get {
                return this.empName;
            }
            set {

                // THIS CODE WILL NOT RUN WHEN VALUES ARE ASSIGNED USING CONSTRUCTOR UNLESS THE VALUE IS ASSINED TO "Name" PROPERTY RATHER 
                // THAN TO this.empName
                if (value.Length > 15) {
                    Console.WriteLine("Error: The name length exceeds 15 characters.");
                } else {
                    this.empName = value;
                }
            }
        }

        public int ID {
            get { return this.empId; }
            set { this.empId = value; }
        }

        // DEFINED ABOVE USING AUTOMATIC PROPERTY
        // public int Age {
        //     get { return this.empAge; }
        //     set { this.empAge = value; }
        // }

        public float Pay {
            get { return this.currentPay; }
            set { this.currentPay = value; }
        }

        // WE CAN ALSO CREATE READ ONLY PROPERTIES BY OMITTING MUTATOR AND INITIALIZING ONLY ONCE IN THE CONSTRUCTOR
        // Since C# version 6, it is possible to define a “read-only automatic property” by omitting the set scope.
        // However, it is not possible to define a write-only property. 
        
        public int SocialSecurityNumber {
            get { return this.ssn;  }
        }

        // STATIC ACCESSOR AND MUTATOR

        public static int Count {
            get { return empCount; }
            set { empCount = value; }
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Employee emp = new Employee("Marvin", 456, 30000, 121);
            
            emp.GiveBonus(1000);
            emp.DisplayStats();

            emp.Name = "Marv";
            Console.WriteLine("Name of the employee: {0}", emp.Name);

            emp.Name = "Xena the warrior princess";                       // PRINTS ERROR
            Console.WriteLine("Name of the employee: {0}", emp.Name);     // Marv

            emp.Age = 35;
            emp.Age++;      // WE CAN USE TRADITIONAL C# OPERATORS
            emp.DisplayStats();

            Console.WriteLine("Company Has {0} Employees.", Employee.Count);
            Console.ReadKey();            
        }
    }
}