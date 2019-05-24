// DIRECT INITIALIZATION OF AUTOMATIC PROPERTIES
// PRIOR TO C#6 THIS MUST BE DONE USING CONSTRUCTORS
// C#6+ PROVIES NEW SYNTAX TO DO THIS
using System;

public class Point {
    public int X {get; set;}
    public int Y {get; set;}

    public Point() { }
    public Point(int X, int Y) {
     this.X = X;
     this.Y = Y;
    }
}


public class Rectangle {
 	public Point topLeft { get; set; } = new Point();
    public Point bottomRight { get; set; } = new Point();
    public void PrintStats() {
    	Console.WriteLine("Top Left: ({0}, {1}), Bottom Right: ({2}, {3})",  topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
    }
}

public static class Program {
    public static void Main() {
        // WAYS TO INITIALIZE OBJECT
        Point p = new Point();
        p.X = 12;
        p.Y = 13;
        
        Point p2 = new Point(25, 12);
        
        // USING OBJECT INITIALIZER LIST
        
        Point p3 = new Point { X = 12, Y = 67 };
        // THIS CALLS DEFAULT CONSTRUCTOR AND ASSIGN X AND Y VALUES THEN
        // OR WE CAN WRITE THIS
        // Point p3 = new Point() { X = 12, Y = 67 };
        
        // WE CAN ALSO CALL CUSTOM CONSTRUCTOR WHEN USING INITIALIZER LIST
        Point p4 = new Point(12, 14) { X = 345, Y = 23 };
        // 12 AND 14 WILL BE OVERWRITTEN IN THIS CASE
        
        // INITIALING OBJECTS USING INITIALIZER LIST
        
        Rectangle rect = new Rectangle() {
            	topLeft = new Point(12, 13),
            	bottomRight = new Point(78, 90)
        };
        rect.PrintStats();
        
    }
}