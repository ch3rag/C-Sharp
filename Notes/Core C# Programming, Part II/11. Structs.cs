// STRUCTS
// LIGHT WEIGHT CLASS
// USED TO CREATE AN ENCAPSULATION OF FEILDS AND METHODS THAT ARE ATOMIC IN NATURE AND FURTHER INHERITANCE IS NOT NEEDED

using System;
namespace Notes {

    struct Point {
        public int x;
        public int y;

        // IT CAN ALSO HAVE CONSTRUCTORS

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }


        public void Increment() {
            x++; y++;
        }
        public void Decrement() {
            y--; x--;
        }

        public void Print() {
            Console.WriteLine("X = {0}, Y = {1}", x, y);
        }
    }

    class Program {
        public static void Main(string[] args) {
            Point myPoint;

            // CAN'T DO THIS NOW
            // myPoint.Print();

            myPoint.x = 100;
            myPoint.y = 200;

            // NOW IT'S ALLOWED
            myPoint.Print();

            myPoint.Increment();
            myPoint.Print();

            myPoint.Decrement();
            myPoint.Print();

            // IF THE STRUCT IS CREATE USING NEW KEYWORD ALL THE FIELDS WILL BE INITIALIZED TO THIER DEFAULT VALUES
            Point newPoint = new Point();               // INVOKING DEFAULT CONSTRUCTOR
            newPoint.Print();

            Point newPoint2 = new Point(45, 23);        // INVOKING CUSTOM CONSTRUCTOR
            newPoint2.Print();
            
    
            // STRUCTS AND ENUM ARE OF VALUE TYPE RATHER THAN REFERENCE TYPE
            // THIS MEANS THEY ARE STORED ON STACK AND NOT ON HEAP
            // THE System.ValueType IS THE CHILD CLASS OF System.Object 
            // Int32 IS ALSO AN EXAMPLE OF VALUE TYPE DEFINED IN System.Int32 STRUCTURE
            

            // ASSIGMENT ON THE VALUE TYPES
            // JUST LIKE AN INT IS A VALUE TYPE, A STRUCT IS ALSO A VALUE TYPE
            // AND WE CAN COPY A COMPLETE STRUCT TO ANOTHER VARIABLE USING JUST ASSIGNMENT

            Point p1 = new Point(43, 23);
            Point p2 = p1;

            p2.x = 1000;        // THIS IS NOT REFLECTED IN P1

            p1.Print();
            p2.Print();

            // IF POINT WAS A CLASS THEN THE CHANGES IN P2 WILL BE REFLECTED IN P1
            // BECAUSE P1 AND P2 POINT THE SAME OBJECT IN THE MANAGED HEAP
            
            Console.ReadLine();
        } 
    }
}

