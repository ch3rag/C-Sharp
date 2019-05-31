// The System.Collections.ObjectModel Namespace

// 1. ObservableCollection<T> 
// Represents a dynamic data collection that provides notifications when items get added, when items get removed, or when the whole list is 
// refreshed

// 2. ReadOnlyObservableCollection<T> 
// Represents a read-only version of ObservableCollection<T>

// ObservableCollection<T> class supports an event named CollectionChanged. This event will fire whenever a new item is inserted, a current item is
// removed (or relocated), or the entire collection is modified.

using System;
using System.Collections.ObjectModel;


namespace Experiment {

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

            ObservableCollection<Person> persons = new ObservableCollection<Person>() {
                new Person(12, "Kevin", 27),
                new Person(32, "Felix", 31)
            };

            persons.CollectionChanged += persons_CollectionChanged;            
            persons.Add(new Person(21, "Richard", 24));

            persons.RemoveAt(1);

            Console.ReadKey();
        }

        static void persons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            Console.WriteLine("Action Performed: " + e.Action.ToString());
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                Console.WriteLine("Added Items: ");
                foreach (Person item in e.NewItems) {
                    Console.WriteLine(item.ToString());
                }
            } else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
                Console.WriteLine("Removed Items:");
                foreach (Person item in e.OldItems) {
                    Console.WriteLine(item.ToString());
                }
            }

        }   
    }
}