// GENERIC INTERFACES
// IComparable <T>
// TO MAKE CUSTOM TYPE ABLE TO GET SORTED USING System.Array.Sort()

using System;
using System.Collections;

namespace Experiment {

    // SPECIFYING TYPE IN INTERFACE
    public class Employee : IComparable<Employee> {
        public string Name { get; set; }
        public int ID { get; set; }
        public Employee(string name, int id) {
            this.Name = name;
            this.ID = id;
        }

        // NOTE THE SYNTAX
        int IComparable<Employee>.CompareTo(Employee other) {
            if (this.ID > other.ID) {
                return 1;
            } else if (this.ID < other.ID) {
                return -1;
            } else {
                return 0;
            }
        }


        public override string ToString() {
            return String.Format("ID: {0}, Name: {1}", this.ID, this.Name);
        }
    }

    class Program {
        static void Main(string[] args) {
            Employee[] employees = {
                                       new Employee("Zippy", 21),
                                       new Employee("Sara", 32),
                                       new Employee("Bob", 1),
                                       new Employee("David", 27),
                                       new Employee("Alex", 4)
                                   };

            System.Array.Sort(employees);

            foreach (Employee e in employees) {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
