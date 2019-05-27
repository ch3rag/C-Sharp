// METHOD SHADOWING
// IF WE HAVE A NON VIRTUAL FUNCTION IN BASE CLASS THE WE WANT TO OVEERIDE
// WE CAN USE new KEYWORD TO TELL THE COMPILER TO IGNORE PARENT'S IMPLEMENTATION
// WE CAN ALSO APPLY SHADOWING ON FIELDS

using System;

namespace Experiment {
    public class Animal {
        public String name = "Fred";
        public void eat() {  
            Console.WriteLine("Animal Is Eating");
        }
    }

    public class Dog : Animal {

        // SHADOWING FIELDS
        public new String name = "Becky";
        
        // METHOD SHAWDOWING NEEDED OTHERWISE COMPILER WILL ISSUE WARNING
        public new void eat() {
            // STILL CALL BASE CLASS METHODS
            // base.eat();
            Console.WriteLine("Dog Is Eating");
        }
    }

    class Program {
        static void Main(string[] args) {
            Animal a = new Animal();
            Dog d = new Dog();

            a.eat();
            d.eat();

            Console.ReadKey();
        }
    }
}
