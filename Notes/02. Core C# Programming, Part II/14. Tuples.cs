// TUPLES

using System;

namespace Notes {
    public class Program {
        public static void Main(string[] args) {
			(string, int, string) values = ("a", 5, "c");
            // OR
			// var values = ("a", 5, "c");
            
            // ACCESSING ITEMS
            // DEFAULT THEY ARE ASSIGNED ItemX
            Console.WriteLine(values.Item1);
            Console.WriteLine(values.Item2);
            Console.WriteLine(values.Item3);
            
            // ASSIGNING NAMES
			// CAN BE DONE ON BOTH SIDES
            // IF DONE RIGHT SIDE NAMES WILL BE IGNORED 
            
            // LEFT SIDE
            (String name, int age) person = ("Chirag", 20);
            Console.WriteLine(person.name);
            Console.WriteLine(person.age);
            
            // RIGHT (MUST USE VAR ON LEFT)
            var person2 = (name: "Chirag", age: 20);
            Console.WriteLine(person2.name);
            Console.WriteLine(person2.age);
            
            // BOTH SIDE
            (String name, int age) person3 = (name: "Chirag", age: 20);
            Console.WriteLine(person3.name);
            Console.WriteLine(person3.age);
            
            // ITEMX STILL WORKS
            Console.WriteLine(person2.Item1);
            Console.WriteLine(person2.Item2);
            
            // WHEN RIGHT SIDES ARE IGNORED?1
            // (int, int) example = (Custom1:5, Custom2:7);
			// (int Field1, int Field2) example = (Custom1:5, Custom2:7);
            
            // INFERRED TUPEL NAMES(C# 7.1)
            // Many times when you initialize a tuple, the variables used for 
            // the right side of the assignment are the same as the names 
            // you'd like for the tuple elements:
            
            int num = 2;
            bool isPrime = true;
            
            var primeInfo = (num, isPrime);
            Console.WriteLine(primeInfo.num + " is prime? " + isPrime);  
            
       		// AS FUNCTION RETURNS(VERY VERY SUITABLE)
            
            var data = getData();
            
            Console.WriteLine(data.a);
            Console.WriteLine(data.b);
            Console.WriteLine(data.c);
            
            // DICARDING AND VARIABLE ASSINGMENT
            // LIKE DESTRUCTURING
            (int n, _, float x) = getData();
            Console.WriteLine(n);
            Console.WriteLine(x);
            
            // DECONSTRUCTING STURCTS
        	Point p = new Point(12, 23);
            var deconstructed = p.Deconstruct();
     		Console.WriteLine(deconstructed.xPos);
            Console.WriteLine(deconstructed.yPos);
            
        }
        
        // RETURNING TUPLE FROM METHOD
        static (int a, string b, float c) getData() {
        	return(1, "Hello", 3.14f);
        }
    }
    
    struct Point {
        int x;
        int y;
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
        
        public (int xPos, int yPos) Deconstruct() => (x, y);
        
        // WIDTHOUT LAMBDA
        // public (int xPos, int yPos) Deconstruct() {
        //  return (x, y);   
        // }
    }
}