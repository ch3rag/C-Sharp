using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RenderingWithShapes {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private enum SelectedShape {
            Circle,
            Rectangle,
            Line
        };

        private SelectedShape currentShape;
        public MainWindow() {
            InitializeComponent();
        }

        private void DrawingArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            // Create a new shape
            Shape shapeToRender = null;

            switch(currentShape) {
                case SelectedShape.Circle:
                    // <GradientStop Color = "#FFC4DEBC" />
                    // <GradientStop Color = "#FF104700" Offset = "1" />
                    // <GradientStop Color = "#FF53C332" Offset = "0.53" />
                    shapeToRender = new Ellipse() {
                        Height = 35,
                        Width = 35
                    };
                    RadialGradientBrush brush = new RadialGradientBrush();
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FFC4DEBC"), 0));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF104700"), 1));
                    brush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF53C332"), 0.53));
                    shapeToRender.Fill = brush;
                    break;
                case SelectedShape.Rectangle:
                    shapeToRender = new Rectangle() {
                        Fill = Brushes.Red,
                        Height = 35,
                        Width = 35,
                        RadiusX = 10,
                        RadiusY = 10
                    };
                    break;
                case SelectedShape.Line:
                    shapeToRender = new Line() {
                        Stroke = Brushes.Blue,
                        StrokeThickness = 10,
                        X1 = 0, X2 = 0, Y1 = 0, Y2 = 50,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Round
                    };
                    break;
            }

            // You cannot do something line 
            // shapeToDraw.Canvas.Left = mouseX;

            // since Canvas.Left Property of shape is a dependency property
            // so we will use Canvas.SetLeft and Canvas.SetTop Method of canvas class to set those dependency properties
            Canvas.SetLeft(shapeToRender, e.GetPosition(DrawingArea).X);
            Canvas.SetTop(shapeToRender, e.GetPosition(DrawingArea).Y);

            if(FlipToggle.IsChecked == true) {
                RotateTransform flip = new RotateTransform(-180);
                shapeToRender.RenderTransform = flip;
            }

            DrawingArea.Children.Add(shapeToRender);
        }

        private void CircleOption_Click(object sender, RoutedEventArgs e) {
            currentShape = SelectedShape.Circle;
        }

        private void RectOption_Click(object sender, RoutedEventArgs e) {
            currentShape = SelectedShape.Rectangle;
        }

        private void LineOption_Click(object sender, RoutedEventArgs e) {
            currentShape = SelectedShape.Line;
        }

        private void DrawingArea_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
            // Get Mouse Position
            Point mouse = e.GetPosition(DrawingArea);

            // HitTest method of VisualTreeHelper detect if the user clicked an item on the canvas
            HitTestResult result = VisualTreeHelper.HitTest(DrawingArea, mouse);

            if(result != null) {
                // get the shape user as click on
                Shape clickedShape = result.VisualHit as Shape;

                // Remove the shape
                DrawingArea.Children.Remove(clickedShape);
            }


        }

        private void FlipToggle_Click(object sender, RoutedEventArgs e) {
            if(FlipToggle.IsChecked == true) {
                RotateTransform flip = new RotateTransform(-180);
                DrawingArea.LayoutTransform = flip;
            } else {
                DrawingArea.LayoutTransform = null;
            }
        }
    }
}
