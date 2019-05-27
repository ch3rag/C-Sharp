// CONST FIELDS
// THESE ARE IMPLICITELY STATIC WHEN USED AS CLASS MEMBER
// THEY CAN ALSO BE USED AT LOCAL LEVEL

using System;
namespace Notes {
    
    public class MyMath {
    	public const double PI = 3.14159;   
    }
	public class Program {
    	public static void Main(string[] args) {
       		MyMath math = new MyMath();
            
            Console.WriteLine(MyMath.PI);
            
            // THIS DOES NOT WORK
            // Console.WriteLine(math.PI);
            // MyMath.PI = 1;
            
            const int i = 0;
            // ERROR
            // const j;		// MUST BE INITIALIZED            
            // i = 1;
            
            
        }
    }
}