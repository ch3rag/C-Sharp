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

namespace WPFRoutedEvents {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        string mouseActivty;
        public MainWindow() {
            InitializeComponent();
        }

        private void BtnClickMe_Click(object sender, RoutedEventArgs e) {
            AddEventInfo(sender, e);
            MessageBox.Show(mouseActivty, "Your Event Info");
            // MessageBox.Show("Clicked The Button!");
        }

        private void outerEllipse_MouseDown(object sender, MouseButtonEventArgs e) {
            // this.Title = "You Clicked The Outer Ellipse";
            // e.Handled = true;
            AddEventInfo(sender, e);
        }

        private void outerEllipse_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            AddEventInfo(sender, e);
        }

        private void AddEventInfo(object sender, RoutedEventArgs e) {
            mouseActivty += string.Format($"{sender} sent a {e.RoutedEvent.RoutingStrategy} event named {e.RoutedEvent.Name}.\n");
        }
    }
}
