using System;

namespace Shapes {
    class Hexagon : Shape {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }

        public override void draw() {
            Console.WriteLine("Drawing {0} the Hexagon", this.PetName);
        }
    }
}
