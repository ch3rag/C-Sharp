// RECREATING USING GENERICS

// •	Generics provide better performance because they do not result in boxing or
//      unboxing penalties when storing value types.

// •	Generics are type safe because they can contain only the type of type you specify.

// •	Generics greatly reduce the need to build custom collection types because you
//      specify the “type of type” when creating the generic container.

// Only classes, structures, interfaces, and delegates can be written generically; enum types cannot.

using System;
using System.Collections.Generic;

namespace Experiment {

    public class Person {

        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }

        public Person() { }
        public Person(int id, string name, int age) {
            this.ID = id;
            this.Name = name;
            this.Age = age;
        }

        public override string ToString() {
            return string.Format("ID: {0}, Name: {1}, Age: {2}", this.ID, this.Name, this.Age);
        }
    }

    public class Program {
        public static void Main(string[] args) {
            List<Person> persons = new List<Person>();

            persons.Add(new Person(1, "Cliff", 30));
            persons.Add(new Person(2, "Daisy", 20));
            persons.Add(new Person(3, "Maxie", 34));
            persons.Add(new Person(4, "Jamey", 25));
            persons.Add(new Person(5, "Grays", 33));

            // compile time error
            // persons.Add(new OperatingSystem(PlatformID.Xbox, new Version(1, 2, 3)));

            foreach (Person p in persons) {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }
}