using System;

namespace Employees {
    public abstract partial class Employee {

        public virtual void GiveBonus(float amount) {
            Pay += amount;
        }

        public virtual void DisplayStats() {
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Employee ID: {0}", this.ID);
            Console.WriteLine("Pay: {0}", this.Pay);
            Console.WriteLine("Social Security Number: {0}", this.SocialSecurityNumber);
        }

        public double GetBenefitCost() {
            return this.empBenefits.ComputePayDeduction();
        }

        public string Name {
            get {
                return this.empName;
            }
            set {
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

        public float Pay {
            get { return this.currentPay; }
            set { this.currentPay = value; }
        }

        public int Age {
            get { return this.age; }
            set { this.age = value; }
        }

        public int SocialSecurityNumber {
            get { return this.ssn; }
        }

        public BenefitPackage Benefits {
            get { return this.empBenefits; }
            set { this.empBenefits = value; }
        }

    }
}