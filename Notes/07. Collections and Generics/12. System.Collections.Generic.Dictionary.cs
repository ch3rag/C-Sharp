// System.Collections.Generic.Dictionary<K, V>

using System;
using System.Collections.Generic;


namespace Experiment {

    // Implementing IEqualityComparer
    public class PersonCompareByID : IEqualityComparer <Person> {
        public bool Equals(Person self, Person other) {
            return self.ID.Equals(other.ID);
        }

        public int GetHashCode(Person obj) {
            return obj.ID.GetHashCode();
        }
    }

    public class Person {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }

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

            // Dictionary<K, V>()
            // Dictionary<K, V>(int capacity)
            // Dictionary<K, V>(IEqualityComparer <K> cmp)
            // Dictionary<K, V>(int capacity, IEqualityComparer <K> cmp)
            // Dictionary<K, V>(Dictionary <K, V>)
            // Dictionary<K, V>(Dictionary <K, V>, IEqualityComparer cmp)
            Dictionary<string, Person> persons = new Dictionary<string, Person>();            

            // void Add (K item, V item)
            Person zack = new Person(0, "Zack", 20);
            Person ryan = new Person(2, "Ryan", 24);
            Person cody = new Person(5, "Cody", 18);
            Person lisa = new Person(9, "Lisa", 18);
            Person mars = new Person(3, "Mars", 23);

            persons.Add("Zack", zack);
            persons.Add("Ryan", ryan);
            persons.Add("Cody", cody);
            persons.Add("Lisa", lisa);
            persons.Add("Mars", mars);
            

            // bool ContainsKey(K item)
            // bool ContainsValue(V item)
            Console.WriteLine(persons.ContainsKey("Zack"));
            Console.WriteLine(persons.ContainsValue(zack));

            // Dictionary<K, V>.Enumerator GetEnumerator()

            Dictionary<string, Person>.Enumerator i = persons.GetEnumerator();

            while (i.MoveNext()) {
                Console.WriteLine("{0} --> {1}", i.Current.Key, i.Current.Value.ToString());
            }


            // bool Remove (K value)
            persons.Remove("Zyan");

            // bool TryGetValue(K value, out V value)
            Person person;
            if (persons.TryGetValue("Zack", out person)) {
                Console.WriteLine(person.ToString());
            }
            

            // void Clear();
            persons.Clear();

            Console.ReadKey();
        }   
    }
}