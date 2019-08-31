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

namespace WpfTestingApplication {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            this.Closing += MainWindow_Closing;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e) {
            ClickMe.Content = e.Key.ToString();
        }

        void MainWindow_MouseMove(object sender, MouseEventArgs e) {
            this.Title = e.GetPosition(this).ToString();
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            string message = "Do you want to close without saving?";
            MessageBoxResult result = MessageBox.Show(message, "My App", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No) {
                e.Cancel = true;
            }   
        }

        void MainWindow_Closed(object sender, EventArgs e) {
            MessageBox.Show("See Ya!");
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e) {
            if ((bool)Application.Current.Properties["GodMode"]) {
                MessageBox.Show("Cheater");
            } else {
                MessageBox.Show("Fair Play");
            }
        }

        private void DateOfBirth_SelectedDatesChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
