using System;

namespace Shapes {
    class Circle : Shape {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void draw() {
            Console.WriteLine("Drawing {0} the Circle", this.PetName);
        }
    }
}
