using System;

namespace Shapes {
    class Program {
        static void Main(string[] args) {

            Shape[] shapes = { new Circle(), new Hexagon(), new Hexagon("Becky"), new Circle("Jonas"), new Circle("Fred") };

            foreach(Shape s in shapes) {
                s.draw();
            }

            Console.ReadKey();
        }
    }
}
