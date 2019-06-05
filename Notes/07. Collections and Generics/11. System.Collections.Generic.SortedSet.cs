// System.Collections.Generic.Queue<T>

using System;
using System.Collections.Generic;


namespace Experiment {

    public class PersonCompareByID : IComparer<Person> {
        public int Compare(Person self, Person other) {
            return self.ID.CompareTo(other.ID);
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
            
            // new SortedSet<Person>()
            // new SortedSet<Person>(IEnumerable <T> col)
            // new SortedSet<Person>(IComparer <T> cmp)
            // new SortedSet<Person>(IEnumerable <T> col, IComparer <T> cmp)

            SortedSet<Person> persons = new SortedSet<Person> (new Person[] {
                new Person(1, "Jane", 20),
                new Person() { ID = 24, Name = "Alex", Age = 23 }
            }, new PersonCompareByID());

            PrintSortedSet<Person>(persons);

            // void Add(T item)
            Person p3 = new Person(0, "Jake", 29);
            Person p4 = new Person(6, "Natasha", 39);
            Person p5 = new Person(8, "Blake", 32);
            persons.Add(p3);
            persons.Add(p4);
            persons.Add(p5);

            Person p1 = new Person(7, "Ryan", 19);
            Person p2 = new Person(12, "Zack", 39);
            persons.Add(p1); persons.Add(p1); persons.Add(p2);     // Only Once Added

            PrintSortedSet<Person>(persons);
            
            // bool Contains()
            Console.WriteLine(persons.Contains(p1));     // true       
            
            // ExpectWith(IEnumerable <T> col)
            // Remove all the items from the current set that are in the passed collection
            persons.ExceptWith(new Person[] { p1, p2, new Person(2, "Zippy", 23) });        // removes Ryan and Zack
            PrintSortedSet<Person>(persons);
            

            // SortedSet<T> GetViewBetween(T lower, T Upper)
            SortedSet<Person> slice = persons.GetViewBetween(p3, p4);  
            PrintSortedSet<Person>(slice);

            // IEnumerator <T> GetEnumerator()
            IEnumerator<Person> i = persons.GetEnumerator();
            
            while (i.MoveNext()) {
                Console.WriteLine(i.Current.ToString());
            }

            // void IntersectWith(IEnumerable <T> col)
            slice.IntersectWith(new Person[] { p4  });
            Console.WriteLine();
            PrintSortedSet<Person>(slice);

            
            // CopyTo(T[] arr)
            // CopyTo(T[] arr, int startIndexInArray)
            // CopyTo(T[] arr, int startIndexInArray, int howMany)
            Person[] personArray = new Person[5];
            persons.CopyTo(personArray, 1, 2);
            

            // Other
            // bool IsProperSubsetOf(IEnumerable <T> col)
            // bool IsProperSupersetOf(IEnumerable <T> col)
            // bool IsSubsetOf(IEnumerable <T> col)
            // bool IsSupersetOf(IEnumerable <T> col)
            // bool Overlaps(IEnumerable <T> col)
            // bool Remove(T item)
            // bool SetEquals (SortedSet<T> other)
            // void UnionWith (IEnumerable<T> other)
            
            // IEnumerable<T> Reverse() 

            IEnumerable<Person> revPersons = persons.Reverse();

            foreach (Person p in revPersons) Console.WriteLine(p.ToString());

            // Count
            Console.WriteLine(persons.Count);

            // Min 
            Console.WriteLine(persons.Min.ToString());

            // Max
            Console.WriteLine(persons.Max.ToString());


            // void Clear();
            persons.Clear();

            // TO BE LEARNED
            // IEqualityComparer <SortedSet<T>> static CreateSetComparer()
            // IEqualityComparer <SortedSet<T>> static CreateSetComparer(IEqualityComparer c)
            
            Console.ReadKey();
        }   

        public static void PrintSortedSet<T>(SortedSet<T> set) {
            foreach (T item in set) {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}