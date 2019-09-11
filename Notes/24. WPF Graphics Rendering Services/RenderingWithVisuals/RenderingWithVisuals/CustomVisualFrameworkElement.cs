using System.Windows;
using System;
using System.Windows.Media;
namespace RenderingWithVisuals {
    class CustomVisualFrameworkElement : FrameworkElement {
        VisualCollection visuals;
        public CustomVisualFrameworkElement() {
            this.MouseDown += CustomVisualFrameworkElement_MouseDown;
            visuals = new VisualCollection(this) {
                AddCircle(),
                AddRectangle()
            };
        }

        private void CustomVisualFrameworkElement_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            Point mouse = e.GetPosition(this);
            VisualTreeHelper.HitTest(
                    this, 
                    null, 
                    new HitTestResultCallback(HitTestCallBack), 
                    new PointHitTestParameters(mouse));
        }

        HitTestResultBehavior HitTestCallBack(HitTestResult result) {
            if(result.VisualHit is DrawingVisual) {
                DrawingVisual visual = result.VisualHit as DrawingVisual;
                if (visual.Transform == null) {
                    visual.Transform = new SkewTransform(7, 7);
                } else {
                    visual.Transform = null;
                }
            }
            return HitTestResultBehavior.Stop;
        }        

        private Visual AddCircle() {
            DrawingVisual drawingVisual = new DrawingVisual();
            using(DrawingContext context = drawingVisual.RenderOpen()) {
                context.DrawEllipse(Brushes.DarkBlue, null, new Point(70, 90), 40, 50);
            }
            return drawingVisual;
        }

        private Visual AddRectangle() {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext context = drawingVisual.RenderOpen()) {
                Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
                context.DrawRectangle(Brushes.Tomato, null, rect);
            }
            return drawingVisual;
        }

        protected override int VisualChildrenCount => visuals.Count;
        protected override Visual GetVisualChild(int index) {
            if(index < 0 || index >= visuals.Count) {
                throw new ArgumentOutOfRangeException();
            } else {
                return visuals[index];
            }
        }
    }
}
