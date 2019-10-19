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

namespace ObjectResourcesApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            // properties such as GradientStop will change even using StaticResources
            RadialGradientBrush brush = (RadialGradientBrush)this.Resources["MyBrush"];
            brush.GradientStops[1] = new GradientStop(Colors.Black, 0);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            // Since cancel button uses a dynamic resource it will detect this change but ok button stays the same
            Resources["MyBrush"] = new SolidColorBrush(Colors.Red);
        }
    }
}
