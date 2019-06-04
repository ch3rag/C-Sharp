// OPERATOR OVERLOADING

// +, -,! , ~, ++, --, true, false 
// These unary operators can be overloaded.

// +, -, *, /, %, &, |, ^, <<, >> 
// These binary operators can be overloaded.

// ==,!=, <, >, <=, >= 
// These comparison operators can be overloaded. C# demands that “like” operators (i.e., < and >, <= and >=, == and !=) are overloaded together.

// [] 
// The [] operator cannot be overloaded as the indexer construct provides the same functionality.

// () 
// The () operator cannot be overloaded. Custom conversion methods provide the same functionality.

// +=, -=, *=, /=, %=, &=, |=, ^=, <<=, >>=
// Shorthand assignment operators cannot be overloaded; You receive them as a freebie when you overload the related binary operator.

using System;

namespace Experiment {

    public class Point : IComparable<Point> {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }

        // BINARY
        public static Point operator +(Point x, Point y) {
            return new Point(x.X + y.X, x.Y + y.Y);
        }

        public static Point operator -(Point x, Point y) {
            return new Point(x.X - y.X, x.Y - y.Y);
        }

        public static Point operator +(Point x, int delta) {
            return new Point(x.X + delta, x.Y + delta);
        }

        public static Point operator -(Point x, int delta) {
            return new Point(x.X - delta, x.Y - delta);
        }

        // UNARY
        public static Point operator ++(Point x) {
            return new Point(x.X + 1, x.Y + 1);
        }

        public static Point operator --(Point x) {
            return new Point(x.X - 1, x.Y - 1);
        }

        // EQUALIY
        // FIRST OVERRIDE GETHASHCODE AND EQUALS
        // C# demands that if you override the == operator, you must also override the != operator

        public override bool Equals(object obj) {
            return obj.ToString() == this.ToString();
        }

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Point x, Point y) {
            return x.Equals(y);
        }

        public static bool operator !=(Point x, Point y) {
            return !(x.Equals(y));
        }

        // COMPARISION OPERATOR
        // C# demands that if you overload <, you must also overload >. The same holds true for the <= and >= operators. 

        public int CompareTo(Point p) {
            if (this.X > p.X && this.Y > p.Y) {
                return 1;
            } else if (this.X < p.X && this.Y > p.Y) {
                return -1;
            } else {
                return 0;
            }
        }

        public static bool operator >(Point x, Point y) {
            return x.CompareTo(y) > 0;
        }

        public static bool operator <(Point x, Point y) {
            return x.CompareTo(y) < 0;
        }

        public static bool operator >=(Point x, Point y) {
            return x.CompareTo(y) >= 0;
        }

        public static bool operator <=(Point x, Point y) {
            return x.CompareTo(y) <= 0;
        }

    }
    public class Program {
        public static void Main(string[] args) {

            Point p1, p2, p3, p4;

            p1 = new Point(123, 435);
            p2 = new Point(34, 45);
            Console.WriteLine(p1 + p2);
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1 - 100);

            p3 = new Point(1, 1);
            Console.WriteLine(p3++);
            Console.WriteLine(p3--);

            p3 = new Point(20, 20);
            Console.WriteLine(++p3);
            Console.WriteLine(--p3);

            p3 = new Point(20, 20);
            p4 = new Point(20, 20);
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1 != p2);
            Console.WriteLine(p3 == p4);
            Console.WriteLine(p3 != p4);

            Console.WriteLine(p1 > p2);
            Console.WriteLine(p1 < p2);
            Console.WriteLine(p3 >= p4);
            Console.WriteLine(p3 <= p4);

            Console.ReadKey();
        }
    }
}