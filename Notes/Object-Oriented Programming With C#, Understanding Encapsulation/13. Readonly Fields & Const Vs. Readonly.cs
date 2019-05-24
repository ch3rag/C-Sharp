// READONLY FIELDS
// SOMETIMES WE NEED TO DEFINE A CONSTANT WHOSE VALUE IS NOT KNOWN DURING RUNTIME
// THE READ ONLY FIELDS CAN BE INITIALIZED ONLY ONCE WITHIN A CONSTRUCTOR
// THEY ARE NOT IMPLICITELY STATIC 

// static readonly (VALUE ACCESSED FROM CLASS LEVEL AND INITIALIZED AT RUNTIME)
// readonly (VALUE ACCESSED FROM OBJECT LEVEL AND INITIALIZED AT RUNTIME)
// const (VALUE ACCESSED FROM CLASS LEVEL AND INITIALIZED AT COMPILE TIME)
// THUS
// static readonly == const (IF VALUE KNOWN AT COMPILE TIME)

using System;
namespace Notes {
    
    public class MyMath {
    	public readonly double PI;
        public MyMath() {
            PI = 3.14159;            
        }
        public static readonly double e;
        
        static MyMath() {
        	e = 2.718;   
        }
    }
	public class Program {
    	public static void Main(string[] args) {
       		MyMath math = new MyMath();
            
            Console.WriteLine(math.PI);
            
            // THIS DOES NOT WORK
            // Console.WriteLine(MyMath.PI);
            
        }
    }
}