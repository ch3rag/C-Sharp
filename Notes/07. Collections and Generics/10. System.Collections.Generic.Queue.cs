// System.Collections.Generic.Queue<T>

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

            // new Queue<T>()
            // new Queue<T>(int capacity)
            // new Queue<T>(IEnumerable <T> c)
            Queue<Point> myPointQueue = new Queue<Point>(new Point[] { new Point(0, 0), new Point(100, 200) });
            PrintQueue(myPointQueue);

            // Enqueue(T item)
            // Adds item to the end of the queue
            myPointQueue.Enqueue(new Point(56, 34));
            myPointQueue.Enqueue(new Point(26, 94));
            myPointQueue.Enqueue(new Point(156, 10));


            PrintQueue(myPointQueue);

            // T Dequeue()
            // Returns and removes the item at the front of the queue
            Point atFront = myPointQueue.Dequeue();
            Console.WriteLine(atFront.ToString());

            // T Peek()
            // Returns the item at the front without removing it
            atFront = myPointQueue.Peek();

            // bool Contains(T item)
            Console.WriteLine(myPointQueue.Contains(atFront)); // True

            // IEnumerator GetEnumerator()

            IEnumerator<Point> i = myPointQueue.GetEnumerator();

            while (i.MoveNext()) {
                Console.WriteLine(i.Current);
            }

            // int Count;
            Console.WriteLine("Number Of Items: {0}", myPointQueue.Count);

            // ToArray()
            Point[] points = myPointQueue.ToArray();

            // CopyTo(T[] arr, int startIndexOfArray)
            Point[] copies = new Point[4];
            myPointQueue.CopyTo(copies, 0);


            // void Clear()
            myPointQueue.Clear();

            // throws InvalidOperationException on dequeuing an empty Queue

            try {
                myPointQueue.Dequeue();
            } catch (InvalidOperationException ex) {
                Console.WriteLine("can't dequeue an empty Queue!!");
            }
            Console.ReadKey();

        }

        public static void PrintQueue(Queue<Point> myQueue) {
            foreach (Point p in myQueue) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine();
        }
    }
}