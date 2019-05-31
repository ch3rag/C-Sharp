// Generic Point Class

using System;

namespace Experiment {

    public class Point<T> {
        public T X { get; set; }
        public T Y { get; set; }

        public Point() { }
        public Point(T x, T y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return String.Format("X: {0}, Y: {1}", this.X, this.Y);
        }

        // reset the points to the default values of their types
        public void ResetPoint() {
            this.X = default(T);
            this.Y = default(T);
        }

    }
    public class Program {
        public static void Main(string[] args) {
            Point<int> p1 = new Point<int>(12, 23);
            Point<double> p2 = new Point<double>(34.123323, 56.21324);

            Console.WriteLine(p1.ToString());
            Console.WriteLine(p2.ToString());

            Console.ReadKey();
        }
    }
}