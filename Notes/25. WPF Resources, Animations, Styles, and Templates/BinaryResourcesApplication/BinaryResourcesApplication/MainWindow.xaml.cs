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

namespace BinaryResourcesApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<BitmapImage> images = new List<BitmapImage>();
        int currentImage = 0;
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            try {
                // Loose Resources
                //string path = Environment.CurrentDirectory;
                //images.Add(new BitmapImage(new Uri($@"{path}\Images\couple.jpg")));
                //images.Add(new BitmapImage(new Uri($@"{path}\Images\cat.jpeg")));
                //images.Add(new BitmapImage(new Uri($@"{path}\Images\rose.jpeg")));

                // Embedded Resources
                images.Add(new BitmapImage(new Uri(@"\Images\couple.jpg", UriKind.Relative)));
                images.Add(new BitmapImage(new Uri(@"\Images\cat.jpeg", UriKind.Relative)));
                images.Add(new BitmapImage(new Uri(@"\Images\rose.jpeg", UriKind.Relative)));
                PictureHolder.Source = images[currentImage];
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } 
        }

        private void PreviousImageButton_Click(object sender, RoutedEventArgs e) {
            currentImage = ((currentImage - 1) + images.Count) % images.Count;
            PictureHolder.Source = images[currentImage];
        }

        private void NextImageButton_Click(object sender, RoutedEventArgs e) {
            currentImage = (currentImage + 1) % images.Count;
            PictureHolder.Source = images[currentImage];
        }
    }
}
