// VIRTUAL & OVERRIDE
// If a base class wants to define a method that may be
// (but does not have to be) overridden by a subclass, 
// it must mark the method with the virtual keyword

using System;

public static class Program {
    public class Animal {
    	public virtual void eat() {
        	Console.WriteLine("Animal Is Eating");   
        }
        
        public virtual void sleep() {
        	Console.WriteLine("Animal Is Sleeping");  
        }
        
        public virtual void play() {
            Console.WriteLine("Animal Is Playing");  
        }
    }
    
    public class Dog : Animal {
        public override void eat() {
   			Console.WriteLine("Dog Is Eating");
        }   
        
        // SEALED OVERRIDES CAN'T BE OVERRIDDEN ANY FUTHER BY SUB-CLASSES
        public sealed override void play() {
        	Console.WriteLine("Dog Is Playing");
        }
    }
    
    public class GermanShepherd : Dog {
        public override void eat() {
            Console.WriteLine("German Shepherd Is Eating");
        }
        
        // ERROR!
        // public override void play() { }
        
    }
    public static void Main() {
        Animal a = new Animal();
        Dog d = new Dog();
        GermanShepherd gs = new GermanShepherd();
        
        a.eat();
        // Animal Is Eating
        a.sleep();
        // Animal Is Sleeping
		a.play();
        // Animal Is Playing
        
        d.eat();
        // Dog Is Eating
        d.sleep();
        // Animal Is Sleeping
        d.play();
        
        gs.eat();
        // German Shepherd Is Eating
        gs.play();
        // Dog Is Playing
    }
}