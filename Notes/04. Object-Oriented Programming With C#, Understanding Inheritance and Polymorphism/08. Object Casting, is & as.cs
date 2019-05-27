// OBJECT CASTING

using System;

namespace Experiment {
    public class Animal {
        public String name = "Fred";
        public virtual void eat() {
            Console.WriteLine("Animal Is Eating");
        }
    }

    public class Dog : Animal {
        public override void eat() {
            Console.WriteLine("Dog Is Eating");
        }
    }

    public class Robot {
        public void eatRob() {
            Console.WriteLine("Robot Is Eating");
        }
    }

    class Program {
        static void Main(string[] args) {
            // BASE CLASS REFERANCE CAN STORE SUB CLASS OBJECTS
            Object a = new Animal();
            Animal d = new Dog();

            MakeAnimalEat(d);

            // ERROR
            // MakeAnimalEat(a);
            // OBJECT REFERANCE IS HIGHER UP IN THE INHERITANCE CHAIN

            // TO MAKE THIS WORK WE CAN PERFORN EXPLICIT DOWNCAST
            MakeAnimalEat((Animal)a);

            // WHEN PERFORMING CASTING USE TRY CATCH TO BE SAFE FROM WRONG TYPE CASTING
            Animal animal;
            try {
                animal = (Animal)a;
            } catch (InvalidCastException) {
                Console.WriteLine("Casting Failed!");
            }
            
            // as KEYWORD PROVIDE QUICK COMPATIBILITY CHECK BETWEEN REFENCE AND THE OBJECT

            Object[] randomObjects = { new Animal(), new Dog(), new Robot(), new Animal(), null, new Robot(), new DateTime() };

            foreach (Object obj in randomObjects) {
                Animal an = obj as Animal;   // IF SUCCESS THEN RETURNS AN ANIMAL OTHERWISE NULL
                if (an != null) {
                    an.eat();
                } else {
                    Console.WriteLine("NOT COMPATIBLE");
                }
            }

            // is KEYWORD ALSO PROVIDE QUICK COMPATIBILITY CHECK BETWEEN REFENCE AND THE OBJECT
            // IT RETURNS BOOLEAN INSTEAD OF NULL OR CASTED OBJECT
            
            foreach (Object obj in randomObjects) {
                if (obj is Animal) {
                    ((Animal)obj).eat();
                } else {
                    Console.WriteLine("NOT COMPATIBLE");
                }
            }
            
            
            // C#7 IMPROVES is KEYWORDS TO MAKE CHECKING AND CASTING IN A SINGLE LINE
            foreach (Object obj in randomObjects) {
                if (obj is Animal an) {
                    an.eat();
                } else {
                    Console.WriteLine("NOT COMPATIBLE");
                }
            }
            
            // ALSO IT SUPPORTS TYPE SWITCHING, WHEN & DISCARS
            foreach (Object obj in randomObjects) {
                switch(obj) {
                    case Animal an:
                        an.eat();
                        break;
                    case Robot r:
                        r.eatRob();
                        break;
                    case DateTime _:
                        // IGNORE DateTime
                        break;
                    case null:
                        // HANDLE NULL
                        break;
                    default:
                        Console.WriteLine("NOT COMPATIBLE");
                        break;
                }
            }
        }

        // CAN PASS ANY ANIMAL OR ITS SUB CLASS TYPE REFERENCE
        static void MakeAnimalEat(Animal a) {
            a.eat();
        }
    }
}
