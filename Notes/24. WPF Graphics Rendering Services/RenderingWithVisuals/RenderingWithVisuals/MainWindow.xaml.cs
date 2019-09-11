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

namespace RenderingWithVisuals {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            const int TextSize = 40;
            FormattedText text = new FormattedText(
                    "Hello Visual Layer",
                    new System.Globalization.CultureInfo("en-US"),
                    FlowDirection.LeftToRight,
                    new Typeface(this.FontFamily, FontStyles.Italic, FontWeights.DemiBold, FontStretches.UltraExpanded),
                    TextSize,
                    Brushes.Green,
                    null,
                    VisualTreeHelper.GetDpi(this).PixelsPerDip);

            // Render Using Visual
            DrawingVisual drawingVisual = new DrawingVisual();

            // Obtain context from visual
            using (DrawingContext context = drawingVisual.RenderOpen()) {
                context.DrawRoundedRectangle(Brushes.Yellow, new Pen(Brushes.Black, 5), new Rect(5, 5, 400, 100), 20, 20);
                context.DrawText(text, new Point(20, 20));
                
            }

            // render visual using a bitmap
            RenderTargetBitmap bitmap = new RenderTargetBitmap(500, 100, 100, 90, PixelFormats.Pbgra32);
            bitmap.Render(drawingVisual);

            // set source of the image to rendered bitmap
            MyImage.Source = bitmap;
        }
    }
}
