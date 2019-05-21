// REFRENCES OF REFERNCES

// If a reference type is passed by reference, the callee may change the values of the
// object’s state data, as well as the object it is referencing.

// If a reference type is passed by value, the callee may change the values of the object’s
// state data but not the object it is referencing

using System;
namespace Notes {
    class Person {
        string name;
        int age;

        public Person(string name, int age) {
            this.name = name;
            this.age = age;
        }
        public static void ChangeWithoutReference(Person p) {
            // I HAVE COPY OF YOUR REMOTE AND I CAN CHANGE "WHAT IS POINTED" BY YOUR REMOTE
            p.age = 99;             
            // BUT I CAN'T MANIPULATE YOUR REMOTE
            p = new Person("Nickki", 35);
        }

        public static void ChangeWithReference(ref Person p) {
            // I HAVE YOUR REMOTE AND I CAN CHANGE WHAT IS POINTED BY YOUR REMOTE AS WELL AS YOUR REMOTE TOO :)
            p.age = 99;
            p = new Person("Julia", 13);
        }

        public void print() {
            Console.WriteLine("Hey I'am {0} and I' am {1} years old.", this.name, this.age);
        }
    }
    class Program {
        public static void Main(string[] args) {
            Person p1 = new Person("Chirag", 20);
            Person p2 = new Person("Bharat", 21);


            Console.WriteLine("ORIGINAL P1 => ");
            Person.ChangeWithoutReference(p1);
            Console.WriteLine("P1 AFTER CHANGE => ");
            p1.print();
            Console.WriteLine("ORIGINAL P2 => ");
            Person.ChangeWithReference(ref p2);
            Console.WriteLine("P2 AFTER CHANGE => ");
            p2.print();
            Console.ReadLine();
        } 
    }
}

