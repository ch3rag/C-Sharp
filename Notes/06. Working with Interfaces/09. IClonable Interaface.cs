// IClonable
// When you want to give your custom type the ability to return an identical copy of itself to the caller, you 
// may implement the standard ICloneable interface

using System;
using System.Collections;

namespace Experiment {
    public class Point : ICloneable {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int xPos, int yPos) {
            this.X = xPos;
            this.Y = yPos;
        }

        public override string ToString() {
            return String.Format("X: {0}, Y: {1}", this.X, this.Y);
        }

        public object Clone() {
            return new Point(this.X, this.Y);

            // POINT DOES NOT CONTAIN ANY REFERENCE TYPE VALUES WE CAN USE Object.MemberWiseClone() TO RETURN THE SHALLOW COPY
            // return this.MemberwiseClone();
        }

    }   
    class Program {
        static void Main(string[] args) {
            Point p1 = new Point(20, 30);

            Point p2 = (Point)p1.Clone();

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            Console.WriteLine("After Modification: ");

            p2.X = -23;
            p2.Y = 56;

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());


            Console.ReadKey();
        }
    }
}
 