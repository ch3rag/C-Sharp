// CREATING INTERFACES
// WHEN IMPLEMENTING INTERFACES:
// The direct base class must be the first item listed after the colon operator.

using System;


namespace Experiment {

    public abstract class Shape {
        public string PetName { get; set; }
        public Shape(string name = "NoName") {
            this.PetName = name;
        }
        public abstract void draw();
    }

    // INTERFACE DEFINITION
    // CAN'T HAVE FIELDS
    // CAN'T HAVE METHOD IMPLEMENTATION
    // ONLY .NET PROPERTIES AND ABSTRACT METHODS ARE ALLOWED

    public interface IPointy {
        // IMPLICITELY PUBLIC AND ABSTRACT
        // READ ONLY POINTS PROPERTY
        byte Points { get; }
    }


    public interface IDraw3D {
        void Draw3D();
    }


    public class Circle : Shape {
        public Circle() { }
        public Circle(string name) : base(name) { }
        public override void draw() {
            Console.WriteLine("Drawing {0} the Circle", this.PetName);
        }
    }
    
    public class ThreeDCircle : Circle, IDraw3D {
        public ThreeDCircle() { }
        public ThreeDCircle(string name) : base(name) { }
        public override void draw() {
            Console.WriteLine("Drawing {0} the ThreeDCircle", this.PetName);
        }

        public void Draw3D() {
            Console.WriteLine("Drawing {0} the ThreeDCircle in 3D", this.PetName);
        }
    }


    public class Hexagon : Shape, IPointy, IDraw3D {
        public Hexagon() { }
        public Hexagon(string name) : base(name) { }
        public override void draw() {
            Console.WriteLine("Drawing {0} the Hexagon", this.PetName);
        }

        public byte Points {
            get {
                return 6;
            }
        }

        public void Draw3D() {
            Console.WriteLine("Drawing {0} the Hexagon in 3D", this.PetName);
        }
    }

    public class Triangle : Shape, IPointy {
        public Triangle() { }
        public Triangle(string name) : base(name) { }
        public override void draw() {
            Console.WriteLine("Drawing {0} the Triangle", this.PetName);
        }
        public byte Points {
            get {
                return 3;
            }
        }
    }

    public class PointyTest : IPointy {
        public byte Points {
            get { throw new NotImplementedException(); }
        }
    }




    class Program {
        static void Main(string[] args) {
            Hexagon zippy = new Hexagon("Zippy");
            Console.WriteLine(zippy.Points);

            // DETERMINING WHETHER AN OBJECT HAS IMPLEMENTED AN INTERFACE USING CASTING, AS OR IS
            Shape[] shapes = { new Circle(), new Triangle(), new ThreeDCircle(), new Hexagon()};

            foreach (Shape s in shapes) {
                try {
                    IPointy shape = (IPointy)s;
                    Console.WriteLine(shape.Points);
                } catch (InvalidCastException ex) {
                    Console.WriteLine("NOT POINTY");
                }
            }

            foreach (Shape s in shapes) {
                IPointy shape = s as IPointy;
                if (shape != null) {
                    Console.WriteLine(shape.Points);
                } else {
                    Console.WriteLine("NOT POINTY");
                }
            }

            foreach (Shape s in shapes) {
                if (s is IPointy) {
                    Console.WriteLine(((IPointy)s).Points);
                } else {
                    Console.WriteLine("NOT POINTY");
                }
            }

            Shape[] shapes3D = { new Circle(), new Hexagon(), new ThreeDCircle(), new Triangle() };

            foreach (Shape s in shapes3D) {
                if (s is IDraw3D) {
                    Draw3DShapes((IDraw3D)s);
                }
            }

            IPointy pointyShape = GetPointyShape(shapes3D);
            if (pointyShape != null) {
                Console.WriteLine(pointyShape.Points);
            }
            
            Console.ReadKey();
        }


        // INTERFACE AS PARAMETERS
        public static void Draw3DShapes(IDraw3D shape) {
            shape.Draw3D();
        }

        // INTERFACE AS RETURN VALUE
        public static IPointy GetPointyShape(Shape[] shapes) {
            // RETURN FIRST POINTY SHAPE
            foreach (Shape s in shapes) {
                if (s is IPointy) {
                    return ((IPointy)s);
                }
            }
            return null;
        }
    }
}
 