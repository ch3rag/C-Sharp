using System;

namespace Notes {
    public partial class Employee {
        public void GiveBonus(float amount) {
            // USING PROPERTIES EVERYWHERE RESULT IN VALIDATION AT EACH STEP
            // THUS CHANGE THIS TO
            // this.currentPay += amount;
            // THIS
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
            get { return this.ssn; }
        }

        // STATIC ACCESSOR AND MUTATOR

        public static int Count {
            get { return empCount; }
            set { empCount = value; }
        }
    }
}