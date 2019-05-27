// ABSTRACT CLASSES
// CREATING A GENERAL BASE CLASS (ANIMAL)
// INSTANCE OF ABSTRACT CLASSES CAN'T BE CREATED
// ONLY THEIR NON-ABSTARCT SUB-CLASSES CAN BE INSTANTIATED
using System;

public static class Program {
    public abstract class Animal {
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Animal() { }
        public Animal(string name) : this(name, 0) { } 
        public Animal(string name, int age) {
        	this.Name = name;
            this.Age = age;
        }
        
    	public virtual void eat() {
        	Console.WriteLine("{0} Is Eating", this.Name);   
        }
        
        public virtual void sleep() {
        	Console.WriteLine("{0} Is Sleeping", this.Name);  
        }
        
        public virtual void play() {
            Console.WriteLine("{0} Is Playing", this.Name);  
        }
    }
    
    public class Dog : Animal {
        
        public Dog(string name) : base(name, 0) { }
        public Dog(string name, int age) : base(name, age) { }
        
        public override void eat() {
   			Console.WriteLine("{0} Is Eating His Dogfood.", this.Name);
        }   
        
        // SEALED OVERRIDES CAN'T BE OVERRIDDEN ANY FUTHER BY SUB-CLASSES
        public sealed override void play() {
        	Console.WriteLine("{0} Is Playing With His Owner", this.Name);
        }
    }
    
    public static void Main() {
        
        // ERROR
        // Animal a = new Animal();
        Dog d = new Dog("Jerry", 3);
        
        d.eat();
        // Dog Is Eating
        d.sleep();
        // Animal Is Sleeping
        d.play();
        
    }
}