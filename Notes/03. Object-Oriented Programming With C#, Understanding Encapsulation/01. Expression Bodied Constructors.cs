// EXPRESSION BODIED CONSTRUCTORS
// USE (ctor + TAB TWICE) TO USE CONSTRUCTOR SNIPPET
using System;


class Car {
 	int topSpeed;
    public Car(int topSpeed) => this.topSpeed = topSpeed;
    public int getTopSpeed() => this.topSpeed;
}
public static class Program {
    public static void Main() {
        Car c = new Car(20);
        Console.WriteLine(c.getTopSpeed());
    }
}