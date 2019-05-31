// System.Collections.Generic.Stack<T>

using System;
using System.Collections.Generic;


namespace Experiment {

    public class Point {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() { }
        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override string ToString() {
            return string.Format("X: {0}, Y: {1}", this.X, this.Y);
        }
    }


    public class Program {
        public static void Main(string[] args) {

            // new Stack<T>()
            // new Stack<T>(int capacity)
            // new Stack<T>(IEnumerable <T> c)
            Stack<Point> myPointStack = new Stack<Point>(new Point[] { new Point(0, 0), new Point(100, 200) });
            PrintStack(myPointStack);

            // Push(T item)
            myPointStack.Push(new Point(56, 34));
            myPointStack.Push(new Point(56, 89));
            myPointStack.Push(new Point(89, 23));

            PrintStack(myPointStack);

            // T Pop()
            Point onTop = myPointStack.Pop();
            Console.WriteLine(onTop.ToString());

            // T Peek()
            // returns top item without removing it
            onTop = myPointStack.Peek();
            PrintStack(myPointStack);


            // bool Contains(T item)
            Console.WriteLine(myPointStack.Contains(onTop)); // TRUE

            // IEnumerator GetEnumerator()

            IEnumerator<Point> i = myPointStack.GetEnumerator();

            while (i.MoveNext()) {
                Console.WriteLine(i.Current);
            }

            // int Count
            Console.WriteLine("Number Of Items: {0}", myPointStack.Count);

            // ToArray()
            Point[] points = myPointStack.ToArray();

            // CopyTo(T[] arr, int startIndexOfArray)
            Point[] copies = new Point[4];
            myPointStack.CopyTo(copies, 0);


            // void Clear()
            myPointStack.Clear();

            // throws InvalidOperationException on popping an empty stack

            try {
                myPointStack.Pop();
            } catch (InvalidOperationException ex) {
                Console.WriteLine("can't pop an empty stack!!");
            }
            Console.ReadKey();

        }

        public static void PrintStack(Stack<Point> myStack) {
            foreach (Point p in myStack) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
        }
    }
}