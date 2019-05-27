// DIRECT INITIALIZATION OF AUTOMATIC PROPERTIES
// PRIOR TO C#6 THIS MUST BE DONE USING CONSTRUCTORS
// C#6+ PROVIES NEW SYNTAX TO DO THIS
using System;
public class Car {
	public int TopSpeed { get; set; } = 10;
    // SET TOPSPEED TO 10
}
public static class Program {
    public static void Main() {
        Car c = new Car();
        Console.WriteLine(c.TopSpeed);
    }
}