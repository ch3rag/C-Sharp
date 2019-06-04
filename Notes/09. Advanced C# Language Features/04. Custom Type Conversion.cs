// Custom Conversion Routines

using System;

namespace Experiment {
    struct Rectangle {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height) : this() {
            this.Width = width;
            this.Height = height;
        }

        public void Draw() {
            for (int i = 0; i < Height; i++) {
                for (int j = 0; j < Width; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString() {
            return string.Format("[Width = {0}; Height = {1}]", this.Width, this.Height);
        }

        // IMPLICIT CONVERSION FROM SQUARE TO RECTANGLE
        public static implicit operator Rectangle(Square sq) {
            return new Rectangle(sq.Length, sq.Length * 2);
        }
    }

    struct Square {
        public int Length { get; set; }

        public Square(int length) : this() {
            this.Length = length;
        }
        public void Draw() {
            for (int i = 0; i < Length; i++) {
                for (int j = 0; j < Length; j++) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
        public override string ToString() {
            return string.Format("[Length = {0}]", this.Length);
        }

        // COVERSION explicit OR implicit BOTH ARE POSSIBLE
        // SQUARE FORM RECTANGLE
        public static explicit operator Square(Rectangle rect) {
            return new Square(rect.Height);
        }   

        // SQUARE FROM INT
        public static explicit operator Square(int side) {
            return new Square(side);
        }

        // INT FROM SQUARE
        public static explicit operator int(Square sq) {
            return sq.Length;
        }
    }

    public class Program {
        public static void Main(string[] args) {
            Rectangle rect = new Rectangle(15, 5);
            Console.WriteLine(rect);
            rect.Draw();
            Console.WriteLine();


            Square sq = (Square)rect;
            Console.WriteLine(sq);
            sq.Draw();

            Square sq2 = (Square)8;
            Console.WriteLine(sq2);
            sq2.Draw();

            int len = (int)sq2;
            Console.WriteLine(len);


            Square s = new Square(5);
            // IMPLICIT CONVERSION SUPPORTS BOTH TYPE OF SYNTAX
            // Rectangle rec = (Rectangle)s;
            Rectangle rec = s;
            rec.Draw();

            Console.ReadKey();
        }
    } 
}