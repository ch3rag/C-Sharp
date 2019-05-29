// INTERFACE HEIRARCHY
// SIMPLE INHERITANCE

using System;


namespace Experiment {
    public interface IDrawable {
        void Draw();
    }


    public interface IAdvancedDraw : IDrawable {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }

    class BitmapImage : IAdvancedDraw {
        public void Draw() {
            Console.WriteLine("Drawing...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right) {
            Console.WriteLine("Drawing in a Bounding Box..");
        }

        public void DrawUpsideDown() {
            Console.WriteLine("Drawing Upside Down..");
        }
    }


    class Program {
        static void Main(string[] args) {
            BitmapImage bi = new BitmapImage();
            bi.Draw();
            bi.DrawInBoundingBox(0, 0, 100, 100);
            bi.DrawUpsideDown();

            Console.ReadKey();
        }
    }
}
 