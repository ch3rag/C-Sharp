// NESTED NAMESPACES


using System;

namespace Shapes {
    namespace Shapes3D {
        public class Circle {

        }

        public class Hexagon {

        }
        // MORE DEFINITIONS
    }

    namespace Shapes2D {
        public class Circle {

        }

        public class Square {

        }
        // MORE DEFINITIONS
    }
}

namespace Shapes.Draw {
    public class Pen2D {
        public void DrawCircle() { }
        public void DrawHexagon() { }
    }
    public class Pen3D {
        public void DrawCircle() { }
        public void DrawHexagon() { }
    }
}



namespace Experiment {
    public class Program {
        public static void Main(string[] args) {
            Shapes.Shapes2D.Circle circle = new Shapes.Shapes2D.Circle();
            Shapes.Shapes3D.Circle circle3d = new Shapes.Shapes3D.Circle();

            Shapes.Draw.Pen3D pen3d = new Shapes.Draw.Pen3D();
            pen3d.DrawCircle();

            Console.ReadKey();
        }
    }
}

