// ENCAPSULATION EXAMPLE
// EMPLOYEE CLASS

using System;

namespace Notes {

    class Employee {
        private string empName;
        private int empId;
        private float currentPay;
        private int empAge;

        public Employee() { }
        public Employee(String empName, int empId, float currentPay) :this(empName, 0, empId, currentPay) { }
        public Employee(String empName, int empAge, int empId, float currentPay) {
            this.empAge = empAge;
            this.empName = empName;
            this.empId = empId;
            this.currentPay = currentPay;
        }

        public void GiveBonus(float amount) {
            this.currentPay += amount;
        }

        public void DisplayStats() {
            Console.WriteLine("Name: {0}", this.empName);
            Console.WriteLine("Age: {0}", this.empAge);
            Console.WriteLine("Employee ID: {0}", this.empId);
            Console.WriteLine("Pay: {0}", this.currentPay);
        }

        public string GetName() {
            return this.empName;
        }

        public void SetName(string empName) {
            if (empName.Length > 15) {
                Console.WriteLine("Error: The name length exceeds 15 characters.");
            } else {
                this.empName = empName;
            }
        }

    }
    public class Program {
        public static void Main(string[] args) {
            Employee emp = new Employee("Marvin", 456, 30000);
            emp.GiveBonus(1000);
            emp.DisplayStats();

            emp.SetName("Marv");
            Console.WriteLine("Name of the employee: {0}", emp.GetName());

            emp.SetName("Xena the warrior princess");                       // PRINTS ERROR
            Console.WriteLine("Name of the employee: {0}", emp.GetName());  // Marv

            Console.ReadKey();            
        }
    }
}