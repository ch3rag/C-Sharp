// PROGRAM.CS CONTAINS PROGRAM CLASS THAT CONAINS MAIN FUNCTION

using System;
namespace Notes {
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