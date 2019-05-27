// LOCAL FUNCTIONS
// FUNCTION WITHIN FUNCTIONS
// USED IN ASYC FUNCTIONS & CUSTOM INTERATORS
// SIMPLE EXAMPLE HERE IS TO SHOW HOW IT CAN BE USED TO SEPERATE THE 
// VALIDATION CODE AND THE REAL GOAL OF THE METHOD i.e, ADD TWO BYTES

using System;

namespace Notes {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine(AddWrapper(100, 200));
            // SUM NOT POSSIBLE
            Console.WriteLine(AddWrapper(100, 100));
            // 200
            
        }
        
        public static byte AddWrapper(byte a, byte b) {
        	// SEPERATING VALIDATION FROM REAL GOUL USING LOCAL FUNCTION
            if(a + b > 255) {
                Console.WriteLine("SUM NOT POSSIBLE");
             	return 0;	
            }
            
            return Add(a, b);
            
            byte Add(byte x, byte y) {
                return (byte)(x + y);
            }
            
        }
    }
}