// Collection Initialization Syntax

using System;
using System.Collections;
using System.Collections.Generic;


namespace Experiment {

    public class Point {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() { }
        public Point(int x, int y) {
            this.X = x;
            this.Y = Y;
        }

        public override string ToString() {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }
    }

    public class Rectangle {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle() {
            TopLeft = new Point();
            BottomRight = new Point();
        }

        public Rectangle(int top, int left, int bottom, int right) {
            this.TopLeft = new Point() { X = left, Y = top };
            this.BottomRight = new Point(right, bottom);
        }

        public override string ToString() {
            return string.Format("Top: {0}, Left: {1}, Bottom: {2}, Right: {3}", this.TopLeft.Y, this.TopLeft.X, this.BottomRight.Y, this.BottomRight.X);
        }
    }

    public class Program {
        public static void Main(string[] args) {
            int[] intArray = { 1, 2, 3, 4, 5, 6, 7 };

            List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            ArrayList intArrayList = new ArrayList() { 1, 2, 3, 4, 5, 6, 7 };

            List<Point> myPoints = new List<Point>() {
                                        new Point(),
                                        new Point(22, 14),
                                        new Point() { X = 34, Y = 23 }
                                    };

            foreach (Point p in myPoints) {
                Console.WriteLine(p.ToString());
            }

            List<Rectangle> myRects = new List<Rectangle>()  {
                new Rectangle(),
                new Rectangle(10, 20, 40, 34),
                new Rectangle() {
                    TopLeft = new Point() { X = 10, Y = 40 }, 
                    BottomRight = new Point() { X = 50, Y = 90}
                }
            };

            foreach (Rectangle r in myRects) {
                Console.WriteLine(r.ToString());
            }

            Console.ReadKey();
        }
    }
}