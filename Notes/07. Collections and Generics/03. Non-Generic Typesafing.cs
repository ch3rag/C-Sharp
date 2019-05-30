// Creating Type Safe Collection Using Non Generic Collections

using System;
using System.Collections;

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

    public class PersonCollection : IEnumerable {
        private ArrayList collection = new ArrayList();

        public int Count {
            get { return collection.Count; }
        }

        public void Add(Person p) {
            collection.Add(p);
        }

        public Person this[int i] {
            get { return (Person)collection[i]; }
        }

        public void RemoveAt(int index) {
            collection.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return collection.GetEnumerator();
        }
    }

    public class Program {
        public static void Main(string[] args) {
            PersonCollection persons = new PersonCollection();
            persons.Add(new Person(1, "Cliff", 30));
            persons.Add(new Person(2, "Daisy", 20));
            persons.Add(new Person(3, "Maxie", 34));
            persons.Add(new Person(4, "Jamey", 25));
            persons.Add(new Person(5, "Grays", 33));

            foreach (Person p in persons) {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }
}